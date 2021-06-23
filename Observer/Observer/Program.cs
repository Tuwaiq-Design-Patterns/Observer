using System;
using System.Collections.Generic;
using System.Threading;

namespace Observer
{
    public interface IObserver
    {
        // Receive update from subject
        void Update(ISwarovski swarovski);
    }

    public interface ISwarovski
    {
        void Subscribe(IObserver observer);

        void Unsubscribe(IObserver observer);

        void Notify();
    }

    public class Swarovski : ISwarovski
    {

        public int State { get; set; } = -0;

        private List<IObserver> _observers = new List<IObserver>();

        public void Subscribe(IObserver observer)
        {
            Console.WriteLine("Swarovski: Subscribe an observer");
            this._observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Swarovski: Unsubscribe an observer");
        }

        public void Notify()
        {
            Console.WriteLine("Swarovski: Notifying observers");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void BusinessLogic()
        {
            Console.WriteLine("\nSwarovski: There is a new collection of bracelets and rings");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Swarovski: My state has just changed to: " + this.State);
            this.Notify();
        }
    }
    class Rings : IObserver
    {
        public void Update(ISwarovski ring)
        {
            if ((ring as Swarovski).State < 3)
            {
                Console.WriteLine("Rings: New collection of rings.");
            }
        }
    }

    class Bracelets : IObserver
    {
        public void Update(ISwarovski bracelets)
        {
            if ((bracelets as Swarovski).State == 0 || (bracelets as Swarovski).State >= 2)
            {
                Console.WriteLine("Bracelets: New collection of bracelets.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var swarovski = new Swarovski();
            var rings = new Rings();
            swarovski.Subscribe(rings);

            var bracelets = new Bracelets();
            swarovski.Subscribe(bracelets);

            swarovski.BusinessLogic();
            swarovski.BusinessLogic();

            swarovski.Unsubscribe(bracelets);

            swarovski.BusinessLogic();
        }
    }
}

