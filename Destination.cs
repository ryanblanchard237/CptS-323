using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Visits_Vaccination
{
    public class Destination
    {
        public double lat;
        public double lon;
        public string destinationName;
        public ServerTimeStamp TimestampPlaceholder { get; } = new ServerTimeStamp();
    }
}
