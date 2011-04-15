
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
            Console.WriteLine("Trying to load previous session data");
            try
            {
                SaveLoad.Load();
            }
            catch (Exception e)
            {
                Console.WriteLine("Loading failed, reason: " + e.Message+" "+e.StackTrace);
            }

			//Application.Run(new MainForm());
			Application.Run(new ColorTest());
		}
		
	}
}
