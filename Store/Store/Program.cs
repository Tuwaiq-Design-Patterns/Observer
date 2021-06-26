using System;
using System.Collections.Generic;

namespace Store
{
    public class Subject : ISubject
    {
        private List<Observer> observers = new List<Observer>();
        private int _int;
        public int Inventory
        {
            get
            {
                return _int;
            }
            set
            {
                
          if (value > _int)
                    Notify();
                _int = value;
            }
        }
        public void Subscribe(Observer observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(Observer observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            observers.ForEach(x => x.Update());
        }
    }

    interface ISubject
    {
        void Subscribe(Observer observer);
        void Unsubscribe(Observer observer);
        void Notify();
    }


    public class Observer : IObserver
    {
        public string ObserverName { get; private set; }
        public Observer(string name)
        {
            this.ObserverName = name;
        }
        public void Update()
        {
            Console.WriteLine(this.ObserverName + ": A new product has arrived at the store");
        }
    }

    interface IObserver
    {
        void Update();
    }
    class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject();
            // Observer1
            Observer observer1 = new Observer("Observer 1");
            subject.Subscribe(observer1);
            // Observer2 
            subject.Subscribe(new Observer("Observer 2"));
            subject.Inventory++;
            // Observer1 unsubscribes and Observer3 subscribes .
            subject.Unsubscribe(observer1);
            subject.Subscribe(new Observer("Observer 3"));
            subject.Inventory++;
            Console.ReadLine();
        }
    }
}
