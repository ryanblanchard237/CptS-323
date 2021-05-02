using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq; // 21 -> 20 errors. (I think.)
using System.Net.Http; // 20 -> 12 errors. (I think.)
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Firebase.Database;
using Firebase.Database.Query;

namespace FormWithFirebaseDatabaseDotNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

			DelatorresMethod().Wait();
			//
			// When I do this I dont even get a window. I think this is not the way to do this.
        }

		public async Task DelatorresMethod()
		{
			//******************** Initialization ***************************//
			var client = new FirebaseClient("https://cpts323-kovidkillers-default-rtdb.firebaseio.com/");
			//var client = new FirebaseClient("https://cpts323battle.firebaseio.com/");
			HttpClient httpclient = new HttpClient();

			//string selectedkey = "", responseString, companyId;  // this confused me, see below.
			//
			string selectedKey = "";
			string responseString;
			string companyId;

			FormUrlEncodedContent content;
			HttpResponseMessage response;



			//******************** Get initial list of Prospect ***********************//
			//var Appointments = await client
			//.Child("appointments")//Prospect list
			//.OnceAsync<Appointment>();

			var appointments = await client.Child("appointments").OnceAsync<Appointment>();

			var appointments2 = client.Child("appointments").OnceAsync<Appointment>();
			//
			// No red squiggles.
			// Therefore you don't have to use the "await" keyword.


			foreach (var appointment in appointments)
			{
				//Console.WriteLine($"OA1:{appointment.Key}:->{appointment.Object.accepted}");
				//
				this.textBox1.Text = $"OA1:{appointment.Key}:->{appointment.Object.accepted}\r\n";
				//
				// This corresponds to the console output that looks like
				// OA1:ag45yw5:->False
				// OA1:asdsdgh:->False
				// etc.
				//
				// There is also stuff that looks like
				// New Appointment:ag45yw5:->13-25 17 Av pasco
				// New Appointment:asdsdgh:->13-25 17 Av pasco
				// etc.
				//
				// Jason was talking about using a Lat/Long in his example2() function in his Form2 cs file...
				// If we can get the appointment address from Firebase, then produce a Lat/Long from that,
				// we can modify e3xampkle2() sot hat it takes Lat/Long arguments, then run with it from there.




				//create a ilist os appointments
				//smart selection to improve your profit
				selectedKey = appointment.Key;
			}

			//Console.WriteLine(); // Little space to make it easier to see.
			textBox1.Text = textBox1.Text + "\r\n";









			//******************** Get Prospect list one by one real time ***************************/
			var child = client.Child("appointments");
			var observable = child.AsObservable<Appointment>();
			//
			// child.(as something that can be observed).
			// 
			// something that can be observed would be a provider.

			//get a new appoinment in the list
			var subscriptionFree = observable
			.Where(f => !string.IsNullOrEmpty(f.Key)) // you get empty Key when there are no data on the server for specified node
			.Where(f => f.Object?.accepted == false)
			.Subscribe(appointment =>
			{
				selectedKey = appointment.Key;
				//Console.WriteLine($"New Appoinment:{appointment.Key}:->{appointment.Object.destination.destinationName}");
				textBox1.Text = textBox1.Text + $"New Appoinment:{appointment.Key}:->{appointment.Object.destination.destinationName}";
				// update the list of appointsments.
			});


			// Maybe I can do like
			//Appointment appointment1; //commented out because it gives me a green blip on my scroll bar which distracts me.
			//appointment1.
			//appointment1.



			//var subFree2 = observable.Wher


			// From the ReadMe.md on the main Github page for the FirebaseDatabase.net package...
			//
			// (Section "Realtime streaming").

			//var observable2 = client.Child("Appointments").AsObservable<Appointment>().Subscribe(d => Console.WriteLine(d.Key));















			/*

			//******************* Cloud Function subcribe a Company ****************\

			var company = new Company
			{
				companyName = "WSU VANS",
				status = "active"
			};

			var dictionary = new Dictionary<string, string>
			{
				{ "companyName",company.companyName },
				{ "status",company.status}
			};

			content = new FormUrlEncodedContent(dictionary);
			response = await httpclient.PostAsync("https://us-central1-cpts323battle.cloudfunctions.net/reportCompany", content);
			responseString = await response.Content.ReadAsStringAsync();
			Response data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseString);
			//Response message
			Console.WriteLine(data.message);
			Console.WriteLine(data.companyId);
			companyId = data.companyId;


			//******************* Call Cloud Function select a Appointment By Id ****************\
			dictionary = new Dictionary<string, string>
			{
				{ "key",selectedkey },
				{ "carPlate","AXL234" },
				{ "did","2"},
				{ "company","Company_name"},
				{ "companyId",companyId},
				{ "carStars","4.8"},
				{ "image","http:.."}
			};
			content = new FormUrlEncodedContent(dictionary);
			response = await httpclient.PostAsync("https://us-central1-cpts323battle.cloudfunctions.net/selectAppointmentById", content);
			responseString = await response.Content.ReadAsStringAsync();
			data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseString);
			Console.WriteLine(data.message);


			//*******************Direct firebase modification example, this is uses only to report the appointment status ****************\
			var child2 = client.Child("/appointmentsStatus/" + selectedkey + "/status/0");
			var status = new Status
			{
				code = 100
			};
			await child2.PutAsync(status); // this...
			var child3 = client.Child("/appointmentsStatus/" + selectedkey + "/status/1");
			status = new Status
			{
				code = 110
			};
			await child3.PutAsync(status); // ...and this...

			var child4 = client.Child("/appointmentsStatus/" + selectedkey + "/status/2");
			status = new Status
			{
				code = 120
			};
			await child4.PutAsync(status); // ...and this
										   //
										   // can all be fixed by adding "using Firebase.Database.Query" at the top of the file.
										   //
										   // Although
										   // I still need my own "Status" class, in additon to that using statement, to make it work.
										   // (Which is confusing to me, I assumed the using statement just included a namespace that defined
										   // that class, but whatever.)
										   ///////////////////////////////////////////////////////////////////////////////////////////



			//******************* Call Cloud Function updatePosition ****************\
			dictionary = new Dictionary<string, string>
			{
				{ "key",selectedkey },
				{ "did","12"},
				{ "companyId",companyId},
				{ "lat","46.271135"},
				{ "lng","-119.278556"}
			};
			content = new FormUrlEncodedContent(dictionary);
			response = await httpclient.PostAsync("https://us-central1-cpts323battle.cloudfunctions.net/updatePosition", content);
			responseString = await response.Content.ReadAsStringAsync();
			data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseString);
			Console.WriteLine(data.message);
			Console.WriteLine("Current index for the point " + data.index);


			//******************* Call Cloud Function for finishAppointment ****************\
			dictionary = new Dictionary<string, string>
			{
				{ "key",selectedkey },
				{ "did","12"},
				{ "companyId",companyId},
				{ "lat","10.1991"},
				{ "lng","-75.8890"}
			};
			content = new FormUrlEncodedContent(dictionary);
			response = await httpclient.PostAsync("https://us-central1-cpts323battle.cloudfunctions.net/finishAppointment", content);
			responseString = await response.Content.ReadAsStringAsync();
			data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseString);
			Console.WriteLine(data.message);
			var stop = Console.ReadLine();

			*/

			subscriptionFree.Dispose();
		}
	}



















    public class DelatorresMethodWrapper
    {
		public async Task DelatorresMethod_InItsOwnClass()
		{
			//******************** Initialization ***************************//
			var client = new FirebaseClient("https://cpts323-kovidkillers-default-rtdb.firebaseio.com/");
			//var client = new FirebaseClient("https://cpts323battle.firebaseio.com/");
			HttpClient httpclient = new HttpClient();
			string selectedkey = "", responseString, companyId;
			FormUrlEncodedContent content;
			HttpResponseMessage response;



			//******************** Get initial list of Prospect ***********************//
			var Appointments = await client
			.Child("appointments")//Prospect list
			.OnceAsync<Appointment>();
			foreach (var appointment in Appointments)
			{
				//Console.WriteLine($"OA1:{appointment.Key}:->{appointment.Object.accepted}");

				

				//
				// This corresponds to the console output that looks like
				// OA1:ag45yw5:->False
				// OA1:asdsdgh:->False
				// etc.
				//
				// There is also stuff that looks like
				// New Appointment:ag45yw5:->13-25 17 Av pasco
				// New Appointment:asdsdgh:->13-25 17 Av pasco
				// etc.
				//
				// Jason was talking about using a Lat/Long in his example2() function in his Form2 cs file...
				// If we can get the appointment address from Firebase, then produce a Lat/Long from that,
				// we can modify e3xampkle2() sot hat it takes Lat/Long arguments, then run with it from there.




				//create a ilist os appointments
				//smart selection to improve your profit
				selectedkey = appointment.Key;
			}

			Console.WriteLine(); // Little space to make it easier to see.









			//******************** Get Prospect list one by one real time ***************************/
			var child = client.Child("appointments");
			var observable = child.AsObservable<Appointment>();



			// START AS-PROVIDED
			//get a new appoinment in the list
			var subscriptionFree = observable
			.Where(f => !string.IsNullOrEmpty(f.Key)) // you get empty Key when there are no data on the server for specified node
			.Where(f => f.Object?.accepted == false)
			.Subscribe(appointment =>
			{
				selectedkey = appointment.Key;
				Console.WriteLine($"New Appoinment:{appointment.Key}:->{appointment.Object.destination.destinationName}");
				// update the list of appointsments.
			});
			// END AS-PROVIDED

			// Maybe I can do like
			//Appointment appointment1; // see previous comment about green blips on the scroll bar.
			//appointment1.
			//appointment1.



			//var subFree2 = observable.Wher


			// From the ReadMe.md on the main Github page for the FirebaseDatabase.net package...
			//
			// (Section "Realtime streaming").

			//var observable2 = client.Child("Appointments").AsObservable<Appointment>().Subscribe(d => Console.WriteLine(d.Key));

















			//******************* Cloud Function subcribe a Company ****************/
			var company = new Company
			{
				companyName = "WSU VANS",
				status = "active"
			};

			var dictionary = new Dictionary<string, string>
			{
				{ "companyName",company.companyName },
				{ "status",company.status}
			};

			content = new FormUrlEncodedContent(dictionary);
			response = await httpclient.PostAsync("https://us-central1-cpts323battle.cloudfunctions.net/reportCompany", content);
			responseString = await response.Content.ReadAsStringAsync();
			Response data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseString);
			//Response message
			Console.WriteLine(data.message);
			Console.WriteLine(data.companyId);
			companyId = data.companyId;

			//******************* Call Cloud Function select a Appointment By Id ****************/
			dictionary = new Dictionary<string, string>
			{
				{ "key",selectedkey },
				{ "carPlate","AXL234" },
				{ "did","2"},
				{ "company","Company_name"},
				{ "companyId",companyId},
				{ "carStars","4.8"},
				{ "image","http:.."}
			};
			content = new FormUrlEncodedContent(dictionary);
			response = await httpclient.PostAsync("https://us-central1-cpts323battle.cloudfunctions.net/selectAppointmentById", content);
			responseString = await response.Content.ReadAsStringAsync();
			data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseString);
			Console.WriteLine(data.message);

			//*******************Direct firebase modification example, this is uses only to report the appointment status ****************/
			var child2 = client.Child("/appointmentsStatus/" + selectedkey + "/status/0");
			var status = new Status
			{
				code = 100
			};
			await child2.PutAsync(status); // this...
			var child3 = client.Child("/appointmentsStatus/" + selectedkey + "/status/1");
			status = new Status
			{
				code = 110
			};
			await child3.PutAsync(status); // ...and this...

			var child4 = client.Child("/appointmentsStatus/" + selectedkey + "/status/2");
			status = new Status
			{
				code = 120
			};
			await child4.PutAsync(status); // ...and this
										   //
										   // can all be fixed by adding "using Firebase.Database.Query" at the top of the file.
										   //
										   // Although
										   // I still need my own "Status" class, in additon to that using statement, to make it work.
										   // (Which is confusing to me, I assumed the using statement just included a namespace that defined
										   // that class, but whatever.)
										   ///////////////////////////////////////////////////////////////////////////////////////////


			//******************* Call Cloud Function updatePosition ****************/
			dictionary = new Dictionary<string, string>
			{
				{ "key",selectedkey },
				{ "did","12"},
				{ "companyId",companyId},
				{ "lat","46.271135"},
				{ "lng","-119.278556"}
			};
			content = new FormUrlEncodedContent(dictionary);
			response = await httpclient.PostAsync("https://us-central1-cpts323battle.cloudfunctions.net/updatePosition", content);
			responseString = await response.Content.ReadAsStringAsync();
			data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseString);
			Console.WriteLine(data.message);
			Console.WriteLine("Current index for the point " + data.index);

			//******************* Call Cloud Function for finishAppointment ****************/
			dictionary = new Dictionary<string, string>
			{
				{ "key",selectedkey },
				{ "did","12"},
				{ "companyId",companyId},
				{ "lat","10.1991"},
				{ "lng","-75.8890"}
			};
			content = new FormUrlEncodedContent(dictionary);
			response = await httpclient.PostAsync("https://us-central1-cpts323battle.cloudfunctions.net/finishAppointment", content);
			responseString = await response.Content.ReadAsStringAsync();
			data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseString);
			Console.WriteLine(data.message);
			var stop = Console.ReadLine();
		}
	}












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
		// Before filling in this class...
		// 10 errors.

		public string userName;
		public string FirstName;
		public string LastName;
		public string Status;// vacinated or not
		public string Age;
		public int pid;//can be the firebase id
		public string image;
		public string userCellphone;

		// Still 10 after filling in. But it's fine. Probably was still good to do.
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

		// After filling in this class...
		// 9 errors.
    }

	public class Destination
    {
		// Before fillung in... 10 errors

		public double lat;
		public double lon;
		public string destinationName;

		// after = 9.
    }

	public class Origin
    {
		public double lat;
		public double lon;
		public string originName;

		// still 9 after filling in this class.
    }

	// 10 errors.








	// Before this... 9 errors.
	public class Response
    {
		public bool success;
		public int index;
		public string message;
		public string companyId;
		public float fareCost;
    }
	// 4 after

	// Before this... 4 errors.
	public class Status
    {
		public int code;
		public int time;
    }
	// after 1.












	// 1 before.
	public class Company
    {
		public string companyName;
		public string status;
    }
	// 0 after.






	// AT THIS POINT
	//
	// I believe this should be


}
