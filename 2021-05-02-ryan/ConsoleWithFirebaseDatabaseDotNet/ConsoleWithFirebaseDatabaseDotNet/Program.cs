using System;

using Firebase;
using Firebase.Database;
using Firebase.Database.Query;

namespace ConsoleWithFirebaseDatabaseDotNet
{
    public class Program
    {
        public foo f;

        public Program()
        {
            f = new foo();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // If this solution had been set up as a Windows Form program,
            // the default would be something like
            //
            // Application.EnableVisualStyles():
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form2());  // <-- noteworthy part
            //
            //
        }


        static public void TalkToFirebase()
        {
            //***** Initialization *****\\
            var firebaseClient = new FirebaseClient("cs 323 battle firebase URL");




            //*** Get initial list of clients. ***\\
            // foo bar baz





            //*** Get client list one-by-one real time ***\\

            var appointmentsFolder = firebaseClient.Child("appointments");

            var newAppointmentNotifier = appointmentsFolder.AsObservable<Appointment>();

            var iDontKnowWhatThisIs = newAppointmentNotifier.Subscribe(appointment =>
            {
                Appointment theNewAppointment = appointment.Object;

                f.appointments.Add(theNewAppointment);
            });
            //
            // I dont really understand how this works but I looked up stuff about it a little bit.
            // Might be able to use it successfully.

        }
    }































    static public class TalkToFirebaseWrapper
    {
        static public void TalkToFirebase()
        {

        }
    }
}
