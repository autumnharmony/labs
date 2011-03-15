using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SelfLearning
{
    public partial class QuestionBox : UserControl
    {
        public BinaryTree btree;

        public QuestionBox()
        {
            InitializeComponent();
        }

        public QuestionBox(BinaryTree bt)
        {
            InitializeComponent();
            btree = bt;
            questionLbl.Text = btree.Q;
        }

       

        private void QuestionBox_Load(object sender, EventArgs e)
        {

        }

        private void yesBtn_Click(object sender, EventArgs e)
        {
            btree.Yes();
            Next();
        }

        private void noBtn_Click(object sender, EventArgs e)
        {
            btree.No();
            Next();
        }

        public void Next()
        {
            if (btree.Completed)
            {
                MessageBox.Show("Completed");
                //Next();
            }
            else
                questionLbl.Text = btree.Q;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
