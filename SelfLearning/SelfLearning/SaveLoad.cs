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

        static int cfn;

        static Node parent;

        static Stack<Node> stack = new Stack<Node>();
        static MyStack<Node> myStack = new MyStack<Node>();

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
                if (node.Left != null) { cf = cf | ChildFlags.Left; }

                //if (node.Left != null) cfn = 1;


                if (node.Right != null) cf = cf | ChildFlags.Right;

                //if (node.Right != null) cfn = 2;

                //if (node.Right != null && node.Left !=null) cfn = 3;



                
                s += node.Question + "\n";
                s +=(int)cf + "\n";
                //s += cfn + "\n";

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

                Console.WriteLine("Tree Info:");
                string s = "";
                bt.Info(bt.Root,ref s);
                Console.WriteLine(s);


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
            //Console.WriteLine(("|" + all + "|"));
            if (all != "")
            {

                string q, cs;

                // q - question
                // cs - child string


                q = all.Split('\n')[0];

                qn = new Node(q);

                if (myStack.Count == 0)
                {
                    qn.Parent = null;
                }
                else 
                qn.Parent = myStack.Pop();

                Console.WriteLine(q);
                cs = all.Split('\n')[1];


                all = all.Replace(q, "");
                all = all.Substring(1,all.Length-1);
                all = all.Substring(1,all.Length-1);

                all = all.Substring(1, all.Length-1);


                ChildFlags cf = (ChildFlags)int.Parse(cs);
                Console.WriteLine("\tcf = {0}",cf);
                //qn.Parent = parent;
                if ((cf & ChildFlags.Left) == ChildFlags.Left)
                {
                    //stack.Push(qn);
                    myStack.Push(qn);
                    
                    qn.Left = Parse(ref all);
                    Console.WriteLine("\tLeft {0}",qn.Left);
                    //Node t = myStack.Pop();
                    //qn.Parent = myStack.Pop();
                    //myStack.Push(t);
                    //stack.Pop();
                    //Console.WriteLine("\tParent {0}",qn.Parent);
                }
                
                
                if ((cf & ChildFlags.Right) == ChildFlags.Right)
                {
                    //stack.Push(qn);
                    myStack.Push(qn);

                    qn.Right = Parse(ref all);

                    Console.Write("\tRight {0}", qn.Right);

                    //Node t = myStack.Pop();
                    //qn.Parent = myStack.Pop();
                    //myStack.Push(t);
                    //stack.Pop();
                    //Console.Write("\tParent {0}", qn.Parent);
                }

                if ((cf) == ChildFlags.None)
                {
                    //if (myStack.Count!=0) myStack.Pop();
                }


                
                
                
            }
            
            return qn;

        }
    }
}
