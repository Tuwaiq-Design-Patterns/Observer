using System;
using System.Collections.Generic;
using System.Threading;

namespace Observer
{
    public interface IObserver
    {
        // Receive update from subject
        void Update(ISubject subject);
    }

    public interface ISubject
    {
       
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObserver();
    }


    public class Magazine : ISubject
    {
        public int State { get; set; } = 4; // to know if change state , to send update to reader
        private List<IObserver> _observers = new List<IObserver>();

        public void RegisterObserver(IObserver observer)
        {
            Console.WriteLine("Magazine: Register");
            this._observers.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Magazine: Remove");
        }

        // Trigger an update in each subscriber in Magazine
        public void NotifyObserver()
        {
            Console.WriteLine("Magazine: Notifying ...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nMagazine: I'm look who's interested");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: My state has just changed to: " + this.State);
            this.NotifyObserver();
        }
    }


    class ReaderA : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Magazine).State < 3)
            {
                Console.WriteLine("Reader A : Receive update about magazine");
            }
        }
    }

    class ReaderB : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Magazine).State == 0 || (subject as Magazine).State >= 2)
            {
                Console.WriteLine("Reader B : Receive update about magazine");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // client 
            var subject = new Magazine();
            var observerA = new ReaderA();
            subject.RegisterObserver(observerA);

            var observerB = new ReaderB();
            subject.RegisterObserver(observerB);

            subject.SomeBusinessLogic();
            subject.SomeBusinessLogic();

            subject.RemoveObserver(observerB);

            subject.SomeBusinessLogic();
        }
    }
}

