using System;

namespace ObserverDP
{
    public class BlogReaders:IBlogReaders
    {
        private string _readersName;

        public BlogReaders(string readersName)
        {
            _readersName = readersName;
        }
            public void NotificationReceived(string message)
        {
            Console.WriteLine(_readersName+ " " + message);
        }
    }
}