using System;
using System.Collections.Generic;

namespace Observer
{

    public interface ITawakkalnaApp
    {
        void SignUp(ITawakkalnaUser user);

        void DeleteAccount(ITawakkalnaUser user);

        void Notify();
    }




    public class TawakkalnaApp : ITawakkalnaApp
    {
        public double version { get; set; }

        private List<ITawakkalnaUser> _tawakkalnaUsers = new List<ITawakkalnaUser>();

        public void SignUp(ITawakkalnaUser user)
        {
            Console.WriteLine("Tawakkalna: user just Signed Up");
            this._tawakkalnaUsers.Add(user);
        }

        public void DeleteAccount(ITawakkalnaUser user)
        {
            this._tawakkalnaUsers.Remove(user);
            Console.WriteLine($"\nTawakkalna: a '{user.GetType().Name}' user has just deleted his Account");
        }

        // Trigger an update in each subscriber.
        public void Notify()
        {
            Console.WriteLine("Tawakkalna: Notifying users...");

            foreach (var user in _tawakkalnaUsers)
            {
                user.Update(this);
            }
        }

        public void FeatureUpdate()
        {
            this.version += 1;

            Console.WriteLine("Tawakkalna: The new Feature of Tawakkalna has been released with version #" + this.version.ToString());
            this.Notify();
        }

        public void BugFixUpdate()
        {
            this.version += 0.1;

            Console.WriteLine("Tawakkalna: There was bugFix of Tawakkalna and  a new release  has been published with version # " + this.version.ToString().Substring(0, 3));
            this.Notify();
        }
    }
}
