using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using Newtonsoft.Json;

namespace CSharpWithFirebase
{
    public class GmapsExample
    {
        /*public static void DistanceEx()
        {
            string url = @"https://maps.googleapis.com/maps/api/distance/json?units=imperial&origins=501+Catskill+Street+Richland+WA&destinations=1803+George+Washington+Way+Richland+WA&key=AIzaSyBYjZ6_joA8X1RwpX8yCKk9D4BmqZjJLS4";

            WebRequest req = WebRequest.Create(url);

            WebResponse response = req.GetResponse();

            Stream data = response.GetResponseStream();

            StreamReader reader = new StreamReader(data);

            // json-formatted string from maps api
            string responseFromServer = reader.ReadToEnd();

            response.Close();
            Console.WriteLine(responseFromServer);
        }*/
        public static void RouteExample()
        {
            //var mainMap = new GMapProviders;
            //GMapProviders.GoogleMap.ApiKey = "AIzaSyD_EgYiqKMGksVC9LqJeRqx5WqRByy6nLk";
            GMapProviders.GoogleMap.ApiKey = "AIzaSyBsS4_zQy-svXOtLrS32XPphEsSX-EMY8M";
            PointLatLng start = new PointLatLng(46.289106, -119.292999);
            PointLatLng end = new PointLatLng(46.276860, -119.291511);
            GDirections routeDirection;
            //MapRoute  totalRoute;
            var temp = GMapProviders.GoogleMap.GetDirections(out routeDirection, start, end, false, false, false, false, false);
            Console.WriteLine(temp);
            var route = new GMapRoute(routeDirection.Route, "route");
            var routesOverlay = new GMapOverlay("routes");
            routesOverlay.Routes.Add(route);
        }
    }
}
