using System;
using System.Collections.Generic;

namespace ObserverPractice
{
    class Program
    {

        public interface IObserver
        {
            public void update();
        }

        public interface IObservable
        {
            public void subscribe(IObserver ob);
            public void unsubscribe(IObserver ob);
            public void notify();
        }

        public class PlaystationStore : IObservable
        {

            private List<IObserver> _observers = new List<IObserver>();
            private string game = "some new amazing PS game";


            public void notify()
            {
                Console.WriteLine("Notifying every subscriber...");
                foreach (var ob in _observers)
                {
                    ob.update();
                }
            }

            public void subscribe(IObserver ob)
            {
                Console.WriteLine("a Player has Subscribed");
                _observers.Add(ob);
            }

            public void unsubscribe(IObserver ob)
            {
                Console.WriteLine("a Player has Unsubscribed");
                _observers.Remove(ob);
            }

            public string newGame()
            {
                return this.game;
            }
        }

        public class PS_Player : IObserver
        {
            public PlaystationStore psn = new PlaystationStore();
            public PS_Player(PlaystationStore psn)
            {
                this.psn = psn;
            }
            //this will be called when there is an update in the store...
            public void update()
            {
                Console.WriteLine("hey! I got the new update! it's: " + this.psn.newGame()) ;
            }
        }

        public class XB_Player : IObserver
        {
            public void update()
            {
                throw new NotImplementedException();
            }
        }

        static void Main(string[] args)
        {
            PlaystationStore psn = new PlaystationStore();

            PS_Player player = new PS_Player(psn);
            PS_Player player2 = new PS_Player(psn);
            PS_Player player3 = new PS_Player(psn);

            psn.subscribe(player);
            psn.subscribe(player2);
            psn.subscribe(player3);

            psn.notify();

            Console.WriteLine("=====================");
            psn.unsubscribe(player2);

            psn.notify();

        }
    }
}
