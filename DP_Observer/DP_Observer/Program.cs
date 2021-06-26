using System;

using System.Collections.Generic;


namespace DP_Observer
{
   


    // The 'Subject' abstract class


    public abstract class Stock
    {
        //provides an interface for attaching and detaching Observer objects.
        private string symbol;
        private double price;
        private List<IInvestor> investors = new List<IInvestor>();

    

        public Stock(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }

        public void Attach(IInvestor investor)
        {
            investors.Add(investor);
        }

        public void Detach(IInvestor investor)
        {
            investors.Remove(investor);
        }

        public void Notify()
        {
            foreach (IInvestor investor in investors)
            {
                investor.Update(this);
            }

            Console.WriteLine("________________");
        }

        // Gets or sets the price (SomeBusinessLogic)

        public double Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    Notify();
                }
            }
        }

   

        public string Symbol
        {
            get { return symbol; }
        }
    }

  
    // The 'ConcreteSubject' class
 

    public class IBM : Stock
    {
        public IBM(string symbol, double price)
            : base(symbol, price)
        {
        }
    }

  
    /// The 'Observer' interface


    public interface IInvestor
    {
        void Update(Stock stock);
    }


    /// The 'ConcreteObserver' class

    public class Investor : IInvestor
    {
        private string name;
        private Stock stock;

        // Constructor

        public Investor(string name)
        {
            this.name = name;
        }

        public void Update(Stock stock)
        {
            Console.WriteLine("Notified {0} of {1}'s " +
                "change to {2:C}", name, stock.Symbol, stock.Price);
        }


        public Stock Stock
        {
            get { return stock; }
            set { stock = value; }
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            // Create IBM stock and attach investors

            IBM ibm = new IBM("IBM", 120.00);
            ibm.Attach(new Investor("Sorros"));
            ibm.Attach(new Investor("Berkshire"));

         

       
            ibm.Price = 450.00;
            ibm.Price = 300.70;
          

       

         
        }
    }
}
