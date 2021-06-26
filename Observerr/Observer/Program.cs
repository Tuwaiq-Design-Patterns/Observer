using System;
using System.Collections.Generic;
using System.Threading;

namespace ObserverProgram
{


    public class ObserverProgram
    {


        public interface IObserver
        {
            public void Update(ISubject subject);
        }


        public interface ISubject
        {
            public void AddObserver(IObserver o);
            public void RemoveObserver(IObserver o);
            public void NotifyObservers();

          
        }


        public class Publisher : ISubject
        {
            public int State { get; set; } = 0;

            private readonly List<IObserver> observers = new List<IObserver>();

            public Publisher()
            {
            }

            public void AddObserver(IObserver o)
            {
                Console.WriteLine("Subject: add an observer.");

                observers.Add(o);
            }

            public void RemoveObserver(IObserver o)
            {
                observers.Remove(o);
                Console.WriteLine("Subject: remove an observer.");

            }

            public void NotifyObservers()
            {
                Console.WriteLine("Subject: Publisher Notifying ");

                foreach (var ob in observers)
                {
                    ob.Update(this);
                }
            }



            public void SomeBusinessLogic()
            {
                Console.WriteLine("\nSubject: I'm doing something important.");
                this.State = new Random().Next(0, 10);

                Thread.Sleep(15);

                Console.WriteLine("Subject: My state has just changed to: " + this.State);
                this.NotifyObservers();
            }
        }


        class ReaderA : IObserver
        {
            public void Update(ISubject subject)
            {
                if ((subject as Publisher).State < 3)
                {
                    Console.WriteLine("ReaderA: Reacted to the event.");
                }
            }
        }

        class ReaderB : IObserver
        {
            public void Update(ISubject subject)
            {
                if ((subject as Publisher).State == 0 || (subject as Publisher).State >= 2)
                {
                   Console.WriteLine("ReaderB: Reacted to the event.");
                }
            }
        }

        public static void Main(string[] args)
                    {
            // client 
            var subject = new Publisher();
            var observerA = new ReaderA();
            subject.AddObserver(observerA);

            var observerB = new ReaderB();
            subject.AddObserver(observerB);

            subject.SomeBusinessLogic();
            subject.SomeBusinessLogic();

            subject.RemoveObserver(observerB);

            subject.SomeBusinessLogic();
        }

                }
            }
        