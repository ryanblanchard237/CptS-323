using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home_Visits_Vaccination
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//TalkToFirebase.FromMilestone4PDF().Wait();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//List<Appointment> appointmentList;
			Application.Run(new Form2());

			//Form2 f2 = new Form2();
			//
			//Application.Run(f2);
		}
	}
}
