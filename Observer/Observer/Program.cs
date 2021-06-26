using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {

        public interface IObserver
        {
            public void update();
        }

        public interface IObservable
        {
            public void subscribe(IObserver obs);
            public void unsubscribe(IObserver obs);
            public void notify();
        }

        public class XboxLive : IObservable
        {

            private List<IObserver> _observers = new List<IObserver>();


            public void notify()
            {
                Console.WriteLine("Notifying every subscriber...");
                foreach (var obs in _observers)
                {
                    obs.update();
                }
            }

            public void subscribe(IObserver obs)
            {
                Console.WriteLine("User Subscribed");
                _observers.Add(obs);
            }

            public void unsubscribe(IObserver obs)
            {
                Console.WriteLine("User Unsubscribed");
                _observers.Remove(obs);
            }
        }

        public class Pc_Player : IObserver
        {
            public XboxLive xlive = new XboxLive();
            public Pc_Player(XboxLive xlive)
            {
                this.xlive = xlive;
            }

            public void update()
            {
                Console.WriteLine("New pc game update!");
            }
        }

        public class Xb_Player : IObserver
        {
            public XboxLive xlive = new XboxLive();
            public Xb_Player(XboxLive xlive)
            {
                this.xlive = xlive;
            }
            public void update()
            {
                Console.WriteLine("New xbox game update!");
            }
        }

        static void Main(string[] args)
        {
            XboxLive xlive = new XboxLive();

            Pc_Player player = new Pc_Player(xlive);
            Pc_Player player2 = new Pc_Player(xlive);
            Pc_Player player3 = new Pc_Player(xlive);
            Xb_Player playerx = new Xb_Player(xlive);

            xlive.subscribe(player);
            xlive.subscribe(player2);
            xlive.subscribe(player3);
            xlive.subscribe(playerx);

            xlive.notify();

            xlive.unsubscribe(player2);

            xlive.notify();

        }
    }
}