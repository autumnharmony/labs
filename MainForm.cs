
using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;


namespace GBusManager
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Graphics g;
		
		public Misc.Mode mode;
		
		bool drawLine;
		int x1,y1;
		
		Point s,f;
		
		ArrayList rs = new ArrayList();
		public String crs = "";
		int pn = 0;
		int lpn = 0;
		
		//Point[] pa;
		
		
		
		public ArrayList points = new ArrayList(20);
        
		//points;
		
		public Point FindNear(int x, int y, int d){
			for (int i = 0; i<points.Count; i++ ){
				Point p = (Point)points[i];
				if (p.X >= x-d && p.X <= x+d && p.Y >= y-d && p.Y <= y+d ){
					return p;
				}
			}
			return null;
		}
		
		
		public MainForm()
		{
		    //Status.Routes = rs;
            //Status.Points = points;

			InitializeComponent();

			ArrayList pal = new ArrayList();
            points.Capacity = 30;
            
            Status.tp = toolsPanel2;
            Status.graphcreator = graphCreator1;
            Status.crs = crs;
            //graphCreator1.Enabled = false;
            
		
		}

        
		
		void MainFormLoad(object sender, EventArgs e)
		{
            toolsPanel2.graphcreator = graphCreator1;
            Settings1 set = new Settings1();
            //set.AdditionalEdgeEllipsis 
            //graphCreator1.DrawPoint(new Point(100, 100, 1));
            graphCreator1.MyEvent += new MyEventHandler(graphCreator1_MyEvent);
		}

        void graphCreator1_MyEvent(object sender, MyEventArgs e)
        {
            label1.Text = String.Format("{0},{1}", e.X, e.Y);
        }
		
		
		void Button4Click(object sender, EventArgs e)
		{
			rs.Add(crs);
			crs = "";
			
		}

		
		void Button5Click(object sender, EventArgs e)
		{
			g.Clear(Color.White);
		}

        private void graphViewer1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Status.ElEd = ((CheckBox)sender).Checked;
        }


        private void graphCreator1_Scroll(object sender, ScrollEventArgs e)
        {
            //toolsPanel2.RoutesListBox.SelectedIndex = toolsPanel2.RoutesListBox.SelectedIndex + e.
            MessageBox.Show((e.NewValue - e.OldValue).ToString());
        }

        void graphCreator1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                for (int i = 0; i < toolsPanel2.RoutesListBox.Items.Count; i++)
                {
                    
                    if (e.Delta < 0)
                        toolsPanel2.RoutesListBox.SelectedItems[i] = toolsPanel2.RoutesListBox.Items[toolsPanel2.RoutesListBox.SelectedItems.IndexOf(toolsPanel2.RoutesListBox.SelectedItems[i]) - 1];
                    else
                        toolsPanel2.RoutesListBox.SelectedItems[i] = toolsPanel2.RoutesListBox.Items[toolsPanel2.RoutesListBox.SelectedItems.IndexOf(toolsPanel2.RoutesListBox.SelectedItems[i]) + 1];
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void graphCreator1_Load(object sender, EventArgs e)
        {

        }

        private void graphCreator1_Paint(object sender, PaintEventArgs e)
        {
            //sender
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLoad.Save();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLoad.Load();
            //graphCreator1 = new GraphCreator();
            //graphCreator1.Invalidate();
            //graphCreator1;
            toolsPanel2.RefreshRoutesAndPoints();

            //Controls.Remove(graphCreator1);
            //graphCreator1 = new GraphCreator();
            //Controls.Add(graphCreator1);
            graphCreator1.points = Status.Points;
            Status.tp.routes = Status.Routes;
            //graphCreator1.Redraw(true);
        }

        private void toolsPanel2_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Need to save data");
            SaveLoad.Save();
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Status.Routes.Clear();
            Status.Points.Clear();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Status.Routes = new ArrayList();
            Status.Points = new ArrayList();
            graphCreator1.Enabled = true;
            
            graphCreator1.points = Status.Points;
            graphCreator1.Show();
            //graphCreator1
        }

           
        
	}
}
