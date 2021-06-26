namespace ObserverDemo
{
    public interface ISubscriber
    {
        public void Update(Publisher publisher);
    }
}