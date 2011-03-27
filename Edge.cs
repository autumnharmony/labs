using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GBusManager
{
    /// <summary>
    /// Ребро графа
    /// </summary>
    [Serializable()]
    class Edge
    {
        Point p1;
        Point p2;

        int route;

        public int n;

        public Color c;

        public Point P1
        {
            get { return p1; }
        }

        public Point P2
        {
            get { return p2; }
        }
        
        /// <summary>
        /// </summary>
        /// <param name="a">начальная точка</param>
        /// <param name="b">конечная точка</param>
        /// <param name="r">маршрут</param>
        /// <param name="n">какое по счету, соединяющее данные точки</param>
        public Edge(Point a, Point b, int r, int n){
            p1 = a;
            p2 = b;
            route = r;
            this.n = n;
        }

        public Edge(Point a, Point b, int r, int n,Color c)
        {
            p1 = a;
            p2 = b;
            route = r;
            this.n = n;
            this.c = c;
        }
        
    }
}
