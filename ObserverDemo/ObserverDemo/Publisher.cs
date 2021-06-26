using System;
using System.Collections.Generic;

namespace ObserverDemo
{
    public class Publisher
    {
        private List<ISubscriber> _gamers = new List<ISubscriber>();
        
        
        public void Subscribe(ISubscriber subscriber)
        {
            Console.WriteLine("Publisher: Subscribe a gamer.");
            this._gamers.Add(subscriber);
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            this._gamers.Remove(subscriber);
            Console.WriteLine("Publisher: Unsubscribe a gamer.");
        }

        // Trigger an update in each subscriber.
        public void NotifySubscriber()
        {
            Console.WriteLine("Publisher: Notifying gamers...");

            foreach (var gamer in _gamers)
            {
                gamer.Update(this);
            }
        }
    }
}