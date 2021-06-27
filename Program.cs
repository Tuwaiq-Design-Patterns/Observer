using System;
using System.Collections.Generic;
using System.Threading;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {

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
    public interface IObserver
    {
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
        public int State { get; set; } = -0; 
        private List<IObserver> _observers = new List<IObserver>();

        public void RegisterObserver(IObserver observer)
        {
            Console.WriteLine("Magazine : NEW 'Register' observer . . .");
            this._observers.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Magazine : NEW 'Remove' observer . . .");
        }

        public void NotifyObserver()
        {
            Console.WriteLine(". ..* Notify *.. .");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void SomeBusinessLogic()
        {
            Console.WriteLine("Magazine: NEW release . . .");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: My state changed to: " + this.State);
            this.NotifyObserver();
        }
    }


    class ReaderA : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Magazine).State < 3)
            {
                Console.WriteLine("Reader A : Receive an update" );
            }
        }
    }

    class ReaderB : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Magazine).State == 0 || (subject as Magazine).State >= 2)
            {
                Console.WriteLine("Reader B : Receive an update ");
            }
        }
    }

    
}
