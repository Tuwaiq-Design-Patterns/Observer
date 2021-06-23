using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        public interface IFollower
        {
            public void update(string state);
        }

        public class Follower : IFollower
        {
            
            public Follower() { }

            public void update(string state)
            {
                Console.WriteLine("You have a new notification: " + state);
            }
        }

        public class User
        {
            public List<IFollower> subscribers;
            public User()
            {
                subscribers = new List<IFollower>();
            }

            public void addFollower(IFollower follower)
            {
                subscribers.Add(follower);
            }

            public void removeFollower(IFollower follower)
            {
                subscribers.Remove(follower);
            }

            public void notifyAll(string state)
            {
                foreach (var subscriber in subscribers)
                {
                    subscriber.update(state);
                }
            }
        }


        static void Main(string[] args)
        {
            //Create user (Subject)
            User user = new User();

            //Create followers (Observers)
            Follower follower1 = new Follower();
            Follower follower2 = new Follower();

            //Add a follower (observers)
            user.addFollower(follower1);
            user.addFollower(follower2);

            //Notify all
            user.notifyAll("I learned something new today");

            //Remove a follower (observer)
            user.removeFollower(follower2);

            //Notify all
            user.notifyAll("The observer design pattern is very useful!");
        }
    }
}
