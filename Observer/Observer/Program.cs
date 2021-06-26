using System;
using System.Collections.Generic;

namespace Observer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GulfDrug gulfDrug = new GulfDrug("GulfDrug", 120.00);
            gulfDrug.Attach(new Pharmacy("Al Nahdi"));
            gulfDrug.Attach(new Pharmacy("Al Dawaa"));
            
            gulfDrug.Price = 120.10;
            gulfDrug.Price = 121.00;
            gulfDrug.Price = 120.50;
            gulfDrug.Price = 120.75;

            Console.ReadKey();
        }
    }
 
    public abstract class PharmaSupplier
    {
        private string symbol;
        private double price;
        private List<IPharmacy> pharmacies = new List<IPharmacy>();
        public PharmaSupplier(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }
        public void Attach(IPharmacy pharmacy)
        {
            pharmacies.Add(pharmacy);
        }
        public void Detach(IPharmacy pharmacy)
        {
            pharmacies.Remove(pharmacy);
        }
        public void Notify()
        {
            foreach (IPharmacy pharmacy in pharmacies)
            {
                pharmacy.Update(this);
            }
            Console.WriteLine("");
        }
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
    
    public class GulfDrug : PharmaSupplier
    {
        public GulfDrug(string symbol, double price)
            : base(symbol, price)
        {
        }
    }
   
    public interface IPharmacy
    {
        void Update(PharmaSupplier pharmaSupplier);
    }
    
    public class Pharmacy: IPharmacy
    {
        private string name;
        private PharmaSupplier pharmaSupplier;
        public Pharmacy(string name)
        {
            this.name = name;
        }
        public void Update(PharmaSupplier pharmaSupplier)
        {
            Console.WriteLine("Notification is sent to {0} from {1}'s " +
                "about medicine price change to {2:C}", name, pharmaSupplier.Symbol, pharmaSupplier.Price);
        }
        public PharmaSupplier PharmaSupplier
        {
            get { return pharmaSupplier; }
            set { pharmaSupplier = value; }
        }
    }
}
