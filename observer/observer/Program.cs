using System;
using System.Collections.Generic;

namespace observer
{
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    public class Subject : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private string ProductName { get; set; }
        private int ProductPrice { get; set; }
        private string Availability { get; set; }
        public Subject(string productName, int productPrice, string availability)
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
            NotifyObservers();
        }
        public void RegisterObserver(IObserver observer)
        {
            Console.WriteLine("Observer: " + ((Observer)observer).UserName);
            observers.Add(observer);
        }
        public void AddObservers(IObserver observer)
        {
            observers.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
        public void NotifyObservers()
        {
            Console.WriteLine("Product Name :"
                            + ProductName + ", product Price : "
                            + ProductPrice + " is available. sending notifications to users");
            Console.WriteLine();
            foreach (IObserver observer in observers)
            {
                observer.update(Availability);
            }
        }
    }
    public interface IObserver
    {
        void update(string availability);
    }
    public class Observer : IObserver
    {
        public string UserName { get; set; }
        public Observer(string userName, ISubject subject)
        {
            UserName = userName;
            subject.RegisterObserver(this);
        }

        public void update(string availabiliy)
        {
            Console.WriteLine("Hello " + UserName + ", Product is now " + availabiliy + " on ColourPop");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Create a Product with Out Of Stock Status
            Subject DisneyPalette = new Subject("Disney Palette", 10000, "Out Of Stock");
            Observer user1 = new Observer("Sara", DisneyPalette);
            Observer user2 = new Observer("Areej", DisneyPalette);

            Console.WriteLine("Disney palette current state : " + DisneyPalette.getAvailability());
            Console.WriteLine();
            // Now product is available
            DisneyPalette.setAvailability("Available");
        }
    }
}
