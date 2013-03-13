namespace MVCSkeleton.ApplicationInterfaces
{
    public interface ISessionService
    {
        void Commit();

        void Rollback();
    }
}