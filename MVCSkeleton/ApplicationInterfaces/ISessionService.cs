namespace MVCSkeleton.Presentation.ApplicationInterfaces
{
    public interface ISessionService
    {
        void Commit();

        void Rollback();
    }
}