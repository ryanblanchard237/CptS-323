using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Net;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

using GMap;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using Firebase.Database;
using Firebase.Database.Query;
using System.Reactive.Linq;
using System.Net.Http;


namespace Home_Visits_Vaccination
{
	public partial class Form2 : Form
	{
		internal readonly GMapOverlay objects = new GMapOverlay("objects");
		internal readonly GMapOverlay routes = new GMapOverlay("routes");
		internal readonly GMapOverlay polygons = new GMapOverlay("polygons");
		static List<Appointment> myappointments= new List<Appointment>();

		PointLatLng currentVanLocation;
		public static List<Appointment> appointmentList;
		int indexOfCurrentAppointment;

		public Form2()
		{
			InitializeComponent();
		}

		GDirections gDirections1;
		static GDirections routeDirection;
		static GMapRoute mapRoute;

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
			gMapControl1.Position = new PointLatLng(46.289106, -119.292999);
			gMapControl1.MinZoom = 2;
			gMapControl1.MaxZoom = 14;
			gMapControl1.Zoom = 14;

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

		private double Distance(PointLatLng p1, PointLatLng p2)
		{
			//radius of earth in meters
			double R = 6371e3;

			double l1 = p1.Lat * Math.PI / 180;
			double l2 = p2.Lat * Math.PI / 180;

			double theta = (p2.Lat - p1.Lat) * Math.PI / 180;

			double lambda = (p2.Lng - p1.Lng) * Math.PI / 180;

			double a = Math.Sin(theta / 2) * Math.Sin(theta / 2)
				+ Math.Cos(l1) * Math.Cos(l2) *
				Math.Sin(lambda / 2) * Math.Sin(lambda / 2);

			double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));


			double m = R * c; // get distance in meters


			return m / 1609.344; //returns distance in miles

		}




		public static async Task FromMilestone4PDF()
		{
			//******************** Initialization ***************************//
			//var client = new FirebaseClient("https://cpts323-kovidkillers-default-rtdb.firebaseio.com/");
			var client = new FirebaseClient("https://cpts323battle.firebaseio.com/");
			HttpClient httpclient = new HttpClient();
			string selectedkey = "", responseString, companyId;
			FormUrlEncodedContent content;
			HttpResponseMessage response;



			//******************** Get initial list of Prospect ***********************//
			var Appointments = await client.Child("appointments").OnceAsync<Appointment>();

			foreach (var appointment in Appointments)
			{
				var temp = 0;
				Console.WriteLine($"OA1:{appointment.Key}:->{appointment.Object.accepted}");
				for (int i=0; i<myappointments.Count; i++)
                {
					if (myappointments[i].Key== appointment.Key)
						temp = i;
					if (temp > 0)
					{
						appointment.Object.Key = appointment.Key;
						myappointments[i] = appointment.Object;
					}
					else 
					{
						appointment.Object.Key = appointment.Key;
						myappointments.Add(appointment.Object);
					}
					temp = 0;
                }
				if (myappointments.Count == 0)
				{
					appointment.Object.Key = appointment.Key;
					myappointments.Add(appointment.Object);

				}
				selectedkey = appointment.Key;
				//myappointments.Add(appointment.Object);

			}

			//******************** Get Prospect list one by one real time ***************************/
			var child = client.Child("appointments");
			var observable = child.AsObservable<Appointment>();
			//
			// child.(as something that can be sovbservser)
			//
			// something that can be obvserved wotul dbew a provider.
			//
			// child.AsProvider() // as push-notification provider. (Provider-Observer .NET method.)


			// START AS-PROVIDED
			//get a new appoinment in the list
			var subscriptionFree = observable
			.Where(f => !string.IsNullOrEmpty(f.Key)) // you get empty Key when there are no data on the server for specified node
			.Where(f => f.Object?.accepted == false)
			.Subscribe(appointment =>
			{
				selectedkey = appointment.Key;
				Console.WriteLine($"New Appoinment:{appointment.Key}:->{appointment.Object.destination.destinationName}");
				// update the list of appointsments.

			  // appointmentList.Add(appointment.Object);

			});
		}

		public   void example2(PointLatLng start, PointLatLng end) 
		{

			GMapProviders.GoogleMap.ApiKey = "AIzaSyBsS4_zQy-svXOtLrS32XPphEsSX-EMY8M";
			//PointLatLng start = new PointLatLng(46.289106, -119.292999); // Will pass the selected appointment lat/lng here
			//PointLatLng end = new PointLatLng(46.276860, -119.291511);
			var temp = GMapProviders.GoogleMap.GetDirections(out routeDirection, start, end, false, false, false, false, false); // API call to get the directions
			GMapRoute mapRoute2 = new GMapRoute(routeDirection.Route, "This Trip"); // Creates the route 
			GMapOverlay overlayTest = new GMapOverlay("Test Route");
			overlayTest.Routes.Add(mapRoute2);
			gMapControl1.Overlays.Add(overlayTest);
			GMap.NET.WindowsForms.Markers.GMarkerGoogle startP = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(start, GMarkerGoogleType.red_pushpin);// Adds the markers to start and end points.
			GMap.NET.WindowsForms.Markers.GMarkerGoogle endP = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(end, GMarkerGoogleType.red_pushpin);
			var carMark = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(mapRoute2.Points[11], new Bitmap("C:\\Users\\Jason\\Desktop\\323\\Milestone2\\CptS-323-main (1)\\CptS-323-main\\Home_Visits_Vaccination\\Home_Visits_Vaccination\\Car_Icon2.png")); // Sets the car marker variable and assigns it the bitmap (Icon)
			objects.Markers.Add(startP); // Adds to markers list
			objects.Markers.Add(endP);  // adds to markers list
			objects.Markers.Add(carMark); // Add the car marker to overlay.

			gMapControl1.Overlays.Add(objects); // Adds the markers to actual overlay.
			gMapControl1.ZoomAndCenterRoute(mapRoute2); // zooms to the route.

			Console.WriteLine(routeDirection);
			for (int i = 0; i < mapRoute2.Points.Count; i++)
			{
				carMark.Position = mapRoute2.Points[i];
				gMapControl1.Refresh();
				Thread.Sleep(1000);
				Console.WriteLine("Point {0} coords are: {1}", i, mapRoute2.Points[i]);
			}
			/*// This will work to get directions from one point to another routeDirection will contain the steps which we can use to display position.
			// Also will include the time for the trip. Can use this to compare and find the optimal prospect.

			GMapProviders.GoogleMap.ApiKey = "AIzaSyD_EgYiqKMGksVC9LqJeRqx5WqRByy6nLk"; //"AIzaSyBsS4_zQy-svXOtLrS32XPphEsSX-EMY8M"; // that didnt help.
			PointLatLng start = new PointLatLng(46.289106, -119.292999);
			PointLatLng end = new PointLatLng(46.276860, -119.291511);

			GMapProviders.GoogleMap.GetDirections(out routeDirection, start, end, false, false, false, false, false);
			//routeDirection.Route

			// Just make a bunch of points to see if the other thing even works.
			// (ie if its just the thing thats not the other thing that has a problem.)
			//
			List<PointLatLng> pointLatLngs = new List<PointLatLng>();
			pointLatLngs.Add(new PointLatLng(46.209161, -119.176587)); // Kennewick
			pointLatLngs.Add(new PointLatLng(46.203846, -119.186387)); // Kennewick
			pointLatLngs.Add(new PointLatLng(46.209517, -119.203108)); // Kennewick
			pointLatLngs.Add(new PointLatLng(46.232833, -119.104462)); // Pasco
			pointLatLngs.Add(new PointLatLng(46.245739, -119.130955)); // Pasco
			pointLatLngs.Add(new PointLatLng(46.284001, -119.295114)); // Richland

			GMapRoute gMapRoute1 = new GMapRoute(pointLatLngs, "gMapRoute3");
			GMapOverlay overlay1 = new GMapOverlay("Test Route");
			overlay1.Routes.Add(gMapRoute1);
			gMapControl1.Overlays.Add(overlay1); //x
			gMapControl1.Refresh();

			GMarkerGoogle startP = new GMarkerGoogle(start, GMarkerGoogleType.red_pushpin);// Adds the markers to start and end points.
			GMarkerGoogle endP = new GMarkerGoogle(end, GMarkerGoogleType.red_pushpin);



			GMarkerGoogle car = new GMarkerGoogle(pointLatLngs[1], new Bitmap(@"C:\Users\Jason\Desktop\323_2\CptS-323-main\CptS-323-main\2021-04-30-ryan\Home_Visits_Vaccination\car-2.png")); // better.
			// 
			// Maybe don't need to down-scale the size of the car now.
			// (I shrunk the original image and called that result file "car-2".
			// 
			// System.Drawing.Size carOldSize = car.Size;
			// textBox1.Text = $"Current values of car.Size...\r\ncar.Size.Width = {carOldSize.Width}\r\ncar.Size.Height = {carOldSize.Height}\r\n";
			// 
			// System.Drawing.Size carNewSize = new System.Drawing.Size();
			// double carScaleFactor = 0.1;
			// carNewSize.Width = (int)(carScaleFactor * carOldSize.Width);
			// carNewSize.Height = (int)(carScaleFactor * carOldSize.Height);
			// string textBox1OldText = textBox1.Text;
			// textBox1.Text = textBox1OldText + $"car new size...\r\nWidth = {carNewSize.Width}\r\nHeight = {carNewSize.Height}\r\n";
			// 
			// car.Size = carNewSize;



			GMapOverlay overlay2 = new GMapOverlay("car");
			overlay2.Markers.Add(car);
			gMapControl1.Overlays.Add(overlay2);

			int i=0;
			while (true)
			{
				car.Position = pointLatLngs[i];
				gMapControl1.Refresh();
				Thread.Sleep(1000);
				
				i++;
				if (i == pointLatLngs.Count)
					break;
			}
			*/
		}



		public static async Task example1()
		{
			var client = new FirebaseClient("https://cpts323battle.firebaseio.com/");
			HttpClient httpclient = new HttpClient();
			string selectedkey = "", responseString, companyId;
			FormUrlEncodedContent content;
			HttpResponseMessage response;

			var company = new Company
			{
				companyName = "Kovid Killers",
				status = "active"
			};

			var dictionary = new Dictionary<string, string>
			{
				{ "companyName",company.companyName },
				{ "status",company.status}
			};

			content = new FormUrlEncodedContent(dictionary);
			response = await httpclient.PostAsync("https://us-central1-cpts323battle.cloudfunctions.net/reportCompany", content);
			responseString = await response.Content.ReadAsStringAsync();
			Response data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseString);
			//Response message
			Console.WriteLine(data.message);
			Console.WriteLine(data.companyId);
			companyId = data.companyId;
		}

		private void button13_Click(object sender, EventArgs e)
		{
			//example1();
			PointLatLng start = new PointLatLng(46.289106, -119.292999); // Will pass the selected appointment lat/lng here
			PointLatLng end = new PointLatLng(46.276860, -119.291511);
			example2(start,end);
		}



		// My stuff from solution "CSharpWithFirebase".

		IFirebaseConfig firebaseConfig = new FirebaseConfig()
		{
			AuthSecret = "foo",
			BasePath = "foo"
		};

		IFirebaseClient client;

		private void Form2_Load(object sender, EventArgs e)
		{
			try
			{
				client = new FireSharp.FirebaseClient(firebaseConfig);
			}
			catch
			{
				MessageBox.Show("There was a problem creating a FirebaseClient from the partuclar FirebaseConfig. (There could be a problem with interenret accces.)");
			}

			//TalkToFirebase.FromMilestone4PDF();
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
			example1();
			FromMilestone4PDF();
			//AddPatientForm addPatientForm = new AddPatientForm(ref client);
			//addPatientForm.Show();
		}

		private void Form2_ResizeEnd(object sender, EventArgs e)
        {

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
