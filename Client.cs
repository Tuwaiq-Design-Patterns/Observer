using System;

namespace Tuwaiq.DesignPatterns.ObserverPattern
{
    class Client
    {
        static void Main(string[] args)
        {
            var publisher = new Publisher();

            Observer observer1 = new Observer(), observer2 = new Observer(), observer3 = new Observer();

            publisher.Subscribe(observer1);
            publisher.Subscribe(observer2);
            publisher.Subscribe(observer3);

            publisher.Message = "This is a new message.";
            publisher.Notify();

            observer1.Print();
            observer2.Print();
            observer3.Print();
        }
    }
}