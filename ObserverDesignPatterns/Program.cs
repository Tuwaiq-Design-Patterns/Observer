using System;
using System.Collections.Generic;
using System.Linq;

namespace ObserverDesignPatterns
{
    public interface IColorCollection
    {
        void Register(IObserver observer);
        void ColorAddedNotification();
    }

    public interface IObserver
    {
        void ColorAdded(string newColor);
    }

    public class ColorCollection : IColorCollection
    {
        private List<string> _colors = new();

        private List<IObserver> _observers = new();

        public void AddColor(string color)
        {
            _colors.Add(color);
            ColorAddedNotification();


        }
        public void Register(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unregister(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void ColorAddedNotification()
        {
            _observers.ToList().ForEach(o => o.ColorAdded(_colors.Last()));
        }

    }

    public class Observer : IObserver
    {
        public string ObserverName { get; set; }
        public Observer(string name)
        {
            ObserverName = name;
        }
        void IObserver.ColorAdded(string newColor)
        {
            Console.WriteLine("I am " + ObserverName + " And Color [" + newColor + "] was Added");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //registrer
            ColorCollection colorCoolection = new();

            //observers
            Observer observer1 = new("observer 1");
            Observer observer2 = new("observer 2");
            Observer observer3 = new("observer 3");

            //adding observers
            colorCoolection.Register(observer1);
            colorCoolection.Register(observer2);
            colorCoolection.Register(observer3);

            //add color
            Console.WriteLine("press Enter to add new colors");
            string input = Console.ReadLine();
            while (true)
            {
                Console.Write("\nType in your color: ");
                string color = Console.ReadLine();
                colorCoolection.AddColor(color);
            }

        }
    }
}
