using System;

namespace ObserverDemo
{
    public class GamerA : ISubscriber
    {
        public void Update(Publisher publisher)
        {
            Console.WriteLine("GamerA: Reacted to the event.");
        }
    }
}