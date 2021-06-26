using System;
using System.Collections.Generic;
using System.Threading;

namespace RefactoringGuru.DesignPatterns.Observer.Conceptual
{
    public interface ISubscriber
    {

        void Update(IYoutubeAlerts subject);
    }

    public interface IYoutubeAlerts
    {

        void Attach(ISubscriber subscriber);


        void Detach(ISubscriber subscriber);


        void Notify();
    }



    public class YoutubeAlerts : IYoutubeAlerts
    {


        public int State { get; set; } = -0;



        private List<ISubscriber> _subscribers = new List<ISubscriber>();


        public void Attach(ISubscriber subscriber)
        {
            Console.WriteLine("YoutubeAlerts: Attached an subscriber.");
            this._subscribers.Add(subscriber);
        }

        public void Detach(ISubscriber subscriber)
        {
            this._subscribers.Remove(subscriber);
            Console.WriteLine("YoutubeAlerts: Detached an subscriber.");
        }


        public void Notify()
        {
            Console.WriteLine("YoutubeAlerts: Notifying subscribers...");

            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(this);
            }
        }





        public void ChannelUploadedVideo()
        {
            Console.WriteLine("\nYoutubeAlerts: channel uplaoded a video.");
            this.State++;

            Thread.Sleep(15);

            Console.WriteLine("YoutubeAlerts: My state has just changed to: " + this.State);
            this.Notify();
        }
    }



    class SubscriberA : ISubscriber
    {
        public void Update(IYoutubeAlerts subject)
        {

            Console.WriteLine("SubscriberA: Recived a notification message.");
            
        }
    }

    class SubscriberB : ISubscriber
    {
        public void Update(IYoutubeAlerts subject)
        {

            Console.WriteLine("SubscriberB: Recived a notification message.");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var subject = new YoutubeAlerts();
            var subscriberA = new SubscriberA();
            subject.Attach(subscriberA);

            var subscriberB = new SubscriberB();
            subject.Attach(subscriberB);

            subject.ChannelUploadedVideo();
            subject.ChannelUploadedVideo();

            Console.WriteLine("\nDetach Subscriber B");
            subject.Detach(subscriberB);

            subject.ChannelUploadedVideo();
        }
    }
}