using System;
using System.Collections.Generic;
using System.Threading;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            // The client code.
            var newspaper = new Newspaper();
            var observerA = new OldReader();
            newspaper.AddObserver(observerA);

            var observerB = new NewbieRedear();
            newspaper.AddObserver(observerB);

            newspaper.SomeBusinessLogic();
            newspaper.SomeBusinessLogic();

            newspaper.RemoveObserver(observerB);

            newspaper.SomeBusinessLogic();
        }

        public interface IObserver
        {
            void Update(ISubject subject);
        }

        public interface ISubject
        {

            public void AddObserver(IObserver observer);
            public void RemoveObserver(IObserver observer);
            public void Notify(); 
        }

        public class Newspaper : ISubject
        {
            public int State { get; set; } = -0;
            private List<IObserver> _observers = new List<IObserver>();

            public void AddObserver(IObserver observer)
            {
                this._observers.Add(observer);
                Console.WriteLine("Newspaper: Attached an observer for newspaper");
            }
            public void RemoveObserver(IObserver observer)
            {
                this._observers.Remove(observer);
                Console.WriteLine("Newspaper: Detached an observer of newspaper");
            }

            // Trigger an update in each subscriber in Magazine
            public void Notify()
            {
                Console.WriteLine("Newspaper: Notifying observers...");

                foreach (var observer in _observers)
                {
                    observer.Update(this);
                }
            }

            public void SomeBusinessLogic()
            {
                Console.WriteLine("Newspaper: I have a new release");
                this.State = new Random().Next(0, 10);

                Thread.Sleep(15);

                Console.WriteLine("Subject: My state has just changed to: " + this.State);
                this.Notify();
            }

        }

        class OldReader : IObserver
        {
            public void Update(ISubject subject)
            {
                if ((subject as Newspaper).State < 3)
                {
                    Console.WriteLine("OldReader : Reacted to the event.");
                }
            }
        }
        
        class NewbieRedear : IObserver
        {
            public void Update(ISubject subject)
            {
                if ((subject as Newspaper).State == 0 || (subject as Newspaper).State >= 2)
                {
                    Console.WriteLine("NewbieRedear : Reacted to the event.");
                }
            }
        }
    }
}
