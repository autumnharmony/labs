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

        ArrayList routes;// = Status.Routes;
        ArrayList points;
        //BindingSource bind = new BindingSource();
        GraphCreator graphcreator;

        public ToolsPanel(GraphCreator g)
        {
            graphcreator = g;
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
            //Misc.Mode prevmode = Status.
            Status.mode = Misc.Mode.Line;

            //button3.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //routes.
            //int n = comboBox1.SelectedIndex;
            //MessageBox.Show(n.ToString());
            //if (n!=-1)
            //Status.graphcreator.DrawRoute((Route)routes[n]);
        }

        public void RefreshRoutes()
        {
            this.BindingContext[routes].SuspendBinding();
            this.BindingContext[routes].ResumeBinding();

            this.BindingContext[points].SuspendBinding();
            this.BindingContext[points].ResumeBinding();

            srcPoint.BindingContext[points].SuspendBinding();
            srcPoint.BindingContext[points].ResumeBinding();

            destPoint.BindingContext[points].SuspendBinding();
            destPoint.BindingContext[points].ResumeBinding();

            //routesListBox.SelectedIndices.
            routesListBox.SelectedIndex = routesListBox.Items.Count-1;
       }

        private void ToolsPanel_Load(object sender, EventArgs e)
        {

        }

        private void routesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox.SelectedIndexCollection ic = routesListBox.SelectedIndices;
            Status.graphcreator.Redraw(true);
            //MessageBox.Show(n.ToString());
            if (ic.Count > 0)
                foreach (int i in ic)
                {
                    if (i != -1) Status.graphcreator.DrawRoute((Route)routes[i],false);
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
            Array a = routes.ToArray(typeof(Route));
            
            Graph g = new Graph(points.Count,a as Route[]);
            resultLbl.Text = g.ShortestRoute(srcPoint.SelectedIndex, destPoint.SelectedIndex).ToString();
        }

        private void endRoute_Click(object sender, EventArgs e)
        {
            routes.Add(new Route(graphcreator.crs));
            graphcreator.ResetRouteInfo();
            RefreshRoutes();
        }

      
    }
}
