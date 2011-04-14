using System;
using System.Diagnostics;
using System.Collections;

namespace GBusManager
{
	/// <summary>
	/// Граф, с заданными узлами, маршрутами, нужен только для вычисления кратчайшего пути
	/// </summary>
	public class Graph
	{
		
		public Node[] nodes;
		//Edge[] edges;
		
		public Route[] routes;
		Node current;
		int route;
        
        // для восстановления пути 
        public Queue nodestomove = new Queue();
		
		

		/// <summary>
		/// Возвращает узел по номеру
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		public Node Node(int i){
			if (i>=0 && i<nodes.Length) return nodes[i];
			return new Node();
		}
			
		
		public Graph(ArrayList points, Route[] r)
		{
            try
            {
                int n = points.Count;
                nodes = new Node[n];
                for (int i = 0; i < n; i++)
                    nodes[i] = new Node(this, i,(Point)points[i]);

                for (int i = 0; i < r.Length; i++)
                {

                    for (int j = 0; j < r[i].Length - 1; j++)
                    {
                        nodes[r[i].nodes[j]].AddAdj(r[i].nodes[j + 1], i);
                        nodes[r[i].nodes[j + 1]].AddAdj(r[i].nodes[j], i);
                    }

                }

                routes = r;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #region OLD
        /*
        // должна была быть весовая матрица в виде функции
		public int W(int i, int j) {
            
			throw new NotImplementedException();
			//if (Node(i).r =
		}

        
        public int[] G(int i){
            AdjNode[] adjnodes = (AdjNode[])nodes[i].neighbors.ToArray(typeof(AdjNode));
            foreach (AdjNode an in adjnodes)
            {
            }


        }*/
        #endregion

        public int ShortestRoute(int s,int f, out string p){
            try
            {
                Queue q = new Queue();

                Node cn;
                q.Enqueue(this.Node(s));
                this.Node(s).len = 0;

                while (q.Count > 0)
                {
                    //Console.WriteLine(q.Peek());
                    cn = (Node)q.Dequeue();
                    foreach (AdjNode an in cn.neighbors)
                    {
                        if (!an.node.v) q.Enqueue(an.node);
                    }
                    LookAroundNode(cn);
                    cn.v = true;
                    //q.Dequeue(cn);
                }

                // восстанавливаем путь по меткам

                string path = "";
                Node start = Node(s);

                Node current = Node(f);
                Node prev = null;

                #region old

                while (current != start)
                {

                    
                    if (prev !=null && current.r != prev.r )
                    {
                        path = "\n пересесть на маршрут " + prev.r.ToString() + " "+ path;
                    }

                    //path = "по (" + current.r + ")" + " в " + current.n + path + "\n";

                    path = ", ехать в " + current.n +" "+ path;

                    nodestomove.Enqueue(current);

                    prev = current;

                    if (((" "+routes[current.r].rs+" ").IndexOf(" " + current.n.ToString() + " ")) > (((" "+routes[current.r].rs+" ").IndexOf(" " +Node(current.prevn).n.ToString() + " "))))
                    {
                        
                        current = current.Neighbor(current.r, -1);
                        
                    }
                    else current = current.Neighbor(current.r, 1);



                }

                #endregion

                path = "Инструкция: на " + prev.r + " маршруте " + path;
                nodestomove.Enqueue(start);
                
                p = path;

                return Node(f).len;

            }
            catch (Exception e) { Console.WriteLine(e.Message); p = "omg!"; return -99; }
			
			#region old 
			/*
			int[] d 	= 	new int[nodes.Length];
			string[] p 	= 	new string[nodes.Length];
			
			int vc = 0; // счетчик посещенных вершин
			
			d[s] = 0;
			p[s]+=s;
			vc++;
			
			int cn = s; // текущий узел
			int cr = 0;	// текущий маршрут
			
			for (int i=0; i< nodes.Length; i++) {
				if (i!=s){
					d[i] = int.MaxValue;
				}
			}
			// пока есть непосещенные узлы
			while (vc < nodes.Length){
				// ищем соседний с наименьшим ребром
				int min = int.MaxValue;
				int minn = 0;
				int i;
				for (i=0; i<nodes[cn].edges.Length; i++){
				
					if (d[cn]+nodes[cn].edges[i].Length(cr) < d[nodes[cn].edges[i].nTo.n])
					
				}
				// нашли минимальное ребро
				
				if (d[nodes[cn].edges[i].nTo] > min)
				cr = nodes[cn].edges[i].r;
				cn = nodes[cn].edges[i].nTo;
				
				vc++;
				
				
			}
			*/
			#endregion
			
			
		}
		
        /// <summary>
        /// Обработка узла. Смотрит соседние и, если нужно производит релаксацию
        /// </summary>
        /// <param name="s"></param>
		public void LookAroundNode(Node s){
            try
            {
                Node cn = s;
                foreach (AdjNode an in cn.neighbors)
                {
                    int w;
                    //int r;
                    if (an.route == cn.r || cn.r == -1) w = 1; else w = 4;
                    try
                    {
                        if (cn.len + w < an.node.len)
                        {
                            // релаксация нашли более короткий путь
                            Console.WriteLine("Релаксация");
                            an.node.len = cn.len + w;
                            an.node.r = an.route;
                            an.node.prevn = s.n;
                            an.node.prev = s;
                        }
                    }
                    catch(Exception ee) {
                        Console.WriteLine(ee.Message);
                    }
                    
                }

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
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
		
		
	}
}
