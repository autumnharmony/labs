using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        Button endRouteBtn;// = new Button();

        public GraphCreator()
        {
            points = new System.Collections.ArrayList();
            Status.Points = points;
            InitializeComponent();


            endRouteBtn = new Button();
            endRouteBtn.Text = "";
            endRouteBtn.AutoSize = true;
            endRouteBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            endRouteBtn.Image = Resource1.cross;
            endRouteBtn.AutoSize = true;
            endRouteBtn.Click += delegate
            {
                try
                {
                    MessageBox.Show("|" + crs + "|");
                    crs = crs.Trim();
                    Status.Routes.Add(new Route(crs));

                    Status.tp.RefreshRoutes();
                    endRouteBtn.Hide();
                    crs = "";
                    lpn = -1;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                //((Control)Status.tp.Controls.Find("comboBox1", true)[0]).Update();
                //Status.mode = Misc.Mode.Select;
            };
            //Controls.Add(endRouteBtn);
            endRouteBtn.Hide();

        }

        public void ResetRouteInfo()
        {
            lpn = -1;
            crs = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void GraphCreator_Load(object sender, EventArgs e)
        {

        }

        public override void GraphView_MouseClick(object sender, MouseEventArgs e)
        {
            base.GraphView_MouseClick(sender, e);
            if (Status.mode == Misc.Mode.Point)
            {

                Graphics g = this.CreateGraphics();
                g.FillEllipse(new SolidBrush(Color.Black), e.X - Settings1.Default.NodeSize / 2, e.Y - Settings1.Default.NodeSize / 2, Settings1.Default.NodeSize, Settings1.Default.NodeSize);
                //g.FillEllipse(new SolidBrush(color), x - point.Size / 2, y - point.Size / 2, point.Size, point.Size);
                TextBox tb = new TextBox();
                this.Controls.Add(tb);
                tb.Left = e.X;
                tb.Top = e.Y - tb.Height;
                tb.Width = 20;
                tb.Text = c.ToString();
                Button btn = new Button();
                btn.Left = e.X + tb.Width;
                btn.Top = e.Y - btn.Height;
                btn.Width = 20;
                btn.Click += delegate
                {
                    c++;
                    this.Controls.Remove(btn);
                    this.Controls.Remove(tb);
                    Label lbl = new Label();
                    lbl.Text = tb.Text;
                    Font f = new Font(FontFamily.GenericMonospace, 8);
                    lbl.Font = f;


                    //lbl.AutoEllipsis = true;
                    lbl.AutoSize = true;
                    Pen p = new Pen(Color.Black);

                    this.Controls.Add(lbl);
                    //lbl.Width = 30;
                    //lbl.Height = 30;
                    lbl.BorderStyle = BorderStyle.None;
                    lbl.Top = e.Y + lbl.Height / 2;
                    lbl.Left = e.X + lbl.Width / 2;

                    Node n = new Node(int.Parse(tb.Text), lbl, e.X, e.Y);
                    Point pp = new Point(e.X, e.Y, int.Parse(tb.Text));

                    //MessageBox.Show(pp.ToString());
                    points.Add(pp);

                    DrawAll();



                };
                this.Controls.Add(btn);
            }
            if (Status.mode == Misc.Mode.Select)
            {
                Point p;
                
                if ((Control.ModifierKeys & Keys.Control) != 0)  multiSelect = true; else { multiSelect = false; foreach (Point pnt in points) pnt.selected = false;}
                if ((p = FindNear(e.X, e.Y, 10)) != null)
                {
                    selectedPoint = p;
                    p.selected = true;
                }
                Redraw(true);

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
                    
					this.CreateGraphics().DrawLine(new Pen(Color.Black),x1,y1,p.X,p.Y);
					//s.Node.AddAdj(f.Node.n,
                    DrawNodes(true);

                    endRouteBtn.Left = p.X - 20;
                    endRouteBtn.Top = p.Y - 20;
                    endRouteBtn.Show();

					lpn = p.N;
					crs +=" "+ p.N;

                    
				}
                //this.Controls.Clear();
                
                
                
                
                //this.Controls.Add(endRouteBtn);
			}
            
		}

         
        

        private void GraphCreator_MouseDown(object sender, MouseEventArgs e)
        {

            if (Status.mode == Misc.Mode.Line)
            {
                
                x1 = e.X;
                y1 = e.Y;
                Point p = FindNear(x1, y1, 10);
                if (p != null && (p.N == lpn || lpn == -1))
                {
                    
                    drawLine = true;
                    s = p;
                    x1 = p.X;
                    y1 = p.Y;
                    if (crs == "") { crs += "" + p.N; endRouteBtn.Show(); }
                }
            }

        }

       
    }
}
