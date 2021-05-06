using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Visits_Vaccination
{
    public class Van
    {
        public string Make;
        public string Model;
        public string Vials { get; set; }
        public string CarPlate;
        public string VanId { get; set; }
        public double lat;
        public double lon;
        public bool inuse = false;
    }
}
