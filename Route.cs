
using System;
using System.Drawing;

namespace GBusManager
{
	/// <summary>
	/// Description of Route.
	/// </summary>
	public class Route
	{
        public string rs;
		public int[] nodes;

        public int n;

        public Color color;
        
		public int Length {
			get {
				return nodes.Length;
			}
		}
		public Route(string s)
		{
            rs = s;
            Random rndm = new Random();
            color = Color.FromArgb(rndm.Next(255), rndm.Next(255), rndm.Next(255));

			string[] ns = s.Split();
			nodes = new int[ns.Length];

            if (ns.Length < 2) { throw new Exception("Route must have at least 2 nodes length"); }
			for (int i = 0; i< ns.Length; i++){
				nodes[i] = int.Parse(ns[i]);
			}
		}
		
		public Route(int[] nn){
			nodes = nn;
		}

        public override string ToString()
        {
            return rs;
        }


	}
}
