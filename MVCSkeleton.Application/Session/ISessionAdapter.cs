namespace MVCSkeleton.Application.Session
{
    public interface ISessionAdapter
    {
        void Commit();

        void CommitWithoutDispose();

        void Dispose();
    }
}