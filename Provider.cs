using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Visits_Vaccination
{
    public class Provider //home visiting clinicians (nurse or doctor)
    {
        public string userName;
        public string FirstName;
        public string LastName;
        public string CDC_COVID_19;//status Provider Agreement
        public string Age;
        public int pid;//can be the firebase id
        public string image;
        public string userCellphone;
    }
}
