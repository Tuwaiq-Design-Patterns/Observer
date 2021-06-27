using System;
using System.Collections.Generic;

namespace ObserverDrill
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var blogger = new Blogger();
            blogger.AddSubscriber(new EmailSubscriber());
            blogger.AddSubscriber(new RssSubscriber());
            blogger.Notify( "GG" );
        }
    }

    public class Blogger
    {
        private readonly List<ISubscriber<string>> subscribers = new();
        public void AddSubscriber(ISubscriber<string> sub)
            => subscribers.Add(sub);

        public void RemoveSubscriber(ISubscriber<string> sub) 
            => subscribers.Remove(sub);

        public void Notify( string newPost )
        { 
            foreach (var s in subscribers) s.Update(newPost);
        }
        
    }

    public interface ISubscriber<T>
    {
        public void Update(T value);
    }

    public class EmailSubscriber : ISubscriber<string>
    {
        public void Update(string newPost)
        {
            Console.WriteLine("EMAIL HAS BEEN SENT");
        }
    }

    public class RssSubscriber : ISubscriber<string>
    {
        public void Update(string value)
        {
            Console.WriteLine("RSS READER IS NOTIFIED");
        }
    }
}