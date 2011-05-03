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
    public partial class ColorTest : Form
    {
        public ColorTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);
            int nn = n * n;
            double h = double.Parse(textBox2.Text);
            double s = double.Parse(textBox3.Text);
            double v = double.Parse(textBox4.Text);
            int w1 = this.Width / n;
            int h1 = this.Height / n;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Color c = new Color();

                    c = Route.RandomColorHSV(h, s, v);
                    Brush b = new SolidBrush(c);

                    tabPage1.CreateGraphics().FillRectangle(b,i * w1, j * h1, w1, h1);
                }
            }

            //tabControl1.Hide();
        }
    }
}
