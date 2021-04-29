using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;

namespace Home_Visits_Vaccination
{
	public class Class1
	{
		private static async Task Foo()
		{
			var client = new FirebaseClient("https://cpts323-kovidkillers-default-rtdb.firebaseio.com/");
			HttpClient httpClient = new HttpClient(); // System.Net.Http.HttpClient()
			FormUrlEncodedContent content;
			HttpResponseMessage response;

			//var appointments = await client.Child("directory").OnceAsync<foo>();

			//var appointments = await 
		}
	}
}
