using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace ConsoleWithFirebaseDatabaseDotNet
{
	// This is the "Appointment" class and everything it depends on.

	public class Appointment // 12 -> 11 errors.
	{
		public Patient patient { get; set; } // custom
		public Van van { get; set; } // custom
		public Destination destination { get; set; } // custom
		public Origin origin { get; set; } // custom
		public Point[] pointList { get; set; } // System.Drawing.Point
		public DateTime initialTime { get; set; } // System.DateTime
		public bool accepted { get; set; }
		public double profit { get; set; }
	}

	public class Patient
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

	public class Van
	{
		// Filling this class in last because I'm kinda confused on how
		// a thing in C# works.
		//
		// 1) Just declaring a variable.
		//      var foo;
		// 2) Doing something like
		//      var foo = new foo();
		// 3) Declaring a variable that has the "get" and "set" keywords in curly braces.
		//      var foo { get; set; }
		//
		// I'm confused on the above 3 things.
		//
		// Filling in this class now so we can make some progress.

		public string Make;
		public string Model;
		public string Vials { get; set; }
		public string CarPlate;
		public string VanId { get; set; }
		public double lat;
		public double lon;
	}

	public class Destination
	{
		public double lat;
		public double lon;
		public string destinationName;
	}

	public class Origin
	{
		public double lat;
		public double lon;
		public string originName;
	}

}
