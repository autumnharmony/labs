using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SelfLearning
{

    public delegate void TreeEvent(object sender, EventArgs e);

    public class BinaryTree
    {     
        Node root;
        Node current;
        Node prev;

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
                TreeChanged(this, new EventArgs());
                if (value != null) { current = value; }
                
            }
        }

        public Node Prev {
            get {
                return prev;
            }
            set {
                TreeChanged(this,new EventArgs());
                prev = value;
             
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

        public void Add(Node n, string q,string a,bool left){
            Console.WriteLine(left);
            Node nn = new Node(q);
            nn.Right = n;

            Node an = new Node(a);
            an.Parent = nn;
            nn.Left = an;
            nn.Parent = n.Parent;
            
            if (left) 
                n.Parent.Left = nn; 
            else 
                n.Parent.Right = nn;
            n.Parent = nn;
            TreeChanged(this,new EventArgs());
            //prev = nn;
            //current = an;
            //return nn.Left;

            
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
            TreeChanged(this,new EventArgs());
        }

        public void No()
        {
            if (Current.isLeaf) {
                MessageBox.Show("Программа не знает, помоги ей стать умнее, поделись своей информацией");

                AddForm af = new AddForm();
                af.ShowDialog();
                if (af.DialogResult == DialogResult.OK)
                {

                    Add(Current, af.qq, af.aa, laststep);
                    Current = Root;
                    OnTreeChanged(new EventArgs());
                }
            } else if (!Completed) {

                Current.answer = -1;
                
                Prev = Current;
                Current = Current.Right;
                laststep = false;
            }
            
            TreeChanged(this,new EventArgs());
        }

        public string Q
        {
            get { return Current.Question; }
        }

        public bool Completed
        {
        	get { return (Current == null); }
        }


        public event TreeEvent TreeChanged;

        protected virtual void OnTreeChanged(EventArgs e)
        {
            TreeChanged(this, e);  
        }

        public void Anew()
        {
            Current = Root;
            Prev = null;
            //TreeChanged(this, new EventArgs());
        }

        public void Redraw()
        {
        //   
        }

        public void Up()
        {
            Prev = Prev.Parent;
            Current = Current.Parent;
            TreeChanged(this, new EventArgs());
            
        }
    }
}
