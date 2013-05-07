using MVCSkeleton.Presentation.ApplicationInterfaces;

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

        public void Dispose()
        {
            _sessionAdapter.Dispose();
        }
    }
}