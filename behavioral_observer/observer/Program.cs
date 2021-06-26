using System;
using System.Collections.Generic;

namespace observer
{
    class Program
    {
        /// The Subject abstract class
        
        abstract class Veggies
        {
            private double _pricePerPound;
            private List<IRestaurant> _restaurants = new List<IRestaurant>();

            public Veggies(double pricePerPound)
            {
                _pricePerPound = pricePerPound;
            }

            public void Attach(IRestaurant restaurant)
            {
                _restaurants.Add(restaurant);
            }

            public void Detach(IRestaurant restaurant)
            {
                _restaurants.Remove(restaurant);
            }

            public void Notify()
            {
                foreach (IRestaurant restaurant in _restaurants)
                {
                    restaurant.Update(this);
                }

                Console.WriteLine("");
            }

            public double PricePerPound
            {
                get { return _pricePerPound; }
                set
                {
                    if (_pricePerPound != value)
                    {
                        _pricePerPound = value;
                        Notify(); //Automatically notify our observers of price changes
                    }
                }
            }
        }

        /// The Observer interface

        interface IRestaurant
        {
            void Update(Veggies veggies);
        }



        /// The ConcreteSubject class
  
        class Tomatos : Veggies
        {
            public Tomatos (double price) : base(price) { }
        }


       
        /// The ConcreteObserver class
    
        class Restaurant : IRestaurant
        {
            private string _name;
            private Veggies _veggie;
            private double _purchaseThreshold;

            public Restaurant(string name, double purchaseThreshold)
            {
                _name = name;
                _purchaseThreshold = purchaseThreshold;
            }

            public void Update(Veggies veggie)
            {
                Console.WriteLine("Notified {0} of {1}'s "
                                   + " price change to {2:C} per pound.",
                                   _name, veggie.GetType().Name, veggie.PricePerPound);
                if (veggie.PricePerPound < _purchaseThreshold)
                {
                    Console.WriteLine(_name + " wants to buy some "
                                      + veggie.GetType().Name + "!");
                }
            }
        }


        static void Main(string[] args)
        {
            // Create price watch for Tomatos 
            // and attach restaurants that buy Tomatos from suppliers.
            Tomatos tomatos = new Tomatos(0.97);
            
            tomatos.Attach(new Restaurant("McDonalds", 0.87));
            tomatos.Attach(new Restaurant("Hervy", 0.84));
            tomatos.Attach(new Restaurant("AlBaik", 0.86));

            // Fluctuating tomatos prices will notify subscribing restaurants.
            tomatos.PricePerPound = 1.00;
            tomatos.PricePerPound = 0.76;
            tomatos.PricePerPound = 0.79;
            tomatos.PricePerPound = 0.89;

            Console.ReadKey();
        }
    }
}
