using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
	}
}
