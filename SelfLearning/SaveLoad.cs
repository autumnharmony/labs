using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;

namespace SelfLearning
{
    // Сохранение и загрузка данных дерева вопросов
    static class SaveLoad
    {

        public enum ChildFlags
        {
            None = 0x0,
            Left = 0x1,
            Right = 0x2,
            LeftRight = 0x3
        }

        static Node parent;

        static Stack<Node> stack = new Stack<Node>();

        public static void Save(BinaryTree tree)
        {
            string s = "";
            Walk(tree.Root,ref s);
            //Console.WriteLine

            StreamWriter sw = new StreamWriter("data",false);

            try
            {
                sw.Write(s);
                sw.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Что-то пошло не так, а именно:");
                Console.WriteLine(e.Message);
            }
            
           

        }

        static void Walk(Node node,ref string s)
        {
            //s = "";
            if (node != null)
            {
                ChildFlags cf = ChildFlags.None;
                if (node.Left != null) cf = cf | ChildFlags.Left;
                if (node.Right != null) cf = cf | ChildFlags.Right;

                
                s += node.Question + "\n";
                s +=(int)cf + "\n";

                Console.WriteLine(node.Question);
                Console.WriteLine(cf);
                


                Walk(node.Left, ref s);
                Walk(node.Right,ref s);
            }

        }

        public static BinaryTree Load()
        {
            BinaryTree bt = null;

            try
            {

                StreamReader sr = new StreamReader("data");

                string all = sr.ReadToEnd();

                Console.WriteLine(all);
                
                

                Node r = Parse( ref all);

                bt = new BinaryTree(r);

            }

            catch (Exception ex)
            {
                Console.WriteLine("Загрузка из файла не получилась, создаем дерево вручную из заготовки");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.StackTrace);
                
                #region Стандартное дерево
                Node 
                
                n1 = null,
                n2 = null,
                n3 = null,
                n4 = null,
                n5 = null,
                n6 = null,
                     
                n7 = null;

                
                n1 = new Node(null, null, n5, "GGG");
                n2 = new Node(null, null, n5, "FFF");
                n3 = new Node(null, null, n6, "EEE");
                n4 = new Node(null, null, n6, "DDD");
                n5 = new Node(n1, n2, n7, "CCC");
                n6 = new Node(n3, n4, n7, "BBB");
                 
                n7 = new Node(n6, n5, null, "AAA");

                n1.Parent = n5;
                n2.Parent = n5;
                n3.Parent = n6;
                n4.Parent = n6;
                n5.Parent = n7;
                n6.Parent = n7;
                
                bt = new BinaryTree(n7);
                #endregion
                 
            }
            return bt;

        }


        static Node Parse(ref string all)
        {
            Node qn = null;
            Console.WriteLine("|" + all + "|");
            if (all != "")
            {
                //Console.WriteLine(all);

                string s;
                string q, cs;


                q = all.Split('\n')[0];

                qn = new Node(q);
                

                cs = all.Split('\n')[1];

                all = all.Replace(q, "");
                all = all.Substring(1,all.Length-1);
                all = all.Substring(1,all.Length-1);
                all = all.Substring(1, all.Length-1);


                ChildFlags cf = (ChildFlags)int.Parse(cs);
                Console.WriteLine(cf);
                //qn.Parent = parent;
                if ((cf & ChildFlags.Left) == ChildFlags.Left)
                {
                    Console.Write("Left:");
                    qn.Left = Parse(ref all);
                    qn.Parent = stack.Peek();
                }
                
                
                if ((cf & ChildFlags.Right) == ChildFlags.Right)
                {
                    Console.Write("Right:");
                    qn.Right = Parse(ref all);
                    qn.Parent = stack.Peek();
                }

                if ((cf & ChildFlags.Right) == ChildFlags.None)
                {
                    if (stack.Count!=0) stack.Pop();
                }


                stack.Push(qn);
                
                
            }
            
            return qn;

        }
    }
}
