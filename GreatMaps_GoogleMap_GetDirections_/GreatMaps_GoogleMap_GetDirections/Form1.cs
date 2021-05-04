using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Firebase;

using GMap.NET;

namespace GreatMaps_GoogleMap_GetDirections
{
    public partial class Form1 : Form
    {
        PointLatLng currentVanLocation;
        List<Van> vans;
		Van formVan; // Gonna try this with a single van for now.
        List<Appointment> appointments;
		int positionInAppointmentsList;
		GMap.NET.WindowsForms.GMapOverlay routesOverlay; // I use this to hold any and all routes that are part of this map/program.
		GMap.NET.WindowsForms.GMapOverlay carMarkerOverlay;
		GMapMarkerVan carMarker;
		

        public Form1()
        {
            InitializeComponent();

			// Initialize the form variables as necesary.
			//currentVanLocation = new PointLatLng(); // might not need this since it's a C# struct.
			vans = new List<Van>();
			formVan = new Van();
			appointments = new List<Appointment>();
			positionInAppointmentsList = 0;
			routesOverlay = new GMap.NET.WindowsForms.GMapOverlay("Overlay for routes.");
			carMarkerOverlay = new GMap.NET.WindowsForms.GMapOverlay("Overlay for car marker.");
			InitCarMarker();

			// 2nd initialization steps.
			map.Overlays.Add(routesOverlay); // (I use "routesOverlay" to hold routes for the map.)
											 // (It has to be added to the GMapControl class.)
			map.Overlays.Add(carMarkerOverlay);

			GMap.NET.MapProviders.GMapProviders.GoogleMap.ApiKey = "AIzaSyBsS4_zQy-svXOtLrS32XPphEsSX-EMY8M";

			//TalkToFirebase();
			// not the above, and instead DoTheThing().

			RunSimulation();
        }

		// Sort of a constructor.
		private void mapLoad(object sender, EventArgs e)
		{
			// Good tutorial:
			// http://www.independent-software.com/gmap-net-beginners-tutorial-maps-markers-polygons-routes-updated-for-vs2015-and-gmap1-7.html

			this.map.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;

			//gMapControl1.MapProvider = GMapProviders.GoogleMap;
			//GMap.NET.MapProviders.GoogleMap.ApiKey = "<some key>";
			// The API key in Delatorre's code is "AIzaSyD_EgYiqKMGksVC9LqJeRqx5WqRByy6nLk".

			GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly; // Dont know what it does, but its recommended by the tutorial.
			this.map.Position = new PointLatLng(46.289106, -119.292999);
			this.map.MinZoom = 2;
			this.map.MaxZoom = 14;
			this.map.Zoom = 14;
		}

		private void InitCarMarker()
        {
			//string pathToImage = Path.Combine(Application.StartupPath, @"..\..\..\..\car-2.png");
			string pathToImage = @"C:\Users\Ryan\Documents\WSU\Classes\20 - 21\WSU Spring 2021\cs323_software_design\GreatMaps_GoogleMap_GetDirections\car-2.png";
			Bitmap b = new Bitmap(pathToImage);
			PointLatLng somewhereInTheTriCities = new PointLatLng(46.35, -119.217653);
			this.carMarker = new GMapMarkerVan(somewhereInTheTriCities /*new PointLatLng(0.0, 0.0)*/, b);

			this.carMarkerOverlay.Markers.Add(carMarker);
        }



		// Methods.

		private async Task TalkToFirebase()
		{
			var firebaseClient = new Firebase.Database.FirebaseClient("https://cpts323battle.firebaseio.com/");

			//***** Initial list of appointments. *****
			var appointmentsOnceAsync = await firebaseClient.Child("appointments").OnceAsync<Appointment>();

			foreach (var a in appointmentsOnceAsync)
			{
				var realA = a.Object;
				appointments.Add(realA);

				textBox1.Text += a.Key; // debug
				textBox1.Text += "\r\n"; // debug
			}

			//AppointmentListToTextbox();
			// It doesn't like this ribht now becaseu some part of the Appointment class
			// for an indivudal received appointment doesn't exist.


			//***** One-by-one real time. *****
			var appointmentsFolder = firebaseClient.Child("appointments");
			var newAppointmentNotifier = appointmentsFolder.AsObservable<Appointment>();

			var useThisWhenItDoesntWantMoreNotifications
				= newAppointmentNotifier.Subscribe(appointment =>
				{
					var realAppointment = appointment.Object;
					appointments.Add(realAppointment);

					// Could test this part by connecting the whole program to my Firebase
					// and then, while it's running, add some more Appointments to my Firebase.

					//NewAppointmentToTextbox();
					// Same problem as AppintmentListTotTextbox().
				});

			// I think that's everything (for the "Initial list" and "Real time" part.)
			// (Ignoring the "Cloud function" part right now.)
		}

		private async Task RunSimulation()
        {
			//TalkToFirebase().Wait(); // if i do this i think the form never finishes getting constructed.
			TalkToFirebase();
			Thread.Sleep(3000);
			// Give it a couple seconds to get the initial list.

			textBox1.Text += $"Before starting the simulation, the appointments list has {appointments.Count} items in it.\r\n";

			for (int i = 0; i < (this.appointments.Count - 1); i++)
            {
				PointLatLng start = new PointLatLng(this.appointments[i].origin.lat, this.appointments[i].origin.lon);
				PointLatLng end   = new PointLatLng(this.appointments[i+1].origin.lat, this.appointments[i+1].origin.lon);
				
				GMap.NET.WindowsForms.GMapRoute route = GetRoute(start, end, $"Appointment {i} to appointment {i+1}");

				VanAlongRoute(route);
            }
		}

		private void PutThisInAThread()
        {
			TalkToFirebase();

			while (true)
            {
				for (int i = 0; i < (this.appointments.Count - 1); i++)
				{
					if (i >= positionInAppointmentsList)
					{
						PointLatLng start = new PointLatLng(this.appointments[i].origin.lat, this.appointments[i].origin.lon);
						PointLatLng end = new PointLatLng(this.appointments[i + 1].origin.lat, this.appointments[i + 1].origin.lon);

						GMap.NET.WindowsForms.GMapRoute route = GetRoute(start, end, $"Appointment {i} to appointment {i + 1}");

						VanAlongRoute(route);

						i++;
					}
				}
			}
        }


		void VanAlongRoute(GMap.NET.WindowsForms.GMapRoute route)
		{
			double timeScale = 16;  // (timeScale * rateThatTimeActuallyMoves) = rateOfOurSimulation
									// So for example, 16 means things will move 16x as fast as they do in real life.

			double timeDelay = 0.001 * timeScale;
			// milliseconds x timeScale

			for (int i = 1; i < route.Points.Count; i++)
			{
				// Dont necessarily need the degree part. It just makes the car look better.

				double degree = MapMath.Bearing(route.Points[i - 1], route.Points[i]); // dont necessarily need.
				double deltaD = MapMath.Distance(route.Points[i - 1], route.Points[i]);

				degree = (degree * 180 / Math.PI + 360) % 360; // no idea what this does. // dont necessarily need.

				carMarker.Rotate((float)degree); // dont necessarily need.

				var distance = 0.0097222222; // 35 mph to miles/second.
				var deltaSeconds = deltaD / distance;
				deltaSeconds = deltaSeconds / timeScale;

				for (double s = 0; s < deltaSeconds; s += timeDelay)
				{
					var r = s / deltaSeconds;
					var dlat = r * (route.Points[i].Lat) + (1 - r) * (route.Points[i - 1].Lat);
					var dlng = r * (route.Points[i].Lng) + (1 - r) * (route.Points[i - 1].Lng);
					var M_point = new PointLatLng(dlat, dlng);

					Thread.Sleep((int)(deltaSeconds * timeDelay * 1000));
					// Wait time between each point as the van is traveling along the roads?

					carMarker.Position = M_point;
					//Console.WriteLine("Point {0} coords are: {1}", i, M_point);
				}
				// End of loop 2.
				// I dont know yet what this loop does.
				// I think maybe we don't need this loop.

				//Console.WriteLine("Point {0} coords are: {1}", i, carMarker.Position);
			}
			// End of loop 1.
			// This one moves us along the roads from the appointment that just got finished
			//   to the next appointment.

			//Console.WriteLine("Start Sleep 56s");
			//Console.WriteLine("{0}", Path.Combine(Application.StartupPath, @"..\..\..\..\Car_Icon4.png"));

			Thread.Sleep((int)(5.6 * 1000));
			// Wait time while the van is at the appointment?

			//Console.WriteLine("DONE. end is {0}", end);

			//firebase to update the status 1 (key),

			//Thread.Sleep((int)(56 * 1000));

			//firebase to update the status 2 ,

			//call firebase finishAppointment
		}



		private void AddDirectionsToMap(PointLatLng start, PointLatLng end, string routeName)
        {
			GDirections gDirections1;

			//GMap.NET.MapProviders.GoogleMapProvider
			//GMap.NET.MapProviders.GoogleMapProviderBase
			GMap.NET.MapProviders.GMapProviders.GoogleMap.GetDirections(
				out gDirections1, start, end,
				false, false, false, false, false);
			// I've been having a problem with this method call.
			// We'll see if this works.

			GMap.NET.WindowsForms.GMapRoute route1
				= new GMap.NET.WindowsForms.GMapRoute(gDirections1.Route, routeName);

			this.routesOverlay.Routes.Add(route1);
			this.map.Refresh();
        }

		private GMap.NET.WindowsForms.GMapRoute GetRoute(PointLatLng start, PointLatLng end, string routeName)
        {
			GDirections gDirections1;

			//GMap.NET.MapProviders.GoogleMapProvider
			//GMap.NET.MapProviders.GoogleMapProviderBase
			GMap.NET.MapProviders.GMapProviders.GoogleMap.GetDirections(
				out gDirections1, start, end,
				false, false, false, false, false);
			// I've been having a problem with this method call.
			// We'll see if this works.

			return (new GMap.NET.WindowsForms.GMapRoute(gDirections1.Route, routeName));
		}







	} // Form class
} // namespace
