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

namespace Home_Visits_Vaccination
{
	public partial class Main_Interface_Form_2 : Form
	{
		public Main_Interface_Form_2()
		{
			InitializeComponent();
		}

		GMap.NET.GDirections gDirections1;

		private void gMapControl1_Load(object sender, EventArgs e)
		{
			// Good tutorial:
			// http://www.independent-software.com/gmap-net-beginners-tutorial-maps-markers-polygons-routes-updated-for-vs2015-and-gmap1-7.html

			gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;   //.BingMapProvider.Instance;
			//gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMap;
			//GMap.NET.MapProviders.GoogleMapProvider.

			//gMapControl1.MapProvider = GMapProviders.GoogleMap;
			//GMap.NET.MapProviders.GoogleMap.ApiKey = "<some key>";
			// The API key in Delatorre's code is "AIzaSyD_EgYiqKMGksVC9LqJeRqx5WqRByy6nLk".

			GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly; // Dont know what it does, but its recommended by the tutorial.

			gMapControl1.MinZoom = 2;
			gMapControl1.MaxZoom = 18;
			gMapControl1.Zoom = 13;

			// to do...
			//
			// Right now, the map is set up for the default GMap interaction behavior...
			// Using the mouse, you can right-click-and-drag (on the map) to move it around;
			// you can use the scroll wheel to zoom in an out.
			// This looks like the only means of interaction.
			//
			// Possibly we could change it so you can control it using the keyboard.
			// (Maybe we want the normal mouse click (left click) to be the one that pans it.)
			// (I feel like that's a bit more natural.)
			// Also have to keep in mind we might be setting markers on it.
			// Although now that I think about it,
		}


		//private void example1()
		//{
		//	// My thought process here was to try to copy the example that
		//	// dr. delatorre showed us when we (me, Jeremiah, Jason, couple other people)
		//	// met with dr. delatorre i think it was Wednesday the 7th (April).
		//	//
		//	// He had an example that showed the van going to a point.
		//	// I copied a little of the code he was showing us while he was explaining it,
		//	// 
		//
		//
		//	//GMap.NET.
		//	GMap.NET.PointLatLng start;
		//	GMap.NET.PointLatLng end;
		//	 
		//
		//}


		private void example1()
		{
			GMap.NET.PointLatLng start;
			GMap.NET.PointLatLng end;

			//GMap.NET.GDirections gDirections1;
			GMap.NET.WindowsForms.GMapRoute gMapRoute1;
			GMap.NET.WindowsForms.GMapOverlay gMapOverlay1;

			try
			{
				// Luis hard-codes an example start- and end-point,
				// I think I might try to make it dynamic to help me understand it
				// and give me practice with it.
				// However at first to get the code running, I'm going to hard-code it.
				//
				start = new GMap.NET.PointLatLng(46.299106, -119.295999);
				end = new GMap.NET.PointLatLng(46.276860, -119.291511);

				var dirstatcode = GMap.NET.MapProviders.GMapProviders.GoogleMap.GetDirections(out gDirections1,
																							  start, end,
																							  false,  // bool avoidHighways
																							  false, // bool avoidTolls
																							  false, // bool walking mode
																							  false,  // bool sensor
																							  false  // bool metric
																							  );
				gMapRoute1 = new GMap.NET.WindowsForms.GMapRoute(gDirections1.Route, "foo");
				// After trying this, I get an error at the aboe line, saying that gDirections1 was null.
				//
				// Try 1
				// Changed MapProvider to GoogleMapProvider (was BingMapProvider).
				// No difference.
				//
				// Try 2
				// Moved the declaration of "gDirections1" to the entire form.
				// No difference.

				gMapOverlay1 = new GMap.NET.WindowsForms.GMapOverlay(); // string param is optional
				gMapOverlay1.Routes.Add(gMapRoute1);
				//MainMap.Overlays.Add(gMapOverlay1);
				this.gMapControl1.Overlays.Add(gMapOverlay1);




			}
			catch (Exception ex)
			{
				MessageBox.Show("Exception happened, {0}", ex.Message);
			}
		}

		private void button13_Click(object sender, EventArgs e)
		{
			example1();
		}



		// My stuff from solution "CSharpWithFirebase".

		IFirebaseConfig firebaseConfig = new FirebaseConfig()
		{
			AuthSecret = "foo",
			BasePath = "foo"
		};

		IFirebaseClient client;

		private void Main_Interface_Form_2_Load(object sender, EventArgs e)
		{
			try
			{
				client = new FireSharp.FirebaseClient(firebaseConfig);
			}
			catch
			{
				MessageBox.Show("There was a problem creating a FirebaseClient from the partuclar FirebaseConfig. (There could be a problem with interenret accces.)");
			}
		}

		// Add Appointment (1)
		//
		// Looks like this class (from Delatorre's code in the Milestone 2 PDF, which Jason copied into some C# files (thanks Jason))
		// uses a bunch of other custom classes in it,
		// so Im gonna skip it for now.
		//
		//private void buttonAddAppointment_Click(object sender, EventArgs e)
		//{
		//	Appointment a = new Appointment()
		//	{
		//
		//	}
		//}


		// Add Patient (4)
		//
		// This one looks pretty do-able with a basic Windows Form.
		// (Just set up a Windows Form that lets you fill in every field and bam.)
		//
		private void buttonAddPatient_Click(object sender, EventArgs e)
		{
			AddPatientForm addPatientForm = new AddPatientForm(ref client);
			addPatientForm.Show();
		}
















		//public System.Threading.Tasks.Task DrDelatorresWaytodoit()
		//{
		//	//******************** Initialization ***************************//
		//	var client = new FirebaseClient("https://cpts323battle.firebaseio.com/");
		//	HttpClient httpclient = new HttpClient();
		//	string selectedkey = "", responseString, companyId;
		//	FormUrlEncodedContent content;
		//	HttpResponseMessage response;

		//	//******************** Get initial list of Prospect ***********************//
		//	var Appointments = await client.Child("appointments").OnceAsync<Appointment>();

		//	foreach (var appointment in Appointments)
		//	{
		//		Console.WriteLine($"OA1:{appointment.Key}:->{appointment.Object.acepted}");
		//		//create a ilist os appointments
		//		//smart selection to improve your profit
		//		selectedkey = appointment.Key;
		//	}
		//	//******************** Get Prospect list one by one real time ***************************/
		//	var child = client.Child("appointments");
		//	var observable = child.AsObservable<Appointment>();
		//	//get a new appoinment in the list
		//	var subscriptionFree = observable
		//	.Where(f => !string.IsNullOrEmpty(f.Key)) // you get empty Key when there are no data on the server for specified node
		//	.Where(f => f.Object?.acepted == false)
		//	.Subscribe(appointment =>
		//	{
		//		selectedkey = appointment.Key;
		//		Console.WriteLine($"New Appoinment:{appointment.Key}:->{appointment.Object.destination.destinationName}");// update the lits of appointsments.
		//	});

		//	//******************* Cloud Function subcribe a Company ****************/
		//	var company = new Company
		//	{
		//		companyName = "WSU VANS",
		//		status = "active"
		//	};
		//				var dictionary = new Dictionary<string, string>
		//	{
		//	{ "companyName",company.companyName },
		//	{ "status",company.status}
		//	};
		//	content = new FormUrlEncodedContent(dictionary);
		//	response = await httpclient.PostAsync("https://us-central1-cpts323battle.cloudfunctions.net/reportCompany", content);
		//	responseString = await response.Content.ReadAsStringAsync();
		//	Response data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseString);
		//	//Response message
		//	Console.WriteLine(data.message);
		//	Console.WriteLine(data.companyId);
		//	companyId = data.companyId;

		//	//******************* Call Cloud Function select a Appointment By Id ****************/
		//	dictionary = new Dictionary<string, string>
		//	{
		//		{ "key",selectedkey },
		//		{ "carPlate","AXL234" },
		//		{ "did","2"},
		//		{ "company","Company_name"},
		//		{ "companyId",companyId},
		//		{ "carStars","4.8"},
		//		{ "image","http:.."}
		//	};

		//	content = new FormUrlEncodedContent(dictionary);
		//	response = await httpclient.PostAsync("https://us-central1-cpts323battle.cloudfunctions.net/selectAppointmentById", content);
		//	responseString = await response.Content.ReadAsStringAsync();
		//	data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseString);
		//	Console.WriteLine(data.message);

		//	//*******************Direct firebase modification example, this is uses only to report the appointment status ****************/
		//	var child2 = client.Child("/appointmentsStatus/" + selectedkey + "/status/0");
		//	var status = new Status
		//	{
		//		code = 100
		//	};
		//	await child2.PutAsync(status);
		//	var child3 = client.Child("/appointmentsStatus/" + selectedkey + "/status/1");
		//	status = new Status
		//	{
		//		code = 110
		//	};
		//	await child3.PutAsync(status);

		//	var child4 = client.Child("/appointmentsStatus/" + selectedkey + "/status/2");
		//	status = new Status
		//	{
		//		code = 120
		//	};

		//	await child4.PutAsync(status);
		//	//******************* Call Cloud Function updatePosition ****************/
		//	dictionary = new Dictionary<string, string>
		//	{
		//		{ "key",selectedkey },
		//		{ "did","12"},
		//		{ "companyId",companyId},
		//		{ "lat","46.271135"},
		//		{ "lng","-119.278556"}
		//	};

		//	content = new FormUrlEncodedContent(dictionary);
		//	response = await httpclient.PostAsync("https://us-central1-cpts323battle.cloudfunctions.net/updatePosition", content);
		//	responseString = await response.Content.ReadAsStringAsync();
		//	data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseString);
		//	Console.WriteLine(data.message);
		//	Console.WriteLine("Current index for the point " + data.index);
		//	//******************* Call Cloud Function for finishAppointment ****************/
		//	dictionary = new Dictionary<string, string>
		//	{
		//		{ "key",selectedkey },
		//		{ "did","12"},
		//		{ "companyId",companyId},
		//		{ "lat","10.1991"},
		//		{ "lng","-75.8890"}
		//	};

		//	content = new FormUrlEncodedContent(dictionary);
		//	response = await httpclient.PostAsync("https://us-central1-cpts323battle.cloudfunctions.net/finishAppointment", content);
		//	responseString = await response.Content.ReadAsStringAsync();
		//	data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseString);
		//	Console.WriteLine(data.message);
		//	var stop = Console.ReadLine();
		//	subscriptionFree.Dispose();
		//	//subscriptionSelected.Dispose();
		//}





	}
}
