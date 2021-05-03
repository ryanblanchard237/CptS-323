using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Firebase.Database;
using Firebase.Database.Query;


// Connect to Dr. Delatorre's Firebase.
// PDF page 14, "calling by cloud". "Direct Firebase modification."


namespace Home_Visits_Vaccination
{
	static public class TalkToFirebase
	{
		public static async Task FromMilestone4PDF()
		{
			//******************** Initialization ***************************//
			var client = new FirebaseClient("https://cpts323-kovidkillers-default-rtdb.firebaseio.com/");
			//var client = new FirebaseClient("https://cpts323battle.firebaseio.com/");
			HttpClient httpclient = new HttpClient();
			string selectedkey = "", responseString, companyId;
			FormUrlEncodedContent content;
			HttpResponseMessage response;



			//******************** Get initial list of Prospect ***********************//
			var Appointments = await client.Child("appointments").OnceAsync<Appointment>();

			foreach (var appointment in Appointments) {

				Console.WriteLine($"OA1:{appointment.Key}:->{appointment.Object.accepted}");
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
			//
			// child.(as something that can be sovbservser)
			//
			// something that can be obvserved wotul dbew a provider.
			//
			// child.AsProvider() // as push-notification provider. (Provider-Observer .NET method.)


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

				// Form2.appointmentList.Add(appointment);

			});
			// END AS-PROVIDED






			// class NewAppointmentObserver;
			
			// NewAppointmentObserver nao;

			//var newAppointmentProvider = appointmentFolder.AsObservable<Appointment>();

			//newAppointmentProvider.Subscribe(nao);
			//
			// And then maybe there's code inside of nao that - when nao gets notified of a new appointment -
			// that code does something?
			// (And in Deltaorre's example, that code just does a Console.WriteLine(neufvbfergbejfeivrhr (appointment key, appoint dest name) ) ?








			// Maybe I can do like
			Appointment appointment1;
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

			subscriptionFree.Dispose();
		}

		


		












		static void TryLambdaOperator()
		{
			string[] words = { "bot", "apple", "apricot" };

			int minimalLength = words.Where(w => w.StartsWith("a")).Min(w => w.Length);

			Console.WriteLine(minimalLength);

		}








		//////////////////////////////////////////////////////////////
		// https://github.com/step-up-labs/firebase-database-dotnet
		//
		//var authSecret = "your_auth_secret";

	}


	public class Response
	{
		public bool success;
		public int index;
		public string message;
		public string companyId;
		public float fareCost;
	}

	public class Status
	{
		public int code;
		public int time;
	}

	//public class Company
	//{
	//	public string companyName;
	//	public string status;
	//}
}
