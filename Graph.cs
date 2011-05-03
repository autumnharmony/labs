using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GBusManager
{
	/// <summary>
	/// Граф, с заданными узлами, маршрутами, нужен только для вычисления кратчайшего пути
	/// </summary>
	public class Graph
	{
		public Node[] nodes;
		public Route[] routes;

		Node current;
		int route;

        ArrayList points;
        // для восстановления пути 
        public Queue nodestomove = new Queue();

        PriorityQueue<int, Node> pq;

        Regex regex = new Regex(@"n(?<node>\d*)r(?<route>\d*)");

        /// <summary>
		/// Возвращает узел по номеру
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		public Node GetNode(int i){
			if (i>=0 && i<nodes.Length) return nodes[i];
            return null;
		}
        /// <summary>
        /// Возвращает маршрут по номеру
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Route GetRoute(int i)
        {
            if (i >= 0 && i < routes.Length) return routes[i];
            return null;
        }
			
		
		public Graph(ArrayList p, Route[] r)
		{
            points = p;
                routes = r;
                int n = p.Count;
                nodes = new Node[n];

                for (int i = 0; i < n; i++)
                {
                    nodes[i] = new Node(this, i);
                }

                for (int i = 0; i < r.Length; i++)
                {
                    for (int j = 0; j < r[i].Length - 1; j++)
                    {
                        // инициализация смежных

                        Node n1 = nodes[r[i].nodes[j]];
                        Node n2 = nodes[r[i].nodes[j + 1]];

                        n1.AddAdj(r[i].nodes[j + 1], i);
                        n2.AddAdj(r[i].nodes[j], i);


                        try
                        {
                            Console.WriteLine("node{0}.routes.Add({1})", n1.n, r[i]);
                            n1.routes.Add(r[i]);
                            n1.routesValues.Add(r[i], int.MaxValue/2);

                        }

                        catch (Exception ex) { Console.WriteLine(ex.Message); }

                        try {
                            Console.WriteLine("node{0}.routes.Add({1})", n2.n, r[i]);
                            n2.routes.Add(r[i]);
                            n2.routesValues.Add(r[i], int.MaxValue/2);
                        }



                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        /*
                        if (j == r[i].Length - 2)
                        {
                            for (int h = 0; h < r.Length; h++)
                            {
                                for (int g = 0; g < r[h].nodes.Length - 1; g++)
                                {

                                    if (r[h].nodes[g] == r[i].nodes[j])
                                    {
                                        nodes[r[h].nodes[g + 1]].routesValues.Add(GetRoute(h), int.MaxValue / 2);
                                    }
                                }
                            }
                            //r[i].nodes[j]
                        }*/

                        
                    }
                    try
                    {
                        for (int h = 0; h < r.Length; h++)
                        {
                            for (int g = 0; g < r[h].nodes.Length - 1; g++)
                            {

                                if (r[h].nodes[g] == r[i].nodes[r[i].Length - 1])
                                {
                                    nodes[r[h].nodes[g + 1]].routesValues.Add(GetRoute(i), int.MaxValue / 2);
                                }
                            }
                        }
                    }
                    catch { }

                 

                    nodes[r[i].nodes[0]].routesValues[r[i]] = 0;

                }
                
        }

        public int ShortestRoute(int s,int f, out string p){
            
                pq = new PriorityQueue<int,Node>();

                Node cn = this.GetNode(s);
                cn.Visit();
                foreach (AdjNode an in cn.neighbors)
                {
                    try
                    {
                        cn.d.Add("n" + cn.n + "r" + an.route, 0);
                    }
                    catch { }
                }
                
                cn.len = 0;
            
                pq.Enqueue(0, cn);

                while (pq.Count > 0)
                {
                    //Console.ReadKey();
                    cn = pq.Dequeue().Value;
                    //LookAroundNode(cn);
                    LookAt(cn);
                    
                }
                // восстанавливаем путь по меткам

                string path = "";
                Node start = GetNode(s);

                Node current = GetNode(f);
                Console.WriteLine(current.Info);
                Node prev = null;

                #region old
                /*
                while (current != start)
                {

                    
                    if (prev !=null && current.route.n != prev.r )
                    {
                        path = "до "+current.n +" \n пересесть на маршрут " + prev.r.ToString() + " "+ path;
                    }

                    //path = "по (" + current.r + ")" + " в " + current.n + path + "\n";

                    //path = ", ехать в " + current.n +" "+ path;

                    nodestomove.Enqueue(current);

                    prev = current;
                    if (current.route.n !=-1)
                    
                    if (((" "+routes[current.route.n].rs+" ").IndexOf(" " + current.n.ToString() + " ")) > (((" "+current.route.rs+" ").IndexOf(" " +GetNode(current.prevn).n.ToString() + " "))))
                    {
                        
                        current = current.Neighbor(current.route.n, -1);
                        
                    }
                    else current = current.Neighbor(current.r, 1);



                }
                 */ 
                
                #endregion

                //path = "Инструкция: на " + prev.r + " маршруте " + path+" до "+f;
                //nodestomove.Enqueue(start);
                
                Node finish = GetNode(f);
                //p = GetNode(f).d.Keys

                    var items = from item in finish.d
                                        orderby item.Value ascending
                                        select item.Key;

                    path = items.ToArray().First();
                    p = path;


                return finish.d.Values.Min();
			
		}
		
        /// <summary>
        /// Обработка узла. Смотрит соседние и, если нужно производит релаксацию
        /// </summary>
        /// <param name="s"></param>
		public void LookAroundNode(Node s){
            try
            {
#if DEBUG
                Console.WriteLine(s);
#endif
                Node cn = s;
                cn.Visit();
                foreach (AdjNode an in cn.neighbors)
                {
                    if (!an.node.Visited) //|| cn.routesValues.Count>an.node.routesValues.Count)
                    {
                        int w;


                        Route r = GetRoute(an.route);

                        //string s = "";
                        //s+=cn.d

                        an.node.RouteVisit(r);
                        Node nn = an.node;

                        int pr;
                        int c = 0;
                        if (cn.routesValues[r] == 0)
                        {
                            // в маршруте это первый узел
                            var items = from item in cn.routesValues
                                        orderby item.Value ascending
                                        select item.Value;
                            if (items.ToArray().Count() > 1)
                            {
                                pr = (int)items.ToArray().GetValue(1) + 4;
                                nn.routesValues[r] = pr;
                                c = 0;
                            }
                            else
                            {
                                pr = (int)items.ToArray().GetValue(0) + 1;
                                nn.routesValues[r] = pr;
                                c = 1;
                            }

                        }

                        else
                        {
                            if (cn.route != r)
                            {
                                
                                var items = from item in cn.routesValues
                                            orderby item.Value ascending
                                            select item.Value;
                                pr = (int)items.ToArray().GetValue(0) + 4;
                                nn.routesValues[r] = pr;
                                c = 2;
                            }
                            else
                            {
                                nn.routesValues[r] = cn.routesValues[r] + 1;
                                pr = cn.routesValues[r] + 1;
                                c = 3;
                            }
                        }

                        //an.node.route = r;
                        //if 
                        pq.Enqueue(pr, an.node);

                        //an.node.NewRouteValue(

                        #region OLD
                        /*
                        if (an.route == cn.r || cn.r == -1) w = 1; else w = 4;
                        
                        if (cn.route == GetRoute(an.route)){
                            if (an.node.NewRouteValue(GetRoute(an.route), cn.routesValues[cn.route] + 1)) { Console.WriteLine("Новая пара ключ-значение"); }
                            pq.Add(new KeyValuePair<int,Node>(cn.routesValues[cn.route] + 1, an.node));
                        }
                        else {
                            Console.WriteLine("C таким ключом уже есть");
                            an.node.NewRouteValue(GetRoute(an.route),cn.routesValues[cn.route]+4);
                            pq.Add(new KeyValuePair<int,Node>(cn.routesValues[cn.route] + 4, an.node));

                        }

                        
                     

                        foreach (Route r in an.node.routesValues.Keys)
                        {
                            Console.WriteLine("{0} - {1}", r.n, an.node.routesValues[r]);
                        }
                    
                        //Route[] array = new Route[an.node.routesValues.Keys.Count];
                        //an.node.routesValues.Keys.CopyTo(array,0);
                        //Console.WriteLine(array.ToString());
                        //Console.WriteLine(an.node.routesValues.Values.ToString());

                        /*
                        try
                        {
                            if (cn.len + w < an.node.len)
                            {
                                //an.node.routesValues[Route(cn.r)] = cn.len + w;

                                //Console.WriteLine(an.node.routesValues);
                                // релаксация нашли более короткий путь
                                Console.WriteLine("Релаксация в {0} было {1}, стало {2}", an, an.node.len, cn.len + w);
                                an.node.len = cn.len + w;
                                an.node.r = an.route;
                                an.node.prevn = s.n;
                                an.node.prev = s;
                            }
                        }
                        catch (Exception ee)
                        {
                            Console.WriteLine(ee.Message);
                        }*/


                        #endregion OLD
                    }
                }

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
		}


        public void LookAt(Node n)
        {
            n.Visit();
            foreach (string s in n.d.Keys)
            {
#if DEBUG
                Console.WriteLine("s = \"{0}\"", s);
#endif
                

                string last = "";
                string prelast = "";
                int ln = 0, lr = -1, pln = -2, plr = -2;
                
                try
                {
                    last = s.Split(' ')[s.Split(' ').Length - 1];
                    prelast = s.Split(' ')[s.Split(' ').Length - 2];
                
                    ln = int.Parse(regex.Match(last).Groups[1].Value);
                    lr = int.Parse(regex.Match(last).Groups[2].Value);

                    pln = int.Parse(regex.Match(prelast).Groups[1].Value);
                    plr = int.Parse(regex.Match(prelast).Groups[2].Value);

                }
                catch { }
#if DEBUG
                Console.WriteLine("ln = {0} lr = {1} pln = {2} plr = {3}", ln,lr,pln,plr);
#endif

                    foreach (AdjNode an in n.neighbors)
                    {
#if DEBUG
                        Console.WriteLine(an.ToString());
#endif

                        if (!an.node.Visited && (an.node.n != pln))
                        {
                            try
                            {
                                int p;
                                if (an.route == lr || lr == -1)
                                {
                                    Console.WriteLine("+1");
                                    //Console.WriteLine("an.node.d.Add({0}, {1});", n.d[s] + " n" + an.node.n + "r" + an.route, n.d[s] + 1);
                                    an.node.d.Add(s + " n" + an.node.n + "r" + an.route, n.d[s] + 1);
                                    p = n.d[s] + 1;
                                }

                                else
                                {
                                    Console.WriteLine("+4");
                                    //Console.WriteLine("an.node.d.Add({0}, {1});", n.d[s] + " n" + an.node.n + "r" + an.route, n.d[s] + 4);
                                    an.node.d.Add(s + " n" + an.node.n + "r" + an.route, n.d[s] + 4);
                                    p = n.d[s] + 4;
                                }


                                pq.Enqueue(p, an.node);

                            }

                            catch { }
                            
                        }
                }
                
                
            }
        }
		
		public void Print(){
			foreach (Node n in nodes) {
				Console.WriteLine(n.n);
				foreach (AdjNode nn in n.neighbors){
					Console.WriteLine("\t"+nn.node.n+" ["+nn.route+"]");
				}
				Console.WriteLine();
			}
		}

        public string Info 
        {
            get
            {
                string s = "";
                foreach (Node n in nodes)
                {
                    s += n.Info+"\n";
                }
                return s;
            }
        }
		
		
	}
}
