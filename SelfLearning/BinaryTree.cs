using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace SelfLearning
{

    //public delegate void TreeEvent(object sender, EventArgs e);

    [Serializable]
    public class BinaryTree
    {     
        Node root;
        Node current;
        Node prev;

        TreeView tv;

        public TreeView TV
        {
            get
            {
                return tv;
            }
            set
            {
                tv = value;
            }
        }

        public Node Root
        {
            get { return root; }
        }

        public Node Current {
            get
            {
                return current;
            }
            set
            {
                
                if (value != null) { current = value; }
                tv.Redraw();
                
            }
        }

        public Node Prev {
            get {
                return prev;
            }
            set {
                
                prev = value;
                tv.Redraw();
            }
        }

        
        bool laststep; // true = налево false = направо

        public string Status
        {
            get { if (Current != null && Prev !=null) return "Current:" + Current.ToString() + " Previous:" + Prev.ToString() + " Последний ответ" + laststep.ToString(); else return "0"; }
        }

        public BinaryTree(Node r)
        {
            root = r;
            current = r;
        }

        public void AddQA(Node n, string q,string a,bool left){

            Console.WriteLine(left);
            Node qn = new Node(q);
            

                qn.Parent = n.Parent;
                qn.Right = n;
                Node an = new Node(a);
                an.Parent = qn;
                qn.Left = an;

                if (left)
                    n.Parent.Left = qn;
                else
                    n.Parent.Right = qn;
                n.Parent = qn;

            
            

            tv.Redraw();
        }

        public void Yes()
        {
            laststep = true; 
            
            
            if (Current.isLeaf) { MessageBox.Show("Программа отгадала, так-то!"); }
            else if (!Completed)
            {

                Current.answer = 1;
                Prev = Current;
                Current = Current.Left;
            }
            //TreeChanged(this,new EventArgs());
            tv.Redraw();
        }

        public void No()
        {
            if (Current.isLeaf) {
                MessageBox.Show("Программа не знает, помоги ей стать умнее, поделись своей информацией");

                AddForm af = new AddForm();
                af.ShowDialog();
                if (af.DialogResult == DialogResult.OK)
                {

                    AddQA(Current, af.qq, af.aa, laststep);
                    Current = Root;
                    
                }
            } else if (!Completed) {

                Current.answer = -1;
                
                Prev = Current;
                Current = Current.Right;
                laststep = false;
            }
            
            //TreeChanged(this,new EventArgs());
            tv.Redraw();
        }

        public string Q
        {
            get { return Current.Question; }
        }

        public bool Completed
        {
        	get { return (Current == null); }
        }


        //public event TreeEvent TreeChanged;

 

        public void Anew()
        {
            Current = Root;
            Prev = null;
            //TreeChanged(this, new EventArgs());
            tv.Redraw();
        }

        public void Redraw()
        {
        //   
        }

        public void Up()
        {
            if (Prev != null && Prev.Parent != null)
            {
                Prev = Prev.Parent;
                Current = Current.Parent;
                //TreeChanged(this, new EventArgs());
                tv.Redraw();
            }
            
        }
    }
}
