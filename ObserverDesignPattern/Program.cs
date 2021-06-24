using System;
using System.Collections.Generic;

namespace ObserverDesignPattern
{
    class Program
    {
        /*
         WhatsAppBroadcast
        IPerson
        Person
         */

        interface IPerson
        {
            public void NewMessageNotify(string message);
        }

        class Person : IPerson
        {
            public void NewMessageNotify(string message)
            {
                Console.WriteLine("I'm a person in the broadcast list and I received this message ["+message+"]");
            }
        }

        class WhatsAppBroadcast
        {
            private List<IPerson> _people { get; set; } = new List<IPerson>();
            public void AddPerson(IPerson person)=> _people.Add(person);
            public void RemovePerson(IPerson person)=> _people.Remove(person);
            public void SendMessage(string message)
            {
                foreach (var person in _people) person.NewMessageNotify(message);
            }
        }

        static void Main(string[] args)
        {
            var broadcast = new WhatsAppBroadcast();
            broadcast.AddPerson(new Person());
            broadcast.AddPerson(new Person());
            broadcast.AddPerson(new Person());
            broadcast.AddPerson(new Person());

            broadcast.SendMessage("Hi!");
        }
    }
}
