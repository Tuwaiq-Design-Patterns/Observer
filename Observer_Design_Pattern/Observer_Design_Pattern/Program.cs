using System;
using System.Collections.Generic;

namespace Observer_Design_Pattern
{
    public interface ISubscriber
    {
       
        void Update(NewsPublisher newsPublisher);
    }

   
    public class NewsPublisher
    {
        private List<ISubscriber> _subscribers = new List<ISubscriber>();


        public int NumberOfPeople { get; set; } = -0;
        public string LastestNews { get; set; }

        public void Attach(ISubscriber subscriber)
        {
           
            this._subscribers.Add(subscriber);
        }

        public void Detach(ISubscriber subscriber)
        {
            this._subscribers.Remove(subscriber);
        
        }

        // Trigger an update in each subscriber.
        public void Notify()
        {
           

            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(this);
            }
        }

       
        public void AddNews(String LastestNews,int NumberOfPeople)
        {
            this.NumberOfPeople = NumberOfPeople;
            this.LastestNews = LastestNews;
            this.Notify();
        }
    }

    
    class SMSSubscriber : ISubscriber
    {
        public void Update(NewsPublisher subject)
        {
            if (subject.NumberOfPeople <= 10)
            {
                Console.WriteLine("SMSSubscriber users "+ subject.NumberOfPeople + " get this NEWs :"+ subject.LastestNews);
            }
        }
    }

    class EmailSubscriber : ISubscriber
    {
        public void Update(NewsPublisher subject)
        {
            if (subject.NumberOfPeople > 10)
            {
                Console.WriteLine("EmailSubscriber users " + subject.NumberOfPeople + " get this NEWs :" + subject.LastestNews);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

          
            
            // The client code.
            var subject = new NewsPublisher();
            var SMS = new SMSSubscriber();
            subject.Attach(SMS);

            var Email = new EmailSubscriber();
            subject.Attach(Email);

            subject.AddNews("News 1",4);
            subject.AddNews("News 2", 14);

           
        }
    }
}
