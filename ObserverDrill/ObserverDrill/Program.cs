using System;
using System.Collections.Generic;

namespace ObserverDrill
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var alarm = new Alarm();
            alarm.AddWatcher(new FireStation());
            alarm.AddWatcher(new PoliceStation());
            alarm.Notify();
        }
    }

    public class Alarm
    {
        private readonly List<IWatcher<Alarm>> watchers = new();

        public void AddWatcher(IWatcher<Alarm> alarmWatcher)
        {
            watchers.Add(alarmWatcher);
        }

        public void RemoveWatcher(IWatcher<Alarm> alarmWatcher)
        {
            watchers.Remove(alarmWatcher);
        }

        public void Notify()
        {
            foreach (var w in watchers) w.Alert(this);
        }
    }

    public interface IWatcher<T>
    {
        public void Alert(T value);
    }

    public class FireStation : IWatcher<Alarm>
    {
        public void Alert(Alarm value)
        {
            Console.WriteLine("Fire station Responding");
        }
    }

    public class PoliceStation : IWatcher<Alarm>
    {
        public void Alert(Alarm value)
        {
            Console.WriteLine("Police station Responding");
        }
    }
}