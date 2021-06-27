using System;
using System.Collections.Generic;

namespace ObserverDesignPattern
{
    interface IObserver
    {
        public void update(String name, String message);
    }
    interface ISubject
    {

        public void follow(IObserver observer);

        public void unfollow(IObserver observer);

        public void notifyObservers(String message);

    }
    
    class User : ISubject
    {
        private String userName;

        private List<IObserver> followers;   // List of subscribers

        public User(String userName)
        {
            this.userName = userName;

            followers = new List<IObserver>();
        }

        public void follow(IObserver observer)
        {
            followers.Add(observer); 
        }

        public void unfollow(IObserver observer) 
        {
            followers.Remove(observer);
        }

        public void notifyObservers(String post)
        {
            foreach (var follower in followers)
            {
                follower.update(userName, post);
            }
        }

        public void post(String post)
        {

            Console.WriteLine(userName + " has post " + post);

            notifyObservers(post);

        }

    }
    class Follower : IObserver
    {
        private String followerName;

        public Follower(String followerName)
        { 
            this.followerName = followerName; 
        }
        public void update(String userName, String post) 
        { 
            Console.WriteLine(followerName + " you have to see " +post +" by " + userName); 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User pewdiepie = new User("Pewdiepie");

            User tSeries = new User("T-Series");

            Follower leo = new Follower("leo");

            Follower misha = new Follower("misha");

            Follower joy = new Follower("Joy");

            Follower john = new Follower("john");

            pewdiepie.follow(leo);

            pewdiepie.follow(joy);

            tSeries.follow(misha);

            tSeries.follow(john);

            pewdiepie.post("New Tweet");

            tSeries.post("New Fleet");

            pewdiepie.unfollow(joy);
        }
    }
}
