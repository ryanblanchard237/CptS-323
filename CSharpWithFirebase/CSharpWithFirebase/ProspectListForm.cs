using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using FireSharp.Config;
//using FireSharp.Interfaces;
//using FireSharp.Response;

//using Firebase.Database;

namespace CSharpWithFirebase
{
	public partial class ProspectListForm : Form
	{
		public ProspectListForm()
		{
			InitializeComponent();
		}

		private void buttonUpdateProspectList_Click(object sender, EventArgs e)
		{
			RefreshListFromDatabase();
			//
			// This gives me warning CS4014,
			// "Because this call is not awaited, execution of the current method continues
			//  before the call is completed.
			//  Consider applying the 'await' operator to the result of the call."
			//
			// This actually might be a desirable thing.
			//
			// Click the button, but the UI doesn't lock up. The list just fills when it fills
			// and the form keeps on running.
			//
			// See below, looks like I have to do it this way.


			//RefreshListFromDatabase().Wait();
			//
			// Other option.
			//
			// Tried it, this actually seems to not work.
			// Seems that the application just doesn't respond at all after clicking the button.
			// (Dont know if that's something related to how this works, or
			// if Firebase just was not responding.)
		}

		private async Task RefreshListFromDatabase()
		{
			// Get rid of the old info in the ListView.
			listView1.Clear();
			SetUpListView();
			// ListView.Clear() removes all the items from the ListView,
			// but it also removes the columns.
			// Therefore we have to set it up again.

			var client = new Firebase.Database.FirebaseClient("https://cpts323-kovidkillers-default-rtdb.firebaseio.com/");
			var timeslots = await client.Child("Prospects").OnceAsync<Prospect>();

			foreach (var slot in timeslots) {
				ListViewItem lvi = new ListViewItem(new string[] {slot.Object.Name, slot.Object.Address} );
				listView1.Items.Add(lvi);
			}
		}

		private void ProspectListForm_Load(object sender, EventArgs e)
		{
			SetUpListView();
		}

		private void SetUpListView()
		{
			listView1.View = View.Details;
			listView1.Columns.Add("Name", 150);
			listView1.Columns.Add("Address", 250);
		}
	}
}
