using System;
using System.Collections.Generic;

namespace Observer
{

    class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject();

            new Hexobserver(subject);
            new Octalobserver(subject);

            Console.WriteLine("First state change: 15");
            subject.setState(13);
            Console.WriteLine("First state change: 30");
            subject.setState(50);


        }
    }

    // Subject
    public class Subject
    {
        private List<Observer> observers = new List<Observer>();
        private int state;
        
        public int getState()
        {
            return state;
        }

        public void setState(int state)
        {
            this.state = state;
            notifyAlloobservers();
            
        }

        public void attach(Observer observer)
        {
            observers.Add(observer);

        }

        public void notifyAlloobservers()
        {
            foreach (Observer observer in observers)
            {
                observer.update();
            }

        }
    }
    // Observer
    public abstract  class Observer
    {
        public Subject subject;
        abstract public void update();
    }

    // Octalobserver
    public class Octalobserver : Observer
    {

        public Octalobserver(Subject subjectin)
        {
            this.subject = subjectin;
            this.subject.attach(this);
        }
        public override void update()
        {
            Console.WriteLine("convert to Octal String: " + this.subject.getState());
        }
    }

    // Hexobserver

    public class Hexobserver : Observer
    {

        public Hexobserver(Subject subjectin)
        {
            this.subject = subjectin;
            this.subject.attach(this);
        }
        public override void update()
        {
            Console.WriteLine("convert to hex String: " + this.subject.getState());
        }
    }
    
}
