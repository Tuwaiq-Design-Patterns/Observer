using System;
using System.Collections.Generic;

namespace ObserverPro
{


    interface ISubject {
        void Attach(IObserver observer);
        void Notify();
    }

    class MeteorologicalStion : ISubject
    {
        private List <IObserver> _observers;
        public float Temperature 
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                Notify();
            }
        }
        public float _temperature;
        public MeteorologicalStion()
        {
            _observers = new List<IObserver>();
        }

        public void Attach(IObserver observer) {
            _observers.Add(observer);
        }
        public void Notify() {

            _observers.ForEach(o =>
            {
                o.Update(this);
            });
        }

    }
    interface IObserver {
        void Update(ISubject subject);
    }

    class NewAgency : IObserver
    {
        public string Agencyname { get; set; }
        public NewAgency( string name )
        {
            Agencyname = name;
        }

        public void Update(ISubject subject)
        {
            if (subject is MeteorologicalStion staion)
            {
                Console.WriteLine(String.Format("The temperature reported by {0}, the degree in celsius is {1}", Agencyname, staion.Temperature));
                Console.WriteLine();


            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MeteorologicalStion staion = new MeteorologicalStion();
            NewAgency agency1 = new NewAgency("bbc news Agency");
            staion.Attach(agency1);

            NewAgency agency2 = new NewAgency("abc News Agency");
            staion.Attach(agency2);

            staion.Temperature = 22.2f;
            staion.Temperature = 28f;
            staion.Temperature = 55.0f;
            staion.Temperature = 16.9f;


            Console.ReadLine();
        }
    }
}
