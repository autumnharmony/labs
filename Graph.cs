
using System;
using System.Diagnostics;
using System.Collections;

namespace GBusManager
{
	/// <summary>
	/// Description of Graph.
	/// </summary>
	public class Graph
	{
		
		public Node[] nodes;
		//Edge[] edges;
		
		public Route[] routes;
		Node current;
		int route;
		
		
		
		public Node Node(int i){
			//Console.WriteLine(i);
			if (i>=0 && i<nodes.Length) return nodes[i];
			return new Node();
			//throw new Exception("Не существует такого узла");
		}
			
		
		public Graph(int n, Route[] r)
		{
			nodes = new Node[n];
			for (int i = 0; i<n; i++)
				nodes[i] = new Node(this, i);
			
			for (int i = 0; i < r.Length; i++){
				
				for (int j = 0; j< r[i].Length-1; j++){
					nodes[r[i].nodes[j]].AddAdj(r[i].nodes[j+1], i);
					nodes[r[i].nodes[j+1]].AddAdj(r[i].nodes[j], i);
				}
					
			}
		}
		public int W(int i, int j) {
			throw new NotImplementedException();
			//if (Node(i).r =
		}
		
					
		public int ShortestRoute(int s,int f){

			//throw new NotImplementedException();

			Queue q = new Queue();
			
			Node cn;
			q.Enqueue(this.Node(s));
			this.Node(s).len = 0;
			
			while (q.Count>0) {
				Console.WriteLine(q.Peek());
				cn = (Node)q.Dequeue();
				foreach (AdjNode an in cn.neighbors){
					if (!an.node.v) q.Enqueue(an.node);
				}
				LookAroundNode(cn);
				cn.v = true;
				//q.Dequeue(cn);
			}

            return Node(f).len;
			
						
			
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
		
		public void LookAroundNode(Node s){
			Node cn = s;
			foreach(AdjNode an in cn.neighbors){
				int w;
				//int r;
				if (an.route == cn.r || cn.r == -1) w = 1; else w = 4;
				try {
					if (cn.len + w < an.node.len){
						Console.WriteLine("Релаксация");
						an.node.len = cn.len + w;
						an.node.r = an.route;
					}
				}
				catch {}
					// релаксация нашли более короткий путь
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
