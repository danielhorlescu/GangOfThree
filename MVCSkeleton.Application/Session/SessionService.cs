using MVCSkeleton.ApplicationInterfaces;

namespace MVCSkeleton.Application.Session
{
    public class SessionService : ISessionService
    {
        private readonly ISessionAdapter _sessionAdapter;

        public SessionService(ISessionAdapter sessionAdapter)
        {
            _sessionAdapter = sessionAdapter;
        }

        public void Commit()
        {
            _sessionAdapter.Commit();
        }

        public void Rollback()
        {
            _sessionAdapter.Rollback();
        }
    }
}