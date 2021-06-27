using System.Collections.Generic;

namespace Tuwaiq.DesignPatterns.ObserverPattern
{
    public class Publisher
    {
        readonly ICollection<Observer> _observers = new List<Observer>();
        string _currentMessage = "";
        public string Message { set { _currentMessage = value; } }
        public void Notify() { foreach (var observer in _observers) observer.Update(_currentMessage); }
        public void Subscribe(Observer observer) => _observers.Add(observer);
        public void Unsubscribe(Observer observer) => _observers.Remove(observer);
        public void UnsubscribeAll() => _observers.Clear();
    }
}