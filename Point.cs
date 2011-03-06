using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GBusManager
{
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

        public override string ToString()
        {
            return "" + N.ToString() ;
        }

    }
}
