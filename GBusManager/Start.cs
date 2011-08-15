using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GBusManager
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Status.newset = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Status.newset = false;
            Close();
        }
    }
}
