
using System;
using System.Collections.Generic;
using System.Collections;
//using System.Windows.Forms;
using System.Linq;

namespace  GBusManager
{

    // струкутра предназначенная для хранения
    // пары соседний узел - номер маршрута
	public struct AdjNode {
		public Node node;
		public int route;
		Graph graph;
		
		public AdjNode(Graph g, int nn, int rn){
			graph = g;
			node = g.GetNode(nn);
			route = rn;
		}
		
		public override string ToString()
		{
			return "node "+ node.n + " ["+route+"]";
		}
	}

	/// <summary>
	/// Description of Node.
	/// </summary>
    [Serializable()]
	public class Node
	{
		#region fields
		
		// номер узла
		public int n;
		
		// минимальный автобусный маршрут
		public int r = -1;

        public Route route;

        public Node prev;
        public int prevn;
		
		// длина минимального пути
		public int len = int.MaxValue / 3;

        
		
		Graph graph;

        public Point point;

		#endregion
		
		int X;
		int Y;

        

		//Label label;
		
		public ArrayList neighbors = new ArrayList();

        //public List<AdjNode> neighbors2 = new List<AdjNode>();

        public Dictionary<string, int> d = new Dictionary<string, int>();

        public List<KeyValuePair<string, int>> h = new List<KeyValuePair<string, int>>();

        //public Has
	
		
		// посещена
		public bool v;


        //TODO: 
        
        
        
        // маршруты которые содержат эту точку
        public HashSet<Route> routes = new HashSet<Route>();


        public Dictionary<Route,int> routesValues = new Dictionary<Route,int>();

        public bool NewRouteValue(Route r, int value){
            if (routesValues.Keys.Contains(r)){
                // уже есть с таким ключом

                if (routesValues[r]>value){

                    routesValues[r] = value;

                    route = r;
                    len = value;
                }
                return false;
            }
            else {
                routesValues.Add(r,value);
                if (routesValues.Values.Min() > value)
                {
                    Console.WriteLine("\tНо найдено меньшее значение");
                    route = r;
                    len = value;
                }
                return true;
            }
        }


        public bool Visited
        {
            
            get
            {
                /*
                foreach (int p in routesValues.Values)
                {
                    if (p == int.MaxValue/2) return false;
                }
                return true;
                 */
#if DEBUG
                Console.WriteLine("Visited? {0}", n);
                Console.WriteLine("_vc = {0} d.Count = {1} routes.Count = {2}", _vc,d.Count,routes.Count);
#endif
                return (_vc >= d.Count && _vc >=routes.Count );
                //return _vc == 1;
            }
        }

        // visited counter
        int _vc;
        public void Visit(){

            //if (_vc < .Count)
            //{
                _vc++;
            //}
        }

        public void RouteVisit(Route r)
        {
            Console.WriteLine("у {0} route = {1}",this.n, r.n);
            route = r;
        }
        
		
		
		public Node(Graph g, int bn)
		{
			graph = g;
			n = bn;
            len = int.MaxValue;
            
            
		}
		
		public Node(int bn, int x, int y)
		{
			//graph = g;
			n = bn;
			X = x;
			Y = y;
			//label = l;
            len = int.MaxValue;
		}
		
		public Node(){
            len = int.MaxValue;
		}
		
		// добавление смежного
		public void AddAdj(int n, int r){
            AdjNode an = new AdjNode(graph,n,r);
			neighbors.Add(an);
            //neighbors2.Add(an);
		}
		


        public Node Neighbor(int r, int d)
        {
            // r - route
            // d - direction
            return graph.GetNode(graph.routes[r].Near(n, d));
        }
		
		public override string ToString()
		{
            return n.ToString();
		}

        public string Info
        {
            get
            {
                string s = "Node " + n + " Info:\n\tСоседи:";
                foreach (AdjNode an in neighbors)
                {
                    s += "\n\t\t" + an.node.n + "[" + an.route + "]";
                }
                s += "\n\tМаршруты:";

                foreach (Route r in routes)
                {
                    s += "\n\t\t" + r.n;
                }

                s += "\n\tДлины путей:";
                foreach (KeyValuePair<Route, int> kvp in routesValues)
                {
                    s += "\n\t\t[" + kvp.Key.n+ "] " + kvp.Value;
                }
                return n + "\n" + s;
            }
        }

        //public 

    }
}
