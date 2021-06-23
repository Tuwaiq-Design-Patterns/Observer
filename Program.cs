using System;
using System.Collections.Generic;
using System.Threading;
using static Observer.Observer;

namespace Observer
{
    class Observer
    {
        public interface IObserver
        {
            // State
            void Update(ISubjectCourse subject);
        }

        public interface ISubjectCourse
        {

            void Subscribe(IObserver observer);
            void Unsubscribe(IObserver observer);
            void Notify();
        }

    
        public class SubjectCourse : ISubjectCourse
        {
            
            public int State { get; set; } = 0;

            private List<IObserver> _observers = new List<IObserver>();

            public void Subscribe(IObserver observer)
            {
                Console.WriteLine("Subscribe an observer.");
                this._observers.Add(observer);
            }

            public void Unsubscribe(IObserver observer)
            {
                this._observers.Remove(observer);
                Console.WriteLine("Unsubscribe an observer.");
            }

            public void Notify()
            {
                Console.WriteLine(" Notifying ...");

                foreach (var observer in _observers)
                {
                    observer.Update(this);
                }
            }

         
            public void Logic()
            {
                Console.WriteLine();
                 this.State = new Random().Next(0, 6);

                Thread.Sleep(10);

                Console.WriteLine(" My course has just changed to: " + this.State);
                this.Notify();
            }
        }

      
        class MathObserver : IObserver
        {
            public void Update(ISubjectCourse subject)
            {
                if ((subject as SubjectCourse).State < 4)
                {
                    Console.WriteLine("MathObserver: Course added");
                }
            }
        }

        class chemistryObserver : IObserver
        {
            public void Update(ISubjectCourse subject)
            {
                if ((subject as SubjectCourse).State == 0 || (subject as SubjectCourse).State >= 3)
                {
                    Console.WriteLine("ChemistryObserver: Course added");
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
            
                var subject = new SubjectCourse();
                var Math = new MathObserver();
                subject.Subscribe(Math);
                var chemistry = new chemistryObserver();
                subject.Subscribe(chemistry);
                subject.Logic();
                subject.Unsubscribe(chemistry);
                subject.Logic();
            }

        }
   
    }
}

