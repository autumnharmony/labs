using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SelfLearning
{
    public partial class MainForm : Form
    {
        BinaryTree bt;

        public MainForm()
        {
            
            Node n1 = null, 
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
            n7 = new Node(n5,n6,null,"AAA");

            n1.Parent = n5;
            n2.Parent = n5;
            n3.Parent = n6;
            n4.Parent = n6;
            n5.Parent = n7;
            n6.Parent = n7;
            bt = new BinaryTree(n7);
            InitializeComponent();
            label1.DataBindings.Add(new Binding("Text", bt, "Status"));
            //label1.DataBindings.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //treeView1.NeedToEnlarge += new TreeViewEvent(treeView1_NeedToEnlarge);
            //Node j = new Node
        }

        void treeView1_NeedToEnlarge(object sender, EventArgs e)
        {
            MessageBox.Show("Нужно увеличить размер treeview");
        }

        private void questionBox1_Load(object sender, EventArgs e)
        {
            questionBox1.btree = bt;
            questionBox1.Next();
        }

        private void treeView1_Load(object sender, EventArgs e)
        {
            treeView1.Tree = bt;
            treeView1.Walk(bt.Root, 1, 1,0);
            bt.TreeChanged += new TreeEvent(bt_TreeChanged);
            //treeView1
        }

        void bt_TreeChanged(object sender, EventArgs e)
        {
            treeView1.Controls.Clear();
            treeView1.Walk(bt.Root,1,1,1) ;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bt.Anew();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            bt.Up();

        }

        
    }
}
