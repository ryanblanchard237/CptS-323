using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Xml;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System.Reflection;


namespace Home_Visits_Vaccination
{
	public partial class Main_Interface_Form_2 : Form
	{
		internal readonly GMapOverlay objects = new GMapOverlay("objects");
		internal readonly GMapOverlay routes = new GMapOverlay("routes");
		internal readonly GMapOverlay polygons = new GMapOverlay("polygons");
		public Main_Interface_Form_2()
		{
			InitializeComponent();
		}

		GMap.NET.GDirections gDirections1;
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
			gMapControl1.MaxZoom = 18;
			gMapControl1.Zoom = 13;
		}


		private void example2() // This will work to get directions from one point to another routeDirection will contain the steps which we can use to display position. Also will include the time for the trip. Can use this to compare and find the optimal prospect.
		{
				GMapProviders.GoogleMap.ApiKey = "AIzaSyBsS4_zQy-svXOtLrS32XPphEsSX-EMY8M";
				PointLatLng start = new PointLatLng(46.289106, -119.292999);
				PointLatLng end = new PointLatLng(46.276860, -119.291511);


				var temp = GMapProviders.GoogleMap.GetDirections(out routeDirection, start, end, false, false, false, false, false);
				GMapRoute mapRoute2 = new GMapRoute(routeDirection.Route, "This Trip");
			GMapOverlay overlayTest = new GMapOverlay("Test Route");
			overlayTest.Routes.Add(mapRoute2);
			gMapControl1.Overlays.Add(overlayTest);
			GMap.NET.WindowsForms.Markers.GMarkerGoogle startP = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(start, GMarkerGoogleType.red_pushpin);// Adds the markers to start and end points.
			GMap.NET.WindowsForms.Markers.GMarkerGoogle endP = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(end, GMarkerGoogleType.red_pushpin);
			var carMark = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(mapRoute2.Points[10], new Bitmap("C:\\Users\\Jason\\Desktop\\323\\Milestone2\\CptS-323-main (1)\\CptS-323-main\\Home_Visits_Vaccination\\Home_Visits_Vaccination\\Car_Icon.png"));
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
			example2();
		}
	}
}
