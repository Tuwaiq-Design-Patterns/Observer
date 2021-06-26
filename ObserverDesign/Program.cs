using System;
using System.Collections.Generic;
using System.Threading;

namespace RefactoringGuru.DesignPatterns.Observer.Conceptual
{
    public interface ISubscribe
    {

        void Update(IDiscordBot subject);
    }

    public interface IDiscordBot
    {

        void Subscribe(ISubscribe subscriber);


        void Unsubscribe(ISubscribe subscriber);


        void Notify();
    }



    public class DiscordBot : IDiscordBot
    {


        public int State { get; set; } = -0;



        private List<ISubscribe> _subscribers = new List<ISubscribe>();


        public void Subscribe(ISubscribe subscriber)
        {
            this._subscribers.Add(subscriber);
            Console.WriteLine("You are a subscriber now");
        }

        public void Unsubscribe(ISubscribe subscriber)
        {
            this._subscribers.Remove(subscriber);
            Console.WriteLine("You just unsubscribed to this bot.");
        }


        public void Notify()
        {
            Console.WriteLine("Notification from this Bot");

            foreach (var sub in _subscribers)
            {
                sub.Update(this);
            }
        }





        public void StreamerWentLive()
        {
            Console.WriteLine("Streamer Went Live");
            this.State++;

            Thread.Sleep(15);

            Console.WriteLine("the state just changed to: " + this.State);
            this.Notify();
        }
    }



    class Subscriber1 : ISubscribe
    {
      

        public void Update(IDiscordBot subject)
        {
            Console.WriteLine();
            Console.WriteLine("Subscriber1 : Recived a notification ");
        }
    }

    class Subscriber2 : ISubscribe
    {

        public void Update(IDiscordBot subject)
        {
           
            Console.WriteLine("Subscriber2: Recived a notification");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var subject = new DiscordBot();
            var subscriber1 = new Subscriber1();
            subject.Subscribe(subscriber1);

            var subscriber2 = new Subscriber2();
            subject.Subscribe(subscriber2);

            subject.StreamerWentLive();
            subject.StreamerWentLive();

            Console.WriteLine();
            Console.WriteLine(" Subscriber 1 Unsubscribe");
            subject.Unsubscribe(subscriber1);

            subject.StreamerWentLive();
        }
    }
}