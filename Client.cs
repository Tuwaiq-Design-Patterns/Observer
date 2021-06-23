using static System.Console;

namespace Observer
{
    class Client
    {
        static void Main(string[] args)
        {
            var publisher = new Publisher();

            var subscriber1 = new Subscriber();
            var subscriber2 = new Subscriber();
            var subscriber3 = new Subscriber();
            var subscriber4 = new Subscriber();
            var subscriber5 = new Subscriber();

            publisher.Subscribe(subscriber1);
            publisher.Subscribe(subscriber2);
            publisher.Subscribe(subscriber3);
            publisher.Subscribe(subscriber4);
            publisher.Subscribe(subscriber5);

            WriteLine("\nBefore notifying subscribers...");
            subscriber1.Print();
            subscriber2.Print();
            subscriber3.Print();

            publisher.SetState("This is a new message.");
            publisher.Notify();

            WriteLine("\nAfter notifying subscribers...");
            subscriber1.Print();
            subscriber2.Print();
            subscriber3.Print();
        }
    }
}
