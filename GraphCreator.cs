using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace GBusManager
{


 

    public partial class GraphCreator :  GraphViewer
    {
        int c;

        bool drawLine;

        int x1, y1;
        public string crs = "";
        int lpn = -1;
        Point s,f;

        ToolsPanel tp;



        GState prevstate;

        //ArrayL

        public ArrayList tempedges = new ArrayList();

        public ArrayList tempdiredges = new ArrayList();

        public ArrayList activeroutes = new ArrayList();

        public GraphCreator()
        {
            //points = new System.Collections.ArrayList();
            points = Status.Points;
            //edges = Status.
            this.g = this.CreateGraphics();
            InitializeComponent();

            Status.myPoints.PointAdded += new PointAddedHandler(myPoints_PointAdded);
        }

        void myPoints_PointAdded(object sender, PointsEventArgs e)
        {
            Console.WriteLine("GraphCreator должен нарисовать новую точку {0}",e.point);
        }

        public void ResetRouteInfo()
        {
            lpn = -1;
            crs = "";
            tempedges.Clear();
            state = GState.NodesAndRoutes;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void GraphCreator_Load(object sender, EventArgs e)
        {

        }

        public override void GraphView_MouseClick(object sender, MouseEventArgs e)
        {
            if (Status.mode == Misc.Mode.Point)
            {
                #region Point

                g.FillEllipse(new SolidBrush(Color.Black), e.X - Settings1.Default.NodeSize / 2, e.Y - Settings1.Default.NodeSize / 2, Settings1.Default.NodeSize, Settings1.Default.NodeSize);
                
                TextBox tb = new TextBox();
                this.Controls.Add(tb);
                tb.Left = e.X;
                tb.Top = e.Y - tb.Height;
                tb.Width = 20;
                tb.Text = c.ToString();
                Button addBtn = new Button();
                
                addBtn.Left = e.X + tb.Width;
                addBtn.Top = e.Y - addBtn.Height;
                addBtn.Width = 20;
                addBtn.Click += delegate
                {
                    c++;
                    this.Controls.Remove(addBtn);
                    this.Controls.Remove(tb);
                    /*
                    Label lbl = new Label();
                    lbl.Text = tb.Text;
                    Font f = new Font(FontFamily.GenericMonospace, 8);
                    lbl.Font = f;

                    lbl.AutoSize = true;
                    Pen p = new Pen(Color.Black);

                    this.Controls.Add(lbl);
                    lbl.BorderStyle = BorderStyle.None;
                    lbl.Top = e.Y + lbl.Height / 2;
                    lbl.Left = e.X + lbl.Width / 2;
                    */
                    //g.DrawString(n.ToString(), new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(x, y));
                    Node n = new Node(int.Parse(tb.Text), e.X, e.Y);
                    Point pp = new Point(e.X, e.Y, int.Parse(tb.Text));
                    Status.myPoints.Add(pp);
                    points.Add(pp);
                    Status.tp.RefreshRoutesAndPoints();
                };
                this.Controls.Add(addBtn);
                #endregion 
            }
            if (Status.mode == Misc.Mode.Select)
            {
                #region Select
                Point p;
                
                if ((Control.ModifierKeys & Keys.Control) != 0)  multiSelect = true; else { multiSelect = false; foreach (Point pnt in points) pnt.selected = false;}
                if ((p = FindNear(e.X, e.Y, 10)) != null)
                {
                    selectedPoint = p;
                    p.selected = true;
                }
                //Redraw(true);
                #endregion
            }
        }

        

        private void GraphCreator_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void GraphCreator_MouseUp(object sender, MouseEventArgs e)
        {

         	if (drawLine) {
				Point p = FindNear(e.X,e.Y,10);
				if (p!=null) {
					f = p;
					drawLine = false;
                    //state = GState.RouteDraw;
					
                    if (Status.DEBUG) MessageBox.Show("("+x1+","+y1+") -> ("+p.X+","+p.Y+")");
					
                    //DrawNodes(true);
                    tempedges.Add(new Edge(s, p, 0, 0));

                    g.DrawLine(new Pen(Color.Black), x1, y1, p.X, p.Y);

					lpn = p.N;
					crs +=" "+ p.N;

                    
				}
                
			}
            
		}

         
        

        private void GraphCreator_MouseDown(object sender, MouseEventArgs e)
        {

            if (Status.mode == Misc.Mode.Line)
            {



                Point p = FindNear(e.X, e.Y, 10);
                if (p != null && (p.N == lpn || lpn == -1))
                {
                   
                    
                    drawLine = true;
                    GState prevstate = state;
                    state = GState.RouteDraw;
                    s = p;
                    x1 = p.X;
                    y1 = p.Y;
                    if (crs == "") { crs += "" + p.N;  }
                }
            }

        }

        private void GraphCreator_Paint(object sender, PaintEventArgs e)
        {
            //this.DrawAll();
            Console.WriteLine("GraphCreator_Paint");
            switch (state){

                case GState.OnlyNodes:
                    {
                        Console.WriteLine("OnlyNodes");
                        DrawNodes(true);
                        break;
                    }
                case GState.NodesAndRoutes:
                    {
                        Console.WriteLine("NodesAndRoutes");
                        DrawNodes(true);
                        edges.Clear();
                        DrawRoutes((Route[])Status.graphcreator.activeroutes.ToArray(typeof(Route)));
                        break;
                    }
                case GState.RouteDraw:
                    {
                        Console.WriteLine("RouteDraw");
                        DrawNodes(true);
                        DrawTempEdges(tempedges);
                        break;
                    }
                case GState.ResultPath:
                    {
                        DrawNodes(true);
                        foreach (object o in tempdiredges){
                            Edge ed = (Edge)o;
                            DrawDirectEdge(ed.P1, ed.P2, ed.c);
                        }
                        break;

                    }
            }

            
        }

        public void DrawExisting()
        {

        }


        public enum GState
        {
         OnlyNodes,
         NodesAndRoutes,
         RouteDraw,
         ResultPath
        }

        public GState state = GState.NodesAndRoutes;
        /*
        public State State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
                ViewEventArgs vea = new ViewEventArgs();
                vea.State = value;
                if (value == GState.NodesAndRoutes)
                {
                    OnViewEvent(vea);
                }
            }
        }
          */
     

       
    }
}
