
using System;
using System.Drawing;
using System.Collections;
using System.Runtime.Serialization;

namespace GBusManager
{
    [Serializable()]
	/// <summary>
	/// Description of Route.
	/// </summary>
	public class Route
	{
        public string rs;
		public int[] nodes;

        public int n;

        bool deleted;

        public Color color;
        
		public int Length {
			get {
				return nodes.Length;
			}
		}
		public Route(string s)
		{
            if (s.Length > 0)
            {
                rs = s;
                Random rndm = new Random();
                color = Color.FromArgb(rndm.Next(255), rndm.Next(255), rndm.Next(255));

                string[] ns = s.Split();
                nodes = new int[ns.Length];

                //if (ns.Length < 2) { throw new Exception("Route must have at least 2 nodes length"); }
                for (int i = 0; i < ns.Length; i++)
                {
                    nodes[i] = int.Parse(ns[i]);
                }
            }
            else {
                Console.WriteLine("Empty route");
            }
		}
		
		public Route(int[] nn){
			nodes = nn;
		}

        public override string ToString()
        {
            return ""+n+"." + "[" + rs + "]";
        }

        public int Near(int n, int d)
        {
            int i = 0;// = rs.IndexOf(n.ToString());
            try
            {
                for (i = 0; i < nodes.Length && nodes[i] != n; i++)
                    ;
                //ArrayList a;
                //a.AddRange();
           
                //if (i+d) 
                return nodes[i + d];
            }
            catch { return nodes[i - d]; } 
        }


	}
}
