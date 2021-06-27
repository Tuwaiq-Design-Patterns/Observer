using ObserverDesignPattren;
using System;
using System.Collections.Generic;

namespace ObserverDesignPattren
{

    public interface IAmazon
    {
        void RegisterUsers(IUser user);
        void Notify();
    }

    public interface IUser
    {
        void Update(string availability);
    }

    public class SubjectAmazon : IAmazon
        {
            private List<IUser> users = new List<IUser>();
            private string ProductName { get; set; }
            private int ProductPrice { get; set; }
            private string Availability { get; set; }
            public SubjectAmazon(string productName, int productPrice, string availability)
            {
                ProductName = productName;
                ProductPrice = productPrice;
                Availability = availability;
            }

            public string getAvailability()
            {
                return Availability;
            }
            public void setAvailability(string availability)
            {
                this.Availability = availability;
                Console.WriteLine("Availability changed from Out of Stock to Available.");
                Notify();
            }
            public void RegisterUsers(IUser user)
            {
                Console.WriteLine("User added : " + ((User)user).UserName);
                users.Add(user);
            }
            public void AddUsers(IUser user)
            {
                users.Add(user);
            }

            public void Notify()
            {
                Console.WriteLine("Product Name :" + ProductName + ", product Price : " + ProductPrice + " is Now available. (send notify to all users) ");
                
                Console.WriteLine("------------------------------------------------");

                foreach (IUser user in users)
                {
                    user.Update(Availability);
                }
            }
        }
    }


    public class User : IUser
{
    public string UserName { get; set; }
    public User(string userName, IAmazon subject)
    {
        UserName = userName;
        subject.RegisterUsers(this);
    }

    public void Update(string availabiliy)
    {
        Console.WriteLine(UserName + ", Product is now " + availabiliy + " on Amazon");
    }
    }

    class Program
    {
    static void Main(string[] args)
    {
        SubjectAmazon Iphone = new SubjectAmazon("Iphone", 3500, "Out Of Stock");

        User user1 = new User("Norah", Iphone);

        User user2 = new User("Taif", Iphone);

        User user3 = new User("Afraa", Iphone);

        Console.WriteLine("Iphone Availability : " + Iphone.getAvailability());

        Console.WriteLine("------------------------------------------------");

        Iphone.setAvailability("Available");



    }
}

