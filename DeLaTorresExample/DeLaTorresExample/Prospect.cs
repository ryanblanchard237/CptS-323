using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaTorresExample
{
	class Prospect
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public bool Accepted { get; set; }

		// public bool VisitInProgress { get; set; }
		// // Maybe when a team gets to a client's (prospect's) house,
		// // they confirm their arrival using our software,
		// // and when they confirm their arrival this bool becomes true
		// // to indicate that a team is currently with this particular client.
		// public string AcceptedBy { get; set; }
		// // Maybe when a team accepts a client (ie. when the client is added to
		// // the team's list of upcoming clients),
		// // this string gets set to be the name of the team that accepted the client
		// // so that the overall system knows what teams are scheduled with what clients.
		//
		// Currently leaving these commented out so I can test the stuff I have.
	}
}
