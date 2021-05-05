﻿using System;
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
		//public static List<Appointment> appointmentList;
		public static List<GMapMarkerVan> vanMarkers  = new List<GMapMarkerVan>();
		int indexOfCurrentAppointment;

		public Form2()
		{
			InitializeComponent();
			example1();
			FromMilestone4PDF();
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
	
		}


		public double Bearing(PointLatLng p1, PointLatLng p2)
		{
			//Convert input values to radians   
			var lat1 = DegreeToRadian(p1.Lat);
			var long1 = DegreeToRadian(p1.Lng);
			var lat2 = DegreeToRadian(p2.Lat);
			var long2 = DegreeToRadian(p2.Lng);
			double deltaLong = long2 - long1;
			double y = Math.Cos(lat2) * Math.Sin(deltaLong);
			double x = Math.Cos(lat1) * Math.Sin(lat2) - Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(deltaLong); ;
			double bearing = Math.Atan2(y, x);
			return bearing;
		}
		public class GMapMarkerVan : GMarkerGoogle
		{

			private readonly Bitmap icon = new Bitmap(Path.Combine(Application.StartupPath, @"C:\\Users\\Jason\\Desktop\\323\\Milestone2\\CptS-323-main (1)\\CptS-323-main\\Home_Visits_Vaccination\\Home_Visits_Vaccination\\Car_Icon4.png"));
			//private readonly Bitmap icon = new Bitmap(Path.Combine(Application.StartupPath, Path.Combine(Application.StartupPath, @"..\..\..\..\Car_Icon4.png")));
			float heading = 0;
			public GMapMarkerVan(PointLatLng p, Bitmap car) :base(p,car)
			{
				this.heading = 0;
				Size = icon.Size;
			}
			public void Rotate(float degre)
			{
				this.heading = degre;
			}
			public override void OnRender(Graphics g)
			{
				Matrix temp = g.Transform;
				g.TranslateTransform(LocalPosition.X, LocalPosition.Y);
				g.RotateTransform(-Overlay.Control.Bearing);

				try
				{
					g.RotateTransform(heading);
				}
				catch { }

				g.DrawImageUnscaled(icon, -icon.Width / 4, -icon.Height / 4);
				g.Transform = temp;
			}
		}
		public double DegreeToRadian(double angle)
		{
			return Math.PI * angle / 180.0;
		}
		public static async Task updatePosition(Appointment app, GMapMarkerVan curVan)
		{
		var dictionary = new Dictionary<string, string>
							{
							{ "key",app.Key },
							{ "did","12"},
							{ "companyId","Kovid Killers"},
							{ "lat", curVan.Position.Lat.ToString() },
							{ "lng",curVan.Position.Lng.ToString()}
							};
			HttpClient httpclient = new HttpClient();
			var content = new FormUrlEncodedContent(dictionary);
			var response = await httpclient.PostAsync("https://us-central1-cpts323battle.cloudfunctions.net/updatePosition", content);
			var responseString = await response.Content.ReadAsStringAsync();
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseString);
			Console.WriteLine(data.message);
			Console.WriteLine("Current index for the point " + data.index);
		}

		public async Task status0(Appointment myappointments)
	{
			var client = new FirebaseClient("https://cpts323battle.firebaseio.com/");
			var child2 = client.Child("/appointmentsStatus/" + myappointments.Key + "/status/0");
			var status = new Status
			{
				code = 100
			};
			await child2.PutAsync(status);
		}

		public async Task status1(Appointment myappointments)
		{
			var client = new FirebaseClient("https://cpts323battle.firebaseio.com/");
			var child2 = client.Child("/appointmentsStatus/" + myappointments.Key + "/status/1");
			var status = new Status
			{
				code = 110
			};
			await child2.PutAsync(status);
		}
		public async Task status2(Appointment myappointments)
		{
			var client = new FirebaseClient("https://cpts323battle.firebaseio.com/");
			var child2 = client.Child("/appointmentsStatus/" + myappointments.Key + "/status/2");
			var status = new Status
			{
				code = 120
			};
			await child2.PutAsync(status);
		}

		public void animate(int index)

		{
			GMapProviders.GoogleMap.ApiKey = "AIzaSyBsS4_zQy-svXOtLrS32XPphEsSX-EMY8M";
			PointLatLng start, end;
			
			start = new PointLatLng(46.289106, -119.292999);
			if (myappointments.Count != 0)
            {
               // for (int j = 0; j < 4; j++)
                //{
                    
						//start = new PointLatLng(myappointments[0].origin.lat, myappointments[0].origin.lon);
						myappointments[0].destination.lon = -119.111432;
						end = new PointLatLng(myappointments[0].destination.lat, myappointments[0].destination.lon);

					//else
					//{
					//	start = new PointLatLng(46.289106, -119.292999); // Will pass the selected appointment lat/lng here
					//		end = new PointLatLng(46.276860, -119.290511);
					//}
					
					var temp = GMapProviders.GoogleMap.GetDirections(out routeDirection, start, end, false, false, false, false, false); // API call to get the directions
					GMapRoute mapRoute2 = new GMapRoute(routeDirection.Route, "This Trip"); // Creates the route 
					GMapOverlay overlayTest = new GMapOverlay("Test Route");
					overlayTest.Routes.Add(mapRoute2);
					gMapControl1.Overlays.Add(overlayTest);
					GMap.NET.WindowsForms.Markers.GMarkerGoogle startP = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(start, GMarkerGoogleType.green_dot);// Adds the markers to start and end points.
					GMap.NET.WindowsForms.Markers.GMarkerGoogle endP = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(end, GMarkerGoogleType.red_dot);
					Bitmap icon = new Bitmap("C:\\Users\\Jason\\Desktop\\323\\Milestone2\\CptS-323-main (1)\\CptS-323-main\\Home_Visits_Vaccination\\Home_Visits_Vaccination\\Car_Icon4.png");
					//var carMark = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(mapRoute2.Points[11], new Bitmap("C:\\Users\\Jason\\Desktop\\323\\Milestone2\\CptS-323-main (1)\\CptS-323-main\\Home_Visits_Vaccination\\Home_Visits_Vaccination\\Car_Icon2.png")); // Sets the car marker variable and assigns it the bitmap (Icon)
					var carMark = new GMapMarkerVan(mapRoute2.Points[mapRoute2.Points.Count - 1], icon);
					vanMarkers.Add(carMark);
				//vanMarkers[j].Position = startP.Position;
				carMark.Position = start;
					objects.Markers.Add(startP); // Adds to markers list
					objects.Markers.Add(endP);  // adds to markers list
					//objects.Markers.Add(vanMarkers[j]); // Add the car marker to overlay.
					objects.Markers.Add(carMark);
					gMapControl1.Overlays.Add(objects); // Adds the markers to actual overlay.
					gMapControl1.ZoomAndCenterRoute(mapRoute2); // zooms to the route.
					Thread t = new Thread(() =>

					{


						var timedelay = 0.016;
						for (int i = 1; i < mapRoute2.Points.Count; i++)
						{
							var degree = Bearing(mapRoute2.Points[i - 1], mapRoute2.Points[i]);
							var deltaX = Distance(mapRoute2.Points[i - 1], mapRoute2.Points[i]);
							degree = (degree * 180 / Math.PI + 360) % 360;
							carMark.Rotate((float)degree);
							//vanMarkers[j].Rotate((float)degree);
							var distance = 0.00972222222; //35mph to miles per second
						var deltaSeconds = deltaX / distance;
							deltaSeconds = deltaSeconds / 16;
							status0(myappointments[0]);
							//Console.WriteLine(routeDirection);
							for (double s = 0; s < deltaSeconds; s = s + timedelay)
							{
								var r = s / deltaSeconds;
								var dlat = r * (mapRoute2.Points[i].Lat) + (1 - r) * (mapRoute2.Points[i - 1].Lat);
								var dlng = r * (mapRoute2.Points[i].Lng) + (1 - r) * (mapRoute2.Points[i - 1].Lng);
								var M_point = new PointLatLng(dlat, dlng);
								Thread.Sleep((int)(deltaSeconds * timedelay * 1000));
								//carMark.Position = M_point;
								carMark.Position = M_point;
								//Console.WriteLine("Point {0} coords are: {1}", i, M_point);
								updatePosition(myappointments[0], carMark);
							}
							
						}
						Console.WriteLine("Start Sleep 56s");
						
						Console.WriteLine("{0}", Path.Combine(Application.StartupPath, @"..\..\..\..\Car_Icon4.png"));
						status1(myappointments[0]);
						Thread.Sleep((int)(56 * 10));
						status2(myappointments[0]);
						Console.WriteLine("DONE. end is {0}", end);

					
                        //firebase to upfate the status 1 (key),

                        //Thread.Sleep((int)(56 * 1000));

                        //firebase to upfate the status 2 ,

                        //call firebase finishAppointment

                    //}
					//=>

					}
				);
					t.Start();
            }
        }
    //}
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
			animate(1);
			//example2(start,end);
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
    }
}
