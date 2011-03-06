using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GBusManager
{
    public partial class GraphViewer : UserControl
    {
        Graph graph;

        public bool multiSelect;

        protected ArrayList points;

        protected Misc.Mode mode;

        Point hoverPoint;

        bool hover;

        Label hoverLabel;

        public void SetMode(Misc.Mode m)
        {
            mode = m;
        }


        public Point selectedPoint;

        public GraphViewer()
        {
            InitializeComponent();
            Status.Points = points;
        }

        public GraphViewer(Graph g)
        {
            graph = g;
            points = new ArrayList(g.nodes.Length);
            InitializeComponent();
        }

        void DrawNodeAt(Point point,bool label)
        {
            int x = point.X;
            int y = point.Y;
            int n = point.N;
            Graphics g = this.CreateGraphics();
            Color color;
            if ((point == selectedPoint) || (point.selected && multiSelect))
            {
                color = Color.Blue;
                
            }
            else color = Color.Black;

            if (label)
            {
                Label lbl = new Label();
                lbl.Text = n.ToString();
                lbl.Font = new Font(FontFamily.GenericMonospace, 8); ;
                lbl.AutoSize = true;
                //Pen p = new Pen(Color.Black);
                this.Controls.Add(lbl);
                lbl.BorderStyle = BorderStyle.None;
                lbl.Top = y + lbl.Height / 2;
                lbl.Left = x + lbl.Width / 2;
                Controls.Add(lbl);
            }

            g.FillEllipse(new SolidBrush(color), x - point.Size / 2, y - point.Size / 2, point.Size, point.Size);
        }

        void DrawEdge(Point s, Point f, Color color)
        {
            Graphics g = this.CreateGraphics();
            g.DrawLine(new Pen(color), s.X, s.Y, f.X, f.Y);
        }

        public void DrawRoute(Route r, bool clear)
        {
            Graphics g = this.CreateGraphics();
            if (clear) g.Clear(Color.White);
            DrawNodes(true);

            for (int i = 0; i < r.Length - 1; i++)
            {
                DrawEdge((Point)points[r.nodes[i]], (Point)points[r.nodes[i + 1]],r.color);
            }
        }

        public void DrawAll()
        {
            foreach (object n in points)
            {
                DrawNodeAt((Point)n,false);
            }

            /*
            foreach (object n in l)
            {
                DrawNodeAt((Point)n);
            }
             */
        }

        public void DrawNodes(bool l)
        {
            foreach (object n in points)
            {
                DrawNodeAt((Point)n,l);
            }
        }

        public void Redraw(bool l)
        {
            Graphics g = this.CreateGraphics();
            this.Controls.Clear();
            g.Clear(Color.White);
            DrawNodes(l);
        }

        public Point FindNear(int x, int y, int d)
        {
            if (points != null)
            {
                //g
                
                for (int i = 0; i < points.Count; i++)
                {
                    Point p = (Point)points[i];
                    if (p.X >= x - d && p.X <= x + d && p.Y >= y - d && p.Y <= y + d)
                    {
                        return p;
                    }
                }
            }

            else
            {
                //hover = false;
            }
            return null;

        }



        private void GraphView_Load(object sender, EventArgs e)
        {

        }

        public virtual void GraphView_MouseClick(object sender, MouseEventArgs e)
        {

           
        }

        private void GraphViewer_MouseHover(object sender, EventArgs e)
        {

        }

        private void GraphViewer_MouseMove(object sender, MouseEventArgs e)
        {
            /*
            Point p;
            Status.x = e.X;
            Status.y = e.Y;
            ////if (hoverLabel != null) Controls.Remove(hoverLabel);

            if (!hover)
            {
                p = FindNear(e.X, e.Y, 2);
                if (p != null)
                {
                    //hover = true;
                    hoverLabel = new Label();
                    hoverLabel.Text = p.N.ToString();
                    hoverLabel.Font = new Font(FontFamily.GenericMonospace, 8); ;
                    hoverLabel.AutoSize = true;
                    //Pen p = new Pen(Color.Black);
                    this.Controls.Add(hoverLabel);
                    hoverLabel.BorderStyle = BorderStyle.FixedSingle;
                    hoverLabel.Top = p.X + 10;
                    hoverLabel.Left = p.Y + 10;
                    //hoverLabel = lbl;
                }
            }
            else { hover = false; Controls.Remove(hoverLabel); }
             */ 
        }
    }
}
