using System;
using System.Collections;


namespace ObserverDP
{
    public abstract class Subject
    {
        private ArrayList observers = new ArrayList();

        public void Attach(IObserver o)
        {
            observers.Add(o);
        }
        
        public void Detach(IObserver o)
        {
            observers.Remove(o);
        }

        public void Notify()
        {
            foreach (IObserver o in observers)
            {
                o.Update();
            }
        }
    }

    public class ConcreteSubject : Subject
    {
        private string state;

        public string GetState()
        {
            return state;
        }

        public void SetState(string newState)
        {
            state = newState;
            Notify();
        }
    }

    public interface IObserver
    {
        void Update();
    }

    public class ConcreteObserver : IObserver
    {
        private ConcreteSubject subject;

        public ConcreteObserver(ConcreteSubject sub)
        {
            subject = sub;
        }

        public void Update()
        {
            string subjectState = subject.GetState();
            Console.WriteLine(subjectState);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ConcreteSubject sub = new ConcreteSubject();

            ConcreteObserver observer1 = new ConcreteObserver(sub);
            ConcreteObserver observer2 = new ConcreteObserver(sub);

            sub.Attach(observer1);
            sub.Attach(observer2);


            sub.SetState("notify test");

            sub.Detach(observer2);
            sub.SetState("observer 2 unsubscribed and observer1 notifed");
          
        }
    }
}
