using System;
using System.Collections.Generic;

namespace Observer
{
    public interface IEmployeesObserver
    {
        void Update(string availability);
    }
    public interface IJarirProduct
    {
        void AddObserver(IEmployeesObserver observer);
        void RemoveObserver(IEmployeesObserver observer);
        void NotifyObservers();
    }
    public class ObserverEmployees : IEmployeesObserver
    {
        public string Username { get; set; }
        public ObserverEmployees(string Username, IJarirProduct product)
        {
            this.Username = Username;
            product.AddObserver(this);
        }

        public void Update(string availabiliy)
        {
            Console.WriteLine("Hello " + Username + ", IPhone X is now " + availabiliy + " on Jarir");
        }
    }
    public class JarirProduct : IJarirProduct
    {
        private readonly List<IEmployeesObserver> observers = new List<IEmployeesObserver>();
        private string ProductName { get; set; }
        private string Availability { get; set; }
        public JarirProduct(string productName, string availability)
        {
            ProductName = productName;
            Availability = availability;
        }
        public void AddObserver(IEmployeesObserver observer)
        {
            this.observers.Add(observer);
        }
        public string GetAvailability()
        {
            return Availability;
        }
        public void SetAvailability(string availability)
        {
            this.Availability = availability;
            Console.WriteLine("Availability changed from Out of Stock to Available.");
            NotifyObservers();
        }
        public void NotifyObservers()
        {
            Console.WriteLine("Product Name: "
                + ProductName + " is Now available. So notify all users.");
            Console.WriteLine();
            foreach (IEmployeesObserver observer in observers)
            {
                observer.Update(Availability);
            }
        }

        public void RemoveObserver(IEmployeesObserver observer)
        {
            this.observers.Remove(observer);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            JarirProduct companyProduct = new JarirProduct("IPhone X", "Out Of Stock");
            ObserverEmployees user1 = new ObserverEmployees("Yasmin", companyProduct);
            ObserverEmployees user2 = new ObserverEmployees("Layan", companyProduct);
            companyProduct.SetAvailability("Available");

            Console.ReadKey();
        }
    }
}
