using System.Collections.Generic;

namespace Observer
{
    public class Publisher
    {
        private readonly ICollection<Subscriber> _members;
        private string _mainState;
        public Publisher()
        {
            _members = new List<Subscriber>();
            _mainState = "";
        }

        public void SetState(string m)
        {
            _mainState = m;
        }

        public void Notify()
        {
            foreach (var s in _members)
            {
                s.Update(_mainState);
            }
        }

        public void Subscribe(Subscriber s)
        {
            _members.Add(s);
        }

        public void Unsubscribe(Subscriber s)
        {
            _members.Remove(s);
        }

        public void UnsubscribeAll()
        {
            _members.Clear();
        }
    }
}