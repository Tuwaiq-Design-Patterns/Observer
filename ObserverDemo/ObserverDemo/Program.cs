using System;

namespace ObserverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var steam = new Publisher();
            var gamerA = new GamerA();
            steam.Subscribe(gamerA);
            
            steam.NotifySubscriber();
            
            steam.Unsubscribe(gamerA);

        }
    }
}