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
	public partial class ProspectListForm : Form
	{
		public ProspectListForm()
		{
			InitializeComponent();
		}

		IFirebaseConfig fconfig = new FirebaseConfig()
		{
			AuthSecret = "Bn3c3rsghHfoHX7PeZwmP5GGrDuywJCiUhQgQFTW",
			BasePath = "https://cpts323-kovidkillers-default-rtdb.firebaseio.com/"
		};

		IFirebaseClient client;

		private void ProspectListForm_Load(object sender, EventArgs e)
		{
			try
			{
				client = new FireSharp.FirebaseClient(fconfig);
			}
			catch
			{
				MessageBox.Show("There was a problem creating a FirebaseClient from the given FirebaseConfig.");
			}
		}

		private void buttonUpdateProspectList_Click(object sender, EventArgs e)
		{
			// FirebaseResponse r = client.Get("Prospects");
			//                          //.GetAsync() ?
			// 						 //     "cpts323-kovidkillers-default-rtdb"
			// // Using either "cpts323-kovidkillers-default-rtdb" or "Prospects",
			// // it doesn't like it.
			// //
			// // I keep getting a NullReferenceException...
			// // "Object reference not set to an instance of an object."


			// FirebaseResponse response = await client.GetAsync("something");
			// 
			// https://stackoverflow.com/q/51579134 , "How to return as objects from firebase using firesharp"


			// var response = client.Get("Prospects/");
			// // This should get me everything in the "Prospects" directory in the database.
			// 
			// // Try this for now to see what happens.
			// MessageBox.Show(r.Body);



			// Step 1. Figure out how we get all the prospects. Abd what kind of a data structure this is.

			var result = client.Get("Prospects");

			MessageBox.Show("Result of \"client.Get(\"Prospects\")\" as just a string...\n"
				            + 
				            result.Body);
		}
	}
}
