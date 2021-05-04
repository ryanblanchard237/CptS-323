using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatMaps_GoogleMap_GetDirections
{
    class Appointment
    {
        public Patient patient { get; set; }
        public Van van { get; set; }
        public Destination destination { get; set; }
        public Origin origin { get; set; }
        public Point[] pointList { get; set; }
        public DateTime initialTime { get; set; }
        public bool accepted { get; set; }
        public double profit { get; set; }
    }

    class Patient
    {
        public string userName;
        public string FirstName;
        public string LastName;
        public string Status;// vacinated or not
        public string Age;
        public int pid;//can be the firebase id
        public string image;
        public string userCellphone;
    }

    class Van
    {
        public string Make;
        public string Model;
        public string Vials { get; set; }
        public string CarPlate;
        public string VanId { get; set; }
        public double lat;
        public double lon;
    }

    class Destination
    {
        public double lat;
        public double lon;
        public string destinationName;
        //public ServerTimeStamp TimestampPlaceholder { get; } = new ServerTimeStamp();
    }

    class Origin
    {
        public double lat;
        public double lon;
        public string originName;
        //public ServerTimeStamp TimestampPlaceholder { get; } = new ServerTimeStamp();
    }

    class Point
    {
        public double lat;
        public double lon;
        //public ServerTimeStamp TimestampPlaceholder { get; } = new ServerTimeStamp();
    }
}
