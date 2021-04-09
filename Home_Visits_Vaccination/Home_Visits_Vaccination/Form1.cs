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
	public partial class Main_Interface_Form : Form
	{
		public Main_Interface_Form()
		{
			InitializeComponent();
		}

		private void gMapControl1_Load(object sender, EventArgs e)
		{
			// Good tutorial:
			// http://www.independent-software.com/gmap-net-beginners-tutorial-maps-markers-polygons-routes-updated-for-vs2015-and-gmap1-7.html

			gMapControl1.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
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

		private void example1()
		{
			// My thought process here was to try to copy the example that
			// dr. delatorre showed us when we (me, Jeremiah, Jason, couple other people)
			// met with dr. delatorre i think it was Wednesday the 7th (April).
			//
			// He had an example that showed the van going to a point.
			// I copied a little of the code he was showing us while he was explaining it,
			// 


			//GMap.NET.
			GMap.NET.PointLatLng start;
			GMap.NET.PointLatLng end;
			 

		}
	}
}
