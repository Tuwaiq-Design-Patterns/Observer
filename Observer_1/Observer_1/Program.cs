using System;
using System.Collections.Generic;

namespace Observer_1
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }

    class Newsagency : IObserver
    {
        public String AgenceyName { set; get; }
        public Newsagency(String name)
        {
            AgenceyName = name;
        }
        public void Update(ISubject subject)
        {
            if (subject is WeatherStation weatherStation)
            {
                Console.WriteLine(String.Format("{0} reporting temperture {1} degree celcius \n", AgenceyName, weatherStation.Temperature));
            }
        }
    }

    public interface ISubject
    {
        // Attach an observer to the subject.
        void Attach(IObserver observer);
        // Detach an observer from the subject.
        void Detach(IObserver observer);
        // Notify all observers about an event.
        void Notify();
    }

    public class WeatherStation : ISubject
    {
        private List<IObserver> _observers;
        public float Temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                Notify();
            } 
        }
        private float _temperature { set; get; }

        public WeatherStation()
        {
            _observers = new List<IObserver>();
        }
        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Attached an observer.\n");
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.\n");
        }
        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...\n");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            WeatherStation weatherStation = new WeatherStation();

            Newsagency agency1 = new Newsagency("agency1");
            weatherStation.Attach(agency1);

            Newsagency agency2 = new Newsagency("agency2");
            weatherStation.Attach(agency2);

            weatherStation.Temperature = 31.2f;
            weatherStation.Temperature = 33.2f;
            
            weatherStation.Detach(agency2);

            weatherStation.Temperature = 36.2f;
            weatherStation.Temperature = 39.2f;

        }
    }
}
