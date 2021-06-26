using System;
using System.Collections.Generic;

namespace Observer
{
    public class Subscriber
    {
        private string message;

        public Subscriber()
        {
            message = "";
        }

        public void Update(string newMsg)
        {
            message = newMsg;
        }
        public void Message()
        {
            Console.WriteLine("Message -> "+ message);
        }
    }
    public class Publisher
    {
        private readonly IList<Subscriber> members;
        
        public Publisher()
        {
            members = new List<Subscriber>();
        }

        public void Notify(string newMessage)
        {
            foreach (var s in members)
            {
                s.Update(newMessage);
            }
        }

        public void Subscribe(Subscriber sub)
        {
            members.Add(sub);
        }

        public void Unsubscribe(Subscriber sub)
        {
            members.Remove(sub);
        }

        public void UnsubscribeAll()
        {
            members.Clear();
        }
    }
    class Client
    {
        static void Main(string[] args)
        {
            var contentMaker = new Publisher();

            var subscriber_1 = new Subscriber();
            var subscriber_2 = new Subscriber();
            var subscriber_3 = new Subscriber();
            var subscriber_4 = new Subscriber();

            contentMaker.Subscribe(subscriber_1);
            contentMaker.Subscribe(subscriber_2);
            contentMaker.Subscribe(subscriber_3);
            contentMaker.Subscribe(subscriber_4);

            Console.WriteLine("Before Sending Notifications ...");
            subscriber_1.Message();
            subscriber_2.Message();
            subscriber_3.Message();
            subscriber_4.Message();

            Console.WriteLine();

            contentMaker.Notify("!!! BREAKING NEWS !!!");

            Console.WriteLine("After Sending Notifications ...");
            subscriber_1.Message();
            subscriber_2.Message();
            subscriber_3.Message();
            subscriber_4.Message();
        }
    }
}