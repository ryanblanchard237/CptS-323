using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

using GMap.NET;
using GMap.NET.WindowsForms.Markers;

namespace GreatMaps_GoogleMap_GetDirections
{
	public class GMapMarkerVan : GMarkerGoogle
	{
		
		//private readonly Bitmap icon = new Bitmap(Path.Combine(Application.StartupPath, @"C:\\Users\\Jason\\Desktop\\323\\Milestone2\\CptS-323-main (1)\\CptS-323-main\\Home_Visits_Vaccination\\Home_Visits_Vaccination\\Car_Icon4.png"));
		private readonly Bitmap icon = new Bitmap(@"C:\Users\Ryan\Documents\WSU\Classes\20 - 21\WSU Spring 2021\cs323_software_design\GreatMaps_GoogleMap_GetDirections\car-2.png");
		//private readonly Bitmap icon = new Bitmap(Path.Combine(Application.StartupPath, Path.Combine(Application.StartupPath, @"..\..\..\..\Car_Icon4.png")));
		float heading = 0;

		public GMapMarkerVan(PointLatLng p, Bitmap car) : base(p, car)
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
}
