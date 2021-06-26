using System;
using System.Collections.Generic;

namespace Observer
{
    //Publisher class
    public abstract class Organizer
    {
        private List<Bidder> bidders = new List<Bidder>();
        public void Subscrib(Bidder bidder)
        {
            bidders.Add(bidder);
        }
        public void Unsubscrib(Bidder bidder)
        {
            bidders.Remove(bidder);
        }
        public void Notify()
        {
            foreach(Bidder b in bidders)
            {
                b.Update();
            }
        }
    }

    //Publisher concert class
    public class CarsAuction : Organizer
    {
        private string organizerState;
        public string State
        {
            get { return organizerState; }
            set { organizerState = value; }
        }
    }

    //Observer class
    public abstract class Bidder
    {
        public abstract void Update();
    }

    //Observer concert class
    public class ConcertBidder : Bidder
    {
        private string name;
        private string bidderState;
        private CarsAuction carsAuction;

        public CarsAuction Auction
        {
            get { return carsAuction; }
            set { carsAuction = value; }
        }

        public ConcertBidder(string name, CarsAuction carsAuction)
        {
            this.name = name;
            this.carsAuction = carsAuction;
        }

        public override void Update()
        {
            bidderState = carsAuction.State;
            Console.WriteLine("Bidder Name: " + name + " his new state: " + bidderState);
        }

    }

    //Client
    class Program
    {
        static void Main(string[] args)
        {
            // Create new object from organizer concert class 
            CarsAuction SubscribWithService = new CarsAuction();
            SubscribWithService.Subscrib(new ConcertBidder("Ahmed", SubscribWithService));
            SubscribWithService.Subscrib(new ConcertBidder("Arwa", SubscribWithService));
            SubscribWithService.Subscrib(new ConcertBidder("Amal", SubscribWithService));

            // state for new added
            SubscribWithService.State = "You are now subscribed in our auction service";

            //Notify bidders
            SubscribWithService.Notify();

            //Test Unsubscrib method
            CarsAuction unSubscribWithService = new CarsAuction();

            //remove user
            unSubscribWithService.Unsubscrib(new ConcertBidder("Ahmed", unSubscribWithService));

        }
    }
}
