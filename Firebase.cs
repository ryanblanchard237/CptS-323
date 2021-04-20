using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Home_Visits_Vaccination
{
    public class fireBase
    {
        public static async Task addVanToFirebase(Van van)
        {
            var client = new FirebaseClient("https://cpts323.firebaseio.com");
            var vansChild = client.Child("Vans");
            var response = await vansChild.PostAsync(van);
        }
        public static async Task updateVanToFirebase(Van van, string vid)
        {
            var client = new FirebaseClient("https://cpts323.firebaseio.com");
            var vansChild = client.Child("Vans").Child(vid);
            await vansChild.PostAsync(van);
        }

        public static async Task addProvidersToFireBase(Provider provider)
        {
            var client = new FirebaseClient("https://daydream-b0bf1.firebaseio.com");
            var providersChild = client.Child("Providers");
            await providersChild.PostAsync(provider);
        }
    }
}
