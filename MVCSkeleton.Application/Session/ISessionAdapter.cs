namespace MVCSkeleton.Application.Session
{
    public interface ISessionAdapter
    {
        void Commit();

        void Dispose();
        /// <summary>
        /// Use only in tests
        /// </summary>
        void CommitWithoutDispose();
    }
}