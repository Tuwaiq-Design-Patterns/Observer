using System.Collections.Generic;

namespace ObserverDP
{
    public class BlogWriter : InotificationService
    {
        private List<IBlogReaders> lst = new List<IBlogReaders>();

        public void AddReders(IBlogReaders blogReaders)
        {
            lst.Add(blogReaders);
        }

        public void RemoveReaders(IBlogReaders blogReaders)
        {
            lst.Add(blogReaders);
        }

        public void NotifyReaders(string notificationMessage)
        {
            foreach (var reader in lst)
            {
                reader.NotificationReceived(notificationMessage);
            }
            
        }
    }
}