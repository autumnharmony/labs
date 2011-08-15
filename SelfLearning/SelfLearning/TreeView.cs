using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SelfLearning
{
    //public delegate void TreeViewEvent(object sender, EventArgs e);

    public partial class TreeView : UserControl
    {
        BinaryTree tree;

        public int H = 0;
        public int W = 0;

        public int H1 = 30;



        public TreeView()
        {
            InitializeComponent();
        }


        public TreeView(BinaryTree tree)
        {
            this.tree = tree;


            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //

            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            //Walk(this.tree.Root,1,1);
            //Left = 5;
            //Top = 10;
            //Width = 200;
        }

        public BinaryTree Tree
        {
            set
            {
                tree = value;
            }
            get
            {
                return tree;
            }
        }


        public void Clear()
        {
            Controls.Clear();
            foreach (Control c in Controls)
            {
                Controls.Remove(c);

            }
            this.Update();
        }

        int dx = 0;

        //int deeplevel;

        //bool needtoresize;

        public void Walk(Node node, int x, int y, int lev)
        {
            
            if (node != null)
            {
                Panel p = new Panel();
                

                p.AutoSize = true;
                Label l = new Label();
                int W1 = (int)Math.Round(Width / Math.Pow(2, y - 1));
                int X = (x - 1) * W1;
                int Y = (y - 1) * H1;
                if (node == tree.Current)
                {
                    l.BackColor = Color.Red;
                }
                if (node == tree.Prev)
                {
                    l.BackColor = Color.Green;
                }
                l.Text = node.Question.ToString();//+" "+X+","+Y+"\n"+W1;
                l.AutoSize = true;
                l.Left += W1 / 2;
                l.Top += H1 / 2;

                /*
                if (lev == deeplevel)
                {
                    if (Math.Abs(l.Left - dx) < 2)
                    {
                        needtoresize = true;
                        MessageBox.Show("needtoresize");
                        //NeedToEnlarge(this, new EventArgs());

                    }
                }
                else
                {
                    dx = l.Left + l.Width ;
                }
                 */ 
                 

                //deeplevel = Math.Max(deeplevel, lev);

                l.TextAlign = ContentAlignment.MiddleCenter;
                l.BorderStyle = BorderStyle.FixedSingle;
                p.Controls.Add(l);
                p.SetBounds(X, Y, W1, H1);

                this.Controls.Add(p);

                Walk(node.Left, x * 2 - 1, y + 1,lev+1);
                Walk(node.Right, x * 2, y + 1,lev+1);
            }
        }


        public void Redraw()
        {
            if (tree != null)
            {
                Controls.Clear();
                //if (needtoresize)
                //{
                //    Enlarge();
                //}
                Walk(tree.Root, 1, 1, 0);
            }
        }

        private void TreeView_Load(object sender, EventArgs e)
        {

        }

        //public event TreeViewEvent Changed;

        /*
        protected virtual void OnSizeChanged(EventArgs e)
        {
            SizeChanged(this, e);
        }
         */ 

        public void Enlarge()
        {
            this.Width += 20;
            this.Height += 10;
            //Redraw();
            //needtoresize = false;
            //SizeChanged(this,new EventArgs());
        }

        private void TreeView_SizeChanged(object sender, EventArgs e)
        {
            Redraw();
        }

        
    }

}