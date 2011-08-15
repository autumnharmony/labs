
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SelfLearning
{
	/// <summary>
	/// Description of AddForm.
	/// </summary>
	public partial class AddForm : Form
	{
		public String qq;
		public String aa;
		public AddForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			qq = textBox1.Text;
			aa = textBox2.Text;
			Close();
		}
		
		void AddFormLoad(object sender, EventArgs e)
		{
			
		}
	}
}
