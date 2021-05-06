using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

// Not good listener for it.
//

// FirebaseDatabase.net is what is used in the Milestone 2 PDF.

namespace Home_Visits_Vaccination
{
	public partial class 
		AddPatientForm : Form
	{
		IFirebaseClient client;

		public AddPatientForm(ref IFirebaseClient ifc)
		{
			InitializeComponent();

			this.client = ifc;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Patient p = new Patient();

			p.userName = textBox1.Text;
			p.FirstName = textBox2.Text;
			p.LastName = textBox3.Text;

			//p.Status; // This will need some finagling. //no associated textBox (uses a pair of RadioButtons).
			p.Status = this.stringFromStatusRadioButtons();

			p.Age = textBox4.Text;

			//p.pid; // Probably will also needs some finagling. //textBox5 // I think this is supposedd to be a unique object ID for this Patient.
			//p.pid = textBox5.Text.To;
			p.pid = Int32.Parse(textBox5.Text);

			//p.image = textBox6.Text;
			p.userCellphone = textBox7.Text;

			//   ->   It needs to be a variable that is declared in the Form class.
			//   |    (Or maybe it can be passed to the Form from somewhere else, which is
			//   |    what I think I might try to do.)
			//   |    I kinda thought maybe I remember somebody (Delatorre?) saying that
			//   |    you sort of only should have 1 of these in your whole application.)
			//   |
			//   |------------------------------------|
			//          this is an IFirebaseClient. --|
			//               v
			SetResponse sr = client.Set("Patients/" + p.pid, p);
		}

		private string stringFromStatusRadioButtons()
		{
			string result;

			if (this.radioButton1.Checked)
				result = "Has been vaccinated.";
			else
			if (this.radioButton2.Checked)
				result = "Has *not* been vaccinated.";
			else
				result = "Error: user needs to choose an option for has-been-vaccinated status.";

			return result;
		}
	}
}
