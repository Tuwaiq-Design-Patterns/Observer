using System;

namespace SnapchatObserver
{
    class Program
    {
        static void Main(string[] args)
        {
            SnapchatAlert snapchatter = new SnapchatAlert();

            IFollower followerA = new FollowerA();
            snapchatter.Follow(followerA);

            IFollower followerB = new FollowerB();
            snapchatter.Follow(followerB);

            Console.WriteLine("Add new snaps");
            snapchatter.SnapchatterAddedSnaps();
            snapchatter.SnapchatterAddedSnaps();
            snapchatter.SnapchatterAddedSnaps();

            Console.WriteLine("follower A unfollow");
            snapchatter.UnFollow(followerA);

        }
    }
}