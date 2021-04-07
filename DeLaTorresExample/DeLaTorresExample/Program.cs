using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace DeLaTorresExample
{
	class Program
	{
		static void Main(string[] args)
		{
			Run().Wait();
		}

		private static async Task Run()
		{
			// *** Initialization *** //
			var client = new FirebaseClient("https://cpts323-kovidkillers-default-rtdb.firebaseio.com/");
			//HttpClient httpclient = new HttpClient();

			// *** Get initial list of people *** //
			var timeslots = await client.Child("Prospects").OnceAsync<Prospect>();
			//
			// This is the problem I was having using the FireSharp package.
			// I couldn't specify a folder in my database to get, I could only get
			// I guess what you might call "bottom-level" items.
			// I.e., I could only get actual items, and not folders-of-items.
			//
			// blah.Child("foo")
			// lets you get a folder.

			foreach (var slot in timeslots)
			{
				// The way I have it set up right now, the "Name" of the Prospect
				// is the key for that prospect in the database.
				//
				// And then the corresponding value for that prospect
				// is the whole set of attributes (fields, variables, whatever) that
				// the Prospect class has.

				// Console.WriteLine("Name: %d\n", slot.Key);
				// C# uses a different string format method than printf() in C.
				Console.WriteLine("Name: {0}", slot.Key);
				Console.WriteLine("Address: {0}\n", slot.Object.Address);
			}

			Console.WriteLine("(hit enter to quit)");
			Console.ReadLine();
		}
	}
}
