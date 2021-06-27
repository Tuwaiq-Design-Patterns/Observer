
using System;
using System.Collections.Generic;
using System.Threading;
namespace ObserverDesignPattern
{

    public interface IFollower
    {
        // Receive update from Account
        void Update(IAccount account);
    }

    public interface IAccount
    {
        // Attach an Follower to the Accounet.
        void Attach(IFollower follower);

        // Detach an follower from the subject.
        void Detach(IFollower follower);

        // Notify all followers about an a new twitte.
        void Notify();
    }

    // state changes.
    public class Account : IAccount
    {
       
        public int State { get; set; } = -0;

        // List of subscribers. In real life, the list of subscribers can be
        // stored more comprehensively (categorized by event type, etc.).
        private List<IFollower> _followers = new List<IFollower>();

        // The subscription management methods.
        public void Attach(IFollower follower)
        {
            Console.WriteLine("Account: Attached an Follower.");
            this._followers.Add(follower);
        }

        public void Detach(IFollower follower)
        {
            this._followers.Remove(follower);
            Console.WriteLine("Account: Detached an follower.");
        }

        // Trigger an update in each Followers.
        public void Notify()
        {
            Console.WriteLine("Account: Notifying Followers Abount a new Tweet...");

            foreach (var follower in _followers)
            {
                follower.Update(this);
            }
        }

  
        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nAccount:cHave a nice day ");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Account: I have a new Tweet : " + this.State);
            this.Notify();
        }
    }

    // Concrete Observers follower  react to the updates  by the Account they had
    // been attached to.
    class ConcretefollowerA : IFollower
    {
        public void Update(IAccount account)
        {
            if ((account as Account).State < 3)
            {
                Console.WriteLine("Concretefollower A: Reacted a notfication for new Tweet from Account .");
            }
        }
    }

    class ConcretefollowerB : IFollower
    {
        public void Update(IAccount account)
        {
            if ((account as Account).State == 0 || (account as Account).State >= 2)
            {
                Console.WriteLine("ConcretefollowerB: Reacted a notfication for new Tweet from Account.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // The client code.
            var account = new Account();
            var FollowerA = new ConcretefollowerA();
            account.Attach(FollowerA);

            var FollowerB = new ConcretefollowerB();
            account.Attach(FollowerB);

            account.SomeBusinessLogic();
            account.SomeBusinessLogic();

            account.Detach(FollowerB);

            account.SomeBusinessLogic();
        }
    }

}

