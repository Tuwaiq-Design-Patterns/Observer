using System;

namespace Tuwaiq.DesignPatterns.ObserverPattern
{
    public class Observer
    {
        private string _message = "";
        public void Update(string message) => _message = message;
        public void Print() => Console.WriteLine("Message -> {0}", _message);
    }
}