using System;
using System.Collections.Generic;

namespace designpatren3
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Notify();
    }

    public class WitherStation : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        public float Temperature {
            get { return _temperature;}
            set
            {
                _temperature = value;
                Notify();
            }
        }
        private float _temperature;

        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }      
        }

    }

    class NewsAgency : IObserver
    {
       public string AgencyName { get; set; }
        public NewsAgency(string name)
        {
            AgencyName = name;
        }

        public void Update(ISubject subject)
        {
            if (subject is WitherStation WitherStation)
            {
                Console.WriteLine(String.Format("{0}, reporting  tempreture {1} degree celcius", AgencyName, WitherStation.Temperature));
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var WitherStation = new WitherStation();
            NewsAgency agency1 = new NewsAgency(" agency1 ");
            WitherStation.Attach(agency1);

            NewsAgency agency2 = new NewsAgency(" agency2 ");
            WitherStation.Attach(agency2);

            WitherStation.Temperature = 32.3f;

            WitherStation.Temperature = 2.3f;

            WitherStation.Temperature = 31.2f;

            WitherStation.Temperature = 27.8f;
        }
    }
}
