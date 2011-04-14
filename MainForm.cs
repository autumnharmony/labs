
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
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//

            Status.Routes = rs;
            Status.Points = points;

			InitializeComponent();
            this.Resize += new EventHandler(MainForm_Resize);
			//g = panel1.CreateGraphics();
			ArrayList pal = new ArrayList();
            points.Capacity = 30;
            Status.tp = toolsPanel2;
            Status.graphcreator = graphCreator1;
            Status.crs = crs;
            //label1.DataBindings.Add(new Binding("Text",graphCreator1, "crs"));
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

        void MainForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
		
		void MainFormLoad(object sender, EventArgs e)
		{
            toolsPanel2.graphcreator = graphCreator1;
            Settings1 set = new Settings1();
            //set.AdditionalEdgeEllipsis 
            graphCreator1.DrawPoint(new Point(100, 100, 1));
            graphCreator1.MyEvent += new MyEventHandler(graphCreator1_MyEvent);
		}

        void graphCreator1_MyEvent(object sender, MyEventArgs e)
        {
            label1.Text = String.Format("{0},{1}", e.X, e.Y);
        }
		
		void Button1Click(object sender, EventArgs e)
		{
			mode = Misc.Mode.Point;
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			mode = Misc.Mode.Line;
		}
		
		
		
		
		

		
		void Button4Click(object sender, EventArgs e)
		{
			rs.Add(crs);
			crs = "";
			
		}
		
		void Panel1Paint(object sender, PaintEventArgs e)
		{
			
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			g.Clear(Color.White);
			//DrawAll(points,new ArrayList(),panel1);
		}

        private void graphViewer1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Status.ElEd = ((CheckBox)sender).Checked;
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            //graphCreator1.Redraw(true);
            this.Refresh();
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
            graphCreator1.Redraw(true);
            toolsPanel2.RefreshRoutesAndPoints();
        }

        private void toolsPanel2_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Need to save data");
            SaveLoad.Save();
        }

           
        
	}
}
