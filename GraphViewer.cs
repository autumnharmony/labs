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
        public event MyEventHandler MyEvent;
        
        protected virtual void OnMyEvent(MyEventArgs e)
        {
            MyEvent(this, e);
        }

        Graph graph;

        public bool multiSelect;

        // PUBLIC!
        public  ArrayList points;
        public  ArrayList edges;

        protected Misc.Mode mode;

        protected Graphics g;

        // какие машруты выделены
        //ArrayList ActiveRoutes;

        public void SetMode(Misc.Mode m)
        {
            mode = m;
        }


        public Point selectedPoint;

        public GraphViewer()
        {
            edges = new ArrayList();
            g = this.CreateGraphics();
            InitializeComponent();
            points = Status.Points;
        }

        public GraphViewer(Graph g)
        {
            graph = g;
            points = new ArrayList(g.nodes.Length);
            Status.Points = points;
            edges = new ArrayList();
            InitializeComponent();
        }

        void DrawNodeAt(Point point,bool label)
        {
            int x = point.X;
            int y = point.Y;
            int n = point.N;
            //Graphics g = this.CreateGraphics();
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
            /*
             * TODO: проверка, если уже нарисовано, то нарисовать со смещением
             */ 
            ///
            //if (!Settings1.Default.AdditionalEdgeEllipsis)
            //{
                bool shift = false;
                int c = 0; // количество уже нарисованных

                foreach (Edge e in edges)
                {
                    if (e.P1 == s && e.P2 == f || e.P2 == s && e.P1 == f)
                    {
                        // нужно сместить
                        c++;
                        shift = true;
                        //break;
                    }
                }
                ///

                //Graphics g = this.CreateGraphics();

                edges.Add(new Edge(s, f, Status.Routes.Count + 1, c));
                if (shift)
                {
                    Console.WriteLine("Уже есть ребро {0},{1} нужно сместить", s.N.ToString(), f.N.ToString());
                    Point p1, p2, p3, p4;
                    float k;
                    p1 = s;
                    p4 = f;

                    p2 = new Point();
                    p3 = new Point();

                    

                    int cc = Settings1.Default.BetweenEdgesK * ((c+1) / 2) ;

                    k = (p4.Y - p1.Y) / (p4.X - p1.X);

                    if (c % 2 == 0)
                    {
                        //if (!Settings1.Default.AdditionalEdgeEllipsis) 
                            //g.DrawLine(new Pen(color), s.X, s.Y - c / 2, f.X, f.Y - c / 2);
                        //else
                        //{

                            p2.X = (int)(p1.X - cc * Math.Cos(Math.Atan(k)));
                            p2.Y = (int)(p1.Y - cc * Math.Sin(Math.Atan(k)));

                            p3.X = (int)(p4.X - cc * Math.Cos(Math.Atan(k)));
                            p3.Y = (int)(p4.Y - cc * Math.Sin(Math.Atan(k)));
                            //g.DrawArc(new Pen(color), (float)s.X, (float)s.Y, (float)Math.Abs(f.X - s.X), (float)c * 10, 0, (float)Math.PI);
                            if (Status.ElEd)
                            {
                                Point p23 = new Point();
                                p23 = MidShiftPoint(p1, p4, -1, cc);
                                g.DrawBezier(new Pen(Color.Green), p1, p23, p23, p4);
                                DrawPoint(p23.Sized(5));
                            }

                            else {
                                g.DrawLine(new Pen(color,1.5f), s.X, s.Y - c*2, f.X, f.Y - c*2);
                            }

                            //g.DrawBezier(new Pen(color), p1, p2, p3, p4);
                        //}
                        //DrawPoint(new Point(p2.X,p2.Y,2,Color.Blue));
                        //DrawPoint(new Point(p3.X,p3.Y,2,Color.Blue));
                    }
                    else
                    {

                        //if (!Settings1.Default.AdditionalEdgeEllipsis)

                            //g.DrawLine(new Pen(color), s.X, s.Y + (c + 1) / 2, f.X, f.Y + (c + 1) / 2);

                        //else
                        //{


                            /*
                             * Точки для кривой безье
                             */




                            /*
                            pp2.X = Math.Min(p1.X, p4.X) + Math.Abs(p4.X - p1.X) / 3;
                            pp2.Y = Math.Min(p1.Y, p4.Y) + Math.Abs(p1.Y - p4.Y) / 3;

                            pp3.X = Math.Min(p1.X, p4.X) + 2 * Math.Abs(p4.X - p1.X) / 3;
                            pp3.Y = Math.Min(p1.Y, p4.Y) + 2 * Math.Abs(p1.Y - p4.Y) / 3;
                             */



                            /*
                            p2.X = (int)(pp2.X - cc * Math.Cos(Math.Atan(k)));
                            p2.Y = (int)(pp2.Y - cc * Math.Sin(Math.Atan(k)));

                            p3.X = (int)(pp3.X - cc * Math.Cos(Math.Atan(k)));
                            p3.Y = (int)(pp3.Y - cc * Math.Sin(Math.Atan(k)));
                            */

                            p2.X = (int)(p1.X + cc * Math.Cos(Math.Atan(k)));
                            p2.Y = (int)(p1.Y + cc * Math.Sin(Math.Atan(k)));

                            p3.X = (int)(p4.X + cc * Math.Cos(Math.Atan(k)));
                            p3.Y = (int)(p4.Y + cc * Math.Sin(Math.Atan(k)));

                            if (Status.ElEd)
                            {

                                Point p23 = new Point();
                                p23 = MidShiftPoint(p1, p4, 1, cc);
                                g.DrawBezier(new Pen(color), p1, p23, p23, p4);
                                DrawPoint(p23.Sized(5));
                            }

                            else
                            {
                                g.DrawLine(new Pen(color,1.5f), s.X, s.Y+c*2, f.X, f.Y+c*2);
                            }
                            //g.DrawBezier(new Pen(color), p1, p2, p3, p4);
                            //DrawPoint(p2);
                            //DrawPoint(p3);
                        //}
                    }

                }
                else g.DrawLine(new Pen(color), s.X, s.Y, f.X, f.Y);
            //}
            //else
            //{
                // эллиптические дуги

            //}
        }


        Point MidPoint(Point p1,Point p2){

            Console.WriteLine("MidPoint:");
            Console.WriteLine("p1({0},{1}) p2({2},{3})", p1.X, p1.Y, p2.X, p2.Y);
            int x = Math.Min(p1.X, p2.X) + ((Math.Max(p1.X, p2.X) - Math.Min(p1.X, p2.X)) / 2);
            int y = Math.Min(p1.Y, p2.Y) + ((Math.Max(p1.Y, p2.Y) - Math.Min(p1.Y, p2.Y)) / 2);
            Console.WriteLine("p({0},{1})", x,y);
            Point p = new Point(x,y);
            //if (Status.DEBUG) 
                DrawPoint(p.Sized(5).Colored(Color.Black));
            return p;
        }

        Point MidShiftPoint(Point p1, Point p2, int s, int c)
        {
            Console.WriteLine("MidShiftPoint:");
            Console.WriteLine("p1({0},{1}) p2({2},{3})", p1.X, p1.Y, p2.X, p2.Y);
            // коэф = tg 
            //double k = ((double)(Math.Max(p1.Y, p2.Y) - Math.Min(p1.Y, p2.Y))) / (double)((Math.Max(p1.X, p2.X) - Math.Min(p1.X, p2.X)));
            double k = (double)(p2.Y - p1.Y) / (double)(p2.X - p1.X);
            Console.WriteLine("k = {0}", k);
            Point mp = MidPoint(p1, p2);

            // s - side (+1 || -1)
            int x;
            int y;
            //if (p1.N < p2.N)
            //{
                x = (int)(mp.X + s * c * Math.Sin(Math.Atan(k)));
                y = (int)(mp.Y + (-1) * s * c * Math.Cos(Math.Atan(k)));
            //}
            //else
            //{
                //x = (int)(mp.X + s * c * Math.Sin(Math.Atan(-k)));
                //y = (int)(mp.Y + (-1) * s * c * Math.Cos(Math.Atan(-k)));
            //}
            Console.WriteLine("p({0},{1})", x, y);
            return new Point(x, y);

        }

        public void DrawPoint(Point p)
        {
            Console.WriteLine("Drawing point ({0},{1}) with Size = {2}", p.X, p.Y, p.Size);
            g.FillEllipse(new SolidBrush(Color.Black), p.X - p.Size / 2, p.Y - p.Size / 2, Settings1.Default.NodeSize, Settings1.Default.NodeSize);
        }

        public void DrawDirectEdge(Point p1, Point p2, Color c)
        {
            Console.WriteLine("DrawDirecEdge with p1 = {0}, p2 = {1}, color = {2}", p1.ToString(), p2.ToString(), c.ToString());
            //Graphics g = this.CreateGraphics();
            

            // стрелка
            Pen p = new Pen(c);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //g.ScaleTransform(
            p.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            p.CustomStartCap = new System.Drawing.Drawing2D.AdjustableArrowCap(8, 5, true);
            //p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            g.DrawLine(p, p1.X, p1.Y, p2.X, p2.Y);

            //g.DrawLine(new Pen(c), p)
            //g.DrawLine(new Pen(c), p)
        }

        /// <summary>
        /// Рисует одно ребро из маршрута
        /// </summary>
        /// <param name="r"></param>
        public void DrawRouteEdge(Route r,Point p1, Point p2)
        {
            if (r.rs.Contains(" " + p1.N + " " + p2.N + " "))
            {
                // прямой порядок

                for (int i = 0; i < r.Length; i++)
                {
                    if (r.nodes[i] == p1.N)
                    {
                        DrawDirectEdge(p1, p2, r.color);
                    }
                }
            }

            if (r.rs.Contains(" " + p2.N + " " + p1.N + " "))
            {
                // обратный порядок

                for (int i = 0; i < r.Length; i++)
                {
                    if (r.nodes[i] == p2.N)
                    {
                        DrawDirectEdge(p2, p1, r.color);
                    }
                }


            }
        }

        public void DrawRoute(Route r, bool clear)
        {
            //Graphics g = this.CreateGraphics();
            if (clear) g.Clear(Color.White);
            DrawNodes(true);

            for (int i = 0; i < r.Length - 1; i++)
            {
                DrawEdge((Point)points[r.nodes[i]], (Point)points[r.nodes[i + 1]],r.color);
            }
        }

        public void DrawRoutes(Route[] routes)
        {
            foreach (Route r in routes)
            {
                DrawRoute(r,false);
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
            edges.Clear();
            //Graphics g = this.CreateGraphics();
            this.Controls.Clear();
            g.Clear(Color.White);
            DrawNodes(l);
        }

            
        /// <summary>
        /// Ищет рядом с (x,y) вершину с точностью d
        /// </summary>
        /// <param name="x">x координата</param>
        /// <param name="y">y координата</param>
        /// <param name="d">d точность</param>
        /// <returns>точку</returns>
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
            MyEventArgs ea = new MyEventArgs();
            ea.X = e.X;
            ea.Y = e.Y;
            if (MyEvent!= null) MyEvent(this, ea);
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

    public delegate void MyEventHandler(object sender, MyEventArgs e);

    public class MyEventArgs : EventArgs
    {
        public int X;
        public int Y;
        public int N;
    }
}
