
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
			//g = panel1.CreateGraphics();
			ArrayList pal = new ArrayList();
            points.Capacity = 30;
            Status.tp = toolsPanel1;
            Status.graphcreator = graphCreator1;
            Status.crs = crs;
            //label1.DataBindings.Add(new Binding("Text",graphCreator1, "crs"));
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			
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
	}
}
