using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GMap.NET;

namespace GreatMaps_GoogleMap_GetDirections
{
    static public class MapMath
    {
		static public double Bearing(PointLatLng p1, PointLatLng p2)
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

		static public double DegreeToRadian(double angle)
		{
			return Math.PI * angle / 180.0;
		}

		static public double Distance(PointLatLng p1, PointLatLng p2)
		{
			//radius of earth in meters
			double R = 6371e3;

			double l1 = p1.Lat * Math.PI / 180;

			double l2 = p2.Lat * Math.PI / 180;

			double theta = (p2.Lat - p1.Lat) * Math.PI / 180;

			double lambda = (p2.Lng - p1.Lng) * Math.PI / 180;

			double a = Math.Sin(theta / 2) * Math.Sin(theta / 2)
				     +
				       Math.Cos(l1) * Math.Cos(l2) * Math.Sin(lambda / 2) * Math.Sin(lambda / 2);

			double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

			double m = R * c; // get distance in meters

			return m / 1609.344; //returns distance in miles

		}
	}
}
