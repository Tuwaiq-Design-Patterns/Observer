using System;

namespace Observer
{


    class Program
    {
        static void Main(string[] args)
        {
            // The client code.
            var app = new TawakkalnaApp();
            Console.WriteLine("Users are signing up");
            Console.WriteLine("-----------------------------");

            var userA = new Citizen();
            app.SignUp(userA);

            var userB = new Alien();
            app.SignUp(userB);

            Console.WriteLine("\nUsers are receiving updates");
            Console.WriteLine("-----------------------------");

            app.FeatureUpdate();
            app.BugFixUpdate();

            app.DeleteAccount(userB);
            Console.WriteLine($"\nAfter {userB.GetType().Name} user has deleted his account, now one user is receiving updates");
            Console.WriteLine("-----------------------------");
            app.BugFixUpdate();
        }
    }
}