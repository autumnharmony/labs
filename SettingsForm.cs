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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            //graphCreator1.DisableEdit();
        }

        private void pointSizeTrackBar_Scroll(object sender, EventArgs e)
        {
            //graphCreator1.Redraw(true);
            Console.WriteLine(pointSizeTrackBar.Value.ToString());
            //graphCreator1.DrawPoint(new Point(graphCreator1.Width/2,graphCreator1.Height/2,pointSizeTrackBar.Value,Color.Black));
            Settings1.Default.NodeSize = pointSizeTrackBar.Value;
            //Settings1.Default.BetweenEdgesK = 
            //graphCreator1.Redraw(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void graphViewer1_Load(object sender, EventArgs e)
        {
            //graphCreator1.DrawE
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            //graphCreator1 = new GraphViewer(
           
            try
            {
            	 throw new NotImplementedException();

                Point p1 = new Point(20, 20, Settings1.Default.NodeSize,0, Color.Black);
                Point p2 = new Point(40, 40, Settings1.Default.NodeSize,1, Color.Black);


                Route r1 = new Route(new int[] { 0, 1 });
                Route r2 = new Route(new int[] { 0, 1 });
                Route r3 = new Route(new int[] { 0, 1 });
                Graph g = new Graph(new System.Collections.ArrayList() { p1, p2 }, new Route[] { r1, r2, r3 });

                //graphCreator1 = new GraphViewer(g) as GraphCreator;
                //graphCreator1.points.Add(p1);
                //graphCreator1.points.Add(p2);

                /*graphCreator1.edges.Add(new Edge(p1, p2, 0, 0));
                graphCreator1.edges.Add(new Edge(p1, p2, 1, 1));
                graphCreator1.edges.Add(new Edge(p1, p2, 2, 2));
                 */
                

                //graphCreator1.r
                //graphCreator1.Redraw(true);
                //graphCreator1.DrawRoutes(new Route[] { r1, r2, r3 });
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void edgeKTrackBar_Scroll(object sender, EventArgs e)
        {
            Settings1.Default.BetweenEdgesK = edgeKTrackBar.Value;
            //graphCreator1.Redraw(true);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Settings1.Default.AdditionalEdgeEllipsis = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Settings1.Default.AdditionalEdgeEllipsis = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
