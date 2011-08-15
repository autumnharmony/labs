using System;
using System.Drawing;
namespace GBusManager
{
	public partial class ColorTest : Gtk.Window
	{
		protected virtual void OnButton2Clicked (object sender, System.EventArgs e)
		{
			int n = (int)entry1.Text;
			nn = n*n;
			double h = (double)entry2.Text;
			double s = (double)entry3.Text;
			double v = (double)entry4.Text;
			int w = drawingarea2.WidthRequest / n;
			int h = drawingarea2.HeightRequest / n;
			
			for (int i=0; i<n; i++){
				for(int j=0 ; j<n; j++){
					Color c = new Color();
					
					c = Route.RandomColorHSV(h,s,v);
					drawingarea2.Draw(new Rectangle(i*w,j*h,w,h));
				}
			}
			
			notebook1.CurrentPage = 1;
			
			
		}
		
		
		public ColorTest () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

