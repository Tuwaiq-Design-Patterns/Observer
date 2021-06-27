using System;

namespace SnapchatObserver
{
    public class FollowerA : IFollower
    {
        public void Update(ISnapchatAlert snapchatAlert)
        {
            Console.WriteLine("FollowerA: Notified about New Snap.");
        }
    }
}