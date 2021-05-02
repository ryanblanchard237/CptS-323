using System;
using System.Collections.Generic;
using System.Text;

using Firebase.Database.Streaming;

// How to Implement a Provider
// https://docs.microsoft.com/en-us/dotnet/standard/events/how-to-implement-a-provider
//
// How to Implement an Observer
// https://docs.microsoft.com/en-us/dotnet/standard/events/how-to-implement-an-observer

namespace ConsoleWithFirebaseDatabaseDotNet
{
    // Step 1, already done. (Appointment class.)

    // Step 2, just the first line below of the class definition.

    class FirebaseNewAppointmentProvider: IObservable<FirebaseEvent<Appointment>>
    // Until we implemenet the "Subscribe()" method, we get red here. ^
    {
        public FirebaseNewAppointmentProvider()
        {
            this.observers = new List<IObserver<FirebaseEvent<Appointment>>>();
            // init the below list.
            //
            // This is part of step 3 in the tutorial.
        }

        List<IObserver<FirebaseEvent<Appointment>>> observers;
        // These are the observers (subscribers) (things that get notifed) that are
        // listeneing to this provider (this obsoervable).
        //
        // This is part of step 3 in the tutorial.


        // Step 4 is "Define an IDisposable implementation that he provider can give to subscribers
        // so that they can remvoe themselves from getting notificiations (from this provider).
        //
        // something about making a nested class called "Unsubscriber" that inherits from IDisposable,
        // it does some stuff, whatever.
        //
        // I did step 5 now I'm coming back to here.
        //
        // I still don't completely know what it does or how it works, but we have to have it.
        //
        public class Unsubscriber: IDisposable
        {
            private List<IObserver<FirebaseEvent<Appointment>>> _observers;
            private IObserver<FirebaseEvent<Appointment>> _observer;

            public Unsubscriber(List<IObserver<Appointment>> observers,
                                IObserver<Appointment> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (!(_observer == null))
                    _observers.Remove(_observer);
            }
        }



        // Step 5 = make the "this.Subscribe()" method.
        //
        // This method has to return an IDisposable.
        //
        public IDisposable Subscribe(IObserver<FirebaseEvent<Appointment>> observer)
        {
            if (!this.observers.Contains(observer))
                this.observers.Add(observer);

            return new Unsubscriber(observers, observer);
            //                   >> ^ >>>>>>>>>^
            //                   ^  ^ List<IObserver<Appointment>>, in the provider class.
            //                   ^
            //                   argument to this function.
            //
            // Return an Unsubscriber....
            // from the observers in this Provider class, and the specific obsever that subscribed to this provider.
        }
    }
}

// There might be something I'm not getting here because I'm having issues making this work
// with IObserver<FirebaseEvent<Appointment>>, etc.
// Something about that is apparently weird or something. not sure waht's going on.
