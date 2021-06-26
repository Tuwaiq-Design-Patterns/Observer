namespace ObserverDP
{
    public interface InotificationService
    {
        void AddReders(IBlogReaders blogReaders);
        void RemoveReaders(IBlogReaders blogReaders);
        void NotifyReaders(string notificationMessage);
    }
}