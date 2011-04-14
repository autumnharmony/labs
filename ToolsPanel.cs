using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace GBusManager
{
    public partial class ToolsPanel : UserControl
    {

        public ArrayList routes;// = Status.Routes;
        ArrayList points;
        //BindingSource bind = new BindingSource();
        public GraphCreator graphcreator;

        public ToolsPanel()
        {
            //graphcreator = g;
            routes = Status.Routes;
            points = Status.Points;

            InitializeComponent();
           
            routesListBox.DataSource = routes;
            BindingContext bc1 = new BindingContext();
            BindingContext bc2 = new BindingContext();

            srcPoint.BindingContext = bc1;
            srcPoint.DataSource = points;

            destPoint.BindingContext = bc2;
            destPoint.DataSource = points;
            
            srcPoint.DisplayMember = "N";
            destPoint.DisplayMember = "N";
       
        }

        private void pointBtn_Click(object sender, EventArgs e)
        {
            //gc.SetMode(Misc.Mode.Point);
            Status.mode = Misc.Mode.Point;
            
            
        }



        private void button2_Click(object sender, EventArgs e)
        {
            //gc.SetMode(Misc.Mode.Select);
            Status.mode = Misc.Mode.Select;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Status.mode != Misc.Mode.Line)
            {
                Status.mode = Misc.Mode.Line;
                lineBtn.Image = Resource1.cross;
                
            }
            else
            {
                endRoute_Click(sender, e);
                lineBtn.Image = Resource1.layer_shape_polyline;
                Status.mode = Misc.Mode.Select;
            }
            
            //button3.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
      
        }

        public void RefreshRoutesAndPoints()
        {

            ListBox.SelectedIndexCollection selected = this.routesListBox.SelectedIndices;

            this.BindingContext[routes].SuspendBinding();
            this.BindingContext[routes].ResumeBinding();

            this.BindingContext[points].SuspendBinding();
            this.BindingContext[points].ResumeBinding();

            srcPoint.BindingContext[points].SuspendBinding();
            srcPoint.BindingContext[points].ResumeBinding();

            destPoint.BindingContext[points].SuspendBinding();
            destPoint.BindingContext[points].ResumeBinding();

            for (int i = 0; i < routesListBox.Items.Count;i++ )
            {
                routesListBox.SetSelected(i, true);
            }

            
       }

        private void ToolsPanel_Load(object sender, EventArgs e)
        {
            #if DEBUG
            removeRouteBtn.Show();
            selectAllRoutesBtn.Show();
            #endif
        }

        private void routesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Status.graphcreator.activeroutes.Clear();

            ListBox.SelectedIndexCollection ic = routesListBox.SelectedIndices;
            Status.graphcreator.Redraw(true);
            //MessageBox.Show(n.ToString());
            if (ic.Count > 0)
                foreach (int i in ic)
                {
                    if (i != -1) Status.graphcreator.DrawRoute((Route)routes[i],false);
                    Status.graphcreator.activeroutes.Add((Route)routes[i]);
                }
        }

        private void routesListBox_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void srcPoint_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void destPoint_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void resultBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Array a = routes.ToArray(typeof(Route));
                graphcreator.tempdiredges.Clear();
                Graph g = new Graph(points, a as Route[]);
                string path;
                resultLbl.Text = g.ShortestRoute(srcPoint.SelectedIndex, destPoint.SelectedIndex, out path).ToString();
                    

                Node c1 = null;
                Node c2 = null;
                //graphcreator.CreateGraphics().Clear(Color.White);
                graphcreator.state = GraphCreator.GState.ResultPath;
                graphcreator.Redraw(true);
                graphcreator.DrawNodes(true);
                while (g.nodestomove.Count >1)
                {
                    /*
                    if (c != null)
                    {
                        graphcreator.DrawDirectEdge(c.point, ((Node)g.nodestomove.Peek()).point, ((Route)routes[((Node)g.nodestomove.Peek()).r]).color);
                    }
                    c = (Node)g.nodestomove.Dequeue();
                     */

                    c1 = (Node)g.nodestomove.Dequeue();
                    c2 = (Node)g.nodestomove.Peek();

                    graphcreator.DrawDirectEdge(c1.point, c2.point, ((Route)routes[c1.r]).color);
                    graphcreator.tempdiredges.Add(new Edge(c1.point, c2.point, c1.r, 0, ((Route)routes[c1.r]).color));
                }
                MessageBox.Show(path);
                
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + "+" + ex.StackTrace); }
        }

        private void endRoute_Click(object sender, EventArgs e)
        {
            try
            {
                Route r = new Route(graphcreator.crs);
                //routes.Add(r);
                Status.Routes.Add(r);
                if (Status.DEBUG) MessageBox.Show(graphcreator.crs);
                graphcreator.ResetRouteInfo();
                
                RefreshRoutesAndPoints();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public System.Windows.Forms.ListBox RoutesListBox{
            get
            {
                return routesListBox;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void selectAllRoutesBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < routesListBox.Items.Count; i++)
            {
                routesListBox.SetSelected(i, true);
            }

        }

        private void removeRouteBtn_Click(object sender, EventArgs e)
        {
            if (routesListBox.SelectedIndices.Count == 1){
                Status.Routes[routesListBox.SelectedIndices[0]] = new Route("");
            }
        }
      
    }
}
