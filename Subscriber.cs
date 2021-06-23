using static System.Console;

namespace Observer
{
    public class Subscriber
    {
        private string _message;

        public Subscriber()
        {
            _message = "";
        }

        public void Update(string newState)
        {
            _message = newState;
        }
        public void Print()
        {
            WriteLine("Message -> {0}", _message);
        }
    }
}