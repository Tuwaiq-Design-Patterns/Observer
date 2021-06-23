using System;
using System.Collections.Generic;
using System.Linq;

namespace ObserverPractice
{
    public interface IFollower
    {
        public void Update(string tweet);
    }
    
    public class Follower : IFollower
    {
        private readonly string _name;
        private readonly List<string> _followedUsersTweets = new();

        public Follower(string name)
        {
            _name = name;
        }
        
        public void Update(string tweet)
        {
            Console.WriteLine($"Follower({_name}) Received new tweet: " + tweet);
            _followedUsersTweets.Add(tweet);
        }

        public List<string> GetTweets()
        {
            return _followedUsersTweets;
        }
    }

    public class User
    {
        private readonly string _name;
        private readonly List<IFollower> _followers = new();
        private readonly List<string> _tweets = new();

        public User(string name)
        {
            _name = name;
        }
        
        public void AddTweet(string tweet)
        {
            Console.WriteLine($"User({_name}): adding new tweet: {tweet}");
            _tweets.Add(tweet);
            
            Console.WriteLine($"User({_name}): notifying all followers");
            Notify();
        }

        public void AddFollower(IFollower follower)
        {
            _followers.Add(follower);
        }

        public void RemoveFollower(IFollower follower)
        {
            _followers.Remove(follower);
        }

        private void Notify()
        {
            foreach (var follower in _followers)
                follower.Update(_tweets.Last());
        }

        public List<string> GetTweets()
        {
            return _tweets;
        }
    }
    
    public class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Ahmed");
            Follower khaled = new Follower("khaled");
            Follower saeed = new Follower("saeed");
            
            user.AddFollower(khaled);
            user.AddFollower(saeed);
            
            Console.WriteLine();
            user.AddTweet("This is my first tweet");
            Console.WriteLine();
            user.AddTweet("This is my second tweet");
            Console.WriteLine();
            user.AddTweet("This is my third tweet");
        }
    }
}