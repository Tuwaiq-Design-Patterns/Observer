using System;

using System.Collections.Generic;

namespace Observer
{
    public interface ISubscriber
    {
        void Update(IStockWatcher subscriber);
    }

    public interface IStockWatcher
    {
        void Subscribe(ISubscriber subscriber);

        void Unsubscribe(ISubscriber subscriber);
        void Orders();
    }

    public class StockWatcher : IStockWatcher
    {
        public int Stock { get; set; }
        public string Store { get; set; }

        private List<ISubscriber> _subscribers = new List<ISubscriber>();
        public void Subscribe(ISubscriber subscriber)
        {
            Console.WriteLine("The store have been added to the watch list.");
            this._subscribers.Add(subscriber);
        }
        public void Unsubscribe(ISubscriber subscriber)
        {
            this._subscribers.Remove(subscriber);
            Console.WriteLine("The store have been removed from the watch list.");
        }
        public void Orders()
        {
            Console.WriteLine("New orders detected. Mailing all subscribers.");

            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(this);
            }
        }
        public void OrdersChecker(int stock, string store)
        {
            Console.WriteLine("The orders checker is waiting for new orders.");

            this.Stock = stock;
            this.Store = store;

            Console.WriteLine("The orders checker has detected " + this.Stock + " orders for " + this.Store + " online store.");
            
            this.Orders();
        }
    }
    class JohnLewis : ISubscriber
    {
        public void Update(IStockWatcher subject)
        {
            if (( (subject as StockWatcher).Stock <= 1 ) && (subject as StockWatcher).Store.Equals("John Lewis"))
            {
                Console.WriteLine("John Lewis order detected. There are " + (subject as StockWatcher).Stock + " orders for it now!");
            }
        }
    }

    class Selfridges : ISubscriber
    {
        public void Update(IStockWatcher subject)
        {
            if (((subject as StockWatcher).Stock <= 1) && (subject as StockWatcher).Store.Equals("Selfridges"))
            {
                Console.WriteLine("Selfridges order detected. There are " + (subject as StockWatcher).Stock + " orders for it now!");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            var stockWatcher = new StockWatcher();
            var johnLewisChecker = new JohnLewis();
            stockWatcher.Subscribe(johnLewisChecker);
            var selfridgesChecker = new Selfridges();
            stockWatcher.Subscribe(selfridgesChecker);

            stockWatcher.OrdersChecker(15, "John Lewis");
            
            stockWatcher.OrdersChecker(3, "Selfridges");

            stockWatcher.Unsubscribe(selfridgesChecker);

        }
    }
}
