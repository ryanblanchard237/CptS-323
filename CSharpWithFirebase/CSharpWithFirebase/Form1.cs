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

namespace CSharpWithFirebase
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		IFirebaseConfig fconfig = new FirebaseConfig()
		{
			AuthSecret = "Bn3c3rsghHfoHX7PeZwmP5GGrDuywJCiUhQgQFTW",
			
			BasePath = "https://cpts323-kovidkillers-default-rtdb.firebaseio.com/"
			// Root-endpoint? In terms of a REST API.
			// (Note group 1 in my notes. Ripped out of notebook.)
		};

		IFirebaseClient client;

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				client = new FireSharp.FirebaseClient(fconfig);
			}
			catch
			{
				MessageBox.Show("There was a problem creating a FirebaseClient from the partuclar FirebaseConfig. (There could be a problem with interenret accces.)");
			}
		}

		private void buttonInsert_Click(object sender, EventArgs e)
		{
			Student s = new Student()
			{
				Name = textBoxStudentName.Text,
				RollNo = textBoxStudentRollNo.Text,
				Grade = textBoxStudentGrade.Text,
				Section = textBoxStudentSection.Text
			};

			SetResponse sr = client.Set("StudentList/" + textBoxStudentRollNo.Text, s);

			MessageBox.Show("SetResponse from database:\n" + sr.Body);
			
			//sr.Body;

			//client.Se

			// Get/Post/Patch(Put)/Delete
			// 
			// Maybe "Set()" corresponds to Patch.
			// And maybe it also does double-duty for Post.

			// MessageBox.Show("Added the object to the database.");
			// In good program design, the user shouldn't really be notified
			// of success. (Successful operationn really shoud just be the standard
			// thign that hapens. the user really shoud only be notified when theres a problem).

		}

		private void buttonSet_Click(object sender, EventArgs e)
		{
			if (radioButton_WhichObject_KeyVal.Checked)
			{
				string key = keyTextBox.Text;
				string value = valueTextBox.Text;

				client.Set(key, value);
			} else
			if (radioButton_WhichObject_Prospect.Checked)
			{
				Prospect p = new Prospect();
				p.Accepted = false;
				p.Address = textBoxAddress.Text;
				p.Name = textBoxProspectName.Text;

				client.Set<Prospect>("Prospects/" + p.Name, p);
			} else
			if (radioButton_WhichObject_YouTut.Checked)
			{
				Student s = new Student();
				s.Grade = textBoxStudentGrade.Text;
				s.Name = textBoxStudentName.Text;
				s.RollNo = textBoxStudentRollNo.Text;
				s.Section = textBoxStudentSection.Text;

				client.Set<Student>("StudentList/" + s.RollNo, s);

			} else
			{
				MessageBox.Show("Choose an option for the type of information to upload/download.");
			}




			//string key = this.keyTextBox.Text;
			//string value = this.valueTextBox.Text;
			//
			//client.Set<string>(key, value);
		}

		private void buttonGet_Click(object sender, EventArgs e)
		{
			// FirebaseResponse response = client.Get("");
			// 
			// MessageBox.Show(response.Body);



			if (radioButton_WhichObject_KeyVal.Checked)
			{
				//string key = keyTextBox.Text;
				//string value = valueTextBox.Text;
				//
				//client.Set(key, value);
			}
			else
			if (radioButton_WhichObject_Prospect.Checked)
			{
				//Prospect p = new Prospect();
				//p.Accepted = false;
				//p.Address = textBoxAddress.Text;
				//p.Name = textBoxProspectName.Text;
				//
				//client.Set<Prospect>("Prospects/" + p.Name, p);
			}
			else
			if (radioButton_WhichObject_YouTut.Checked)
			{
				//Student s = new Student();
				//s.Grade = textBoxStudentGrade.Text;
				//s.Name = textBoxStudentName.Text;
				//s.RollNo = textBoxStudentRollNo.Text;
				//s.Section = textBoxStudentSection.Text;
				//
				//client.Set<Student>("StudentList/" + s.RollNo, s);

			}
			else
			{
				MessageBox.Show("Choose an option for the type of information to upload/download.");
			}
		}

		private void label5_Click(object sender, EventArgs e)
		{

		}
	}
}
