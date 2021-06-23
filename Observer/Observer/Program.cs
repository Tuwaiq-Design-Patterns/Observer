using System;
using System.Collections.Generic;
using static System.Console;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var publisher = new Publisher();

            var subscriber1 = new Subscriber();
            var subscriber2 = new Subscriber();
            var subscriber3 = new Subscriber();
            var subscriber4 = new Subscriber();
            var subscriber5 = new Subscriber();

            publisher.Subscribe(subscriber1);
            publisher.Subscribe(subscriber2);
            publisher.Subscribe(subscriber3);
            publisher.Subscribe(subscriber4);
            publisher.Subscribe(subscriber5);

            WriteLine("\nBefore notifying subscribers...");
            subscriber1.Print();
            subscriber2.Print();
            subscriber3.Print();

            publisher.SetState("This is a new message.");
            publisher.Notify();

            WriteLine("\nAfter notifying subscribers...");
            subscriber1.Print();
            subscriber2.Print();
            subscriber3.Print();
        }
    }
    public class Subscriber
    {
        private string _message;

        public Subscriber()
        {
            _message = "";
        }

        public void Update(string newState)
        {
            _message = newState;
        }
        public void Print()
        {
            WriteLine("Message -> {0}", _message);
        }
    }
    public class Publisher
    {
        private readonly ICollection<Subscriber> _members;
        private string _mainState;
        public Publisher()
        {
            _members = new List<Subscriber>();
            _mainState = "";
        }

        public void SetState(string m)
        {
            _mainState = m;
        }

        public void Notify()
        {
            foreach (var s in _members)
            {
                s.Update(_mainState);
            }
        }

        public void Subscribe(Subscriber s)
        {
            _members.Add(s);
        }

        public void Unsubscribe(Subscriber s)
        {
            _members.Remove(s);
        }

        public void UnsubscribeAll()
        {
            _members.Clear();
        }
    }
}