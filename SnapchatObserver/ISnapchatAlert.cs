namespace SnapchatObserver
{
    public interface ISnapchatAlert
    {
        void Follow(IFollower follower);
        
        void UnFollow(IFollower follower);

        void Notify();
    }
}