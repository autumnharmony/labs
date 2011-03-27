using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace GBusManager
{
    [Serializable()]
    public class Point
    {
        public int N
        {
            get { return n; }
            //set { n = value; }
        }

        int x, y;
        int n;
        public bool selected;
        int size;
        Color color;

        public int Size
        {
            get { return size; }
            //set { si = value; }
        }

        

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }



        public Point(int x1, int y1, int nn)
        {
            x = x1;
            y = y1;
            n = nn;

            size = Settings1.Default.NodeSize;
        }

        public Point(int x1, int y1, int s, Color c)
        {
            x = x1;
            y = y1;
            size = s;
            color = c;
        }

        public Point(int x1, int y1, int s, int n, Color c)
        {
            x = x1;
            y = y1;
            size = s;
            color = c;
            this.n = n;
        }

        public Point(int x1, int y1)
        {
            x = x1;
            y = y1;
            //size = Settings1.Default.NodeSize;
        }

        public Point(Node n)
        {
            size = Settings1.Default.NodeSize;
        }

        public Point()
        {
            size = Settings1.Default.NodeSize;
        }

        public Point Colored(Color c)
        {
            return new Point(x, y, size, c);
        }

        public Point Sized(int s)
        {
            return new Point(x, y, s, color);
        }




        public override string ToString()
        {
            //return "" + N.ToString() ;
            return String.Format("{0} ({1},{2})",N, X, Y);
        }

        
        public static implicit operator System.Drawing.Point(Point p)
        {
            return new System.Drawing.Point(p.X, p.Y);
        }

    }
}
