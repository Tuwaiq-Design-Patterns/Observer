using System;
using System.Collections.Generic;
using System.Threading;

namespace SnapchatObserver
{
    public class SnapchatAlert : ISnapchatAlert
    {
        private int snapState = 0;

        private List<IFollower> _followers = new List<IFollower>();
        
        
        public void Follow(IFollower follower)
        {
            this._followers.Add(follower);
            Console.WriteLine("New Follower");
        }

        public void UnFollow(IFollower follower)
        {
            this._followers.Remove(follower);
            Console.WriteLine("Unfollowed");
        }

        public void Notify()
        {
            Console.WriteLine("Notify Followers");

            foreach (var follower in _followers)
            {
                follower.Update(this);
            }
        }

        public void SnapchatterAddedSnaps()
        {
            Console.WriteLine("SnapChatter Added new Snaps");
            this.snapState++;
            Thread.Sleep(20);

            Console.WriteLine("Snapchatter Snap State changed to: " + this.snapState);
            this.Notify();
        }
    }
}