
using System;
using System.Windows.Forms;

namespace GBusManager
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            
            //SaveLoad.Load();
            

			Application.Run(new Start());

            if (!Status.newset) { SaveLoad.Load(); }
            Application.Run(new MainForm());
            
		}
		
	}
}
