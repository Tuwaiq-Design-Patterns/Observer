using System;

namespace SnapchatObserver
{
    public class FollowerB : IFollower
    {
        public void Update(ISnapchatAlert snapchatAlert)
        {
            Console.WriteLine("FollowerB: Notified about New Snap.");
        }
    }
}