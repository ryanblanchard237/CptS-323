using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Visits_Vaccination
{
    public class Appointment
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
}
