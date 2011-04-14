
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
                //color = RandomColor();
                color = RandomColorHSV(rndm.Next(), rndm.NextDouble(), rndm.NextDouble());
                Console.WriteLine("RandomColor {0}", color.ToString());


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

        Color RandomColor()
        {
            Random random = new Random();
            int red = random.Next(random.Next(255));
            int green = random.Next(random.Next(255));
            int blue = random.Next(random.Next(255));
            Color color;
            color = Color.FromArgb(red, green, blue);
            //color = Color.F
            return color;
        }

        Color RandomColorHSV(double hue, double saturation, double value)
        {

            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
            
            

             
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
