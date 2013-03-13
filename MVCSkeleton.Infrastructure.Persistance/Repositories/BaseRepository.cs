using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.IOC;
using NHibernate;

namespace MVCSkeleton.Infrastructure.Persistance.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : IAggregateRoot
    {
        private readonly SessionAdapter _sessionAdapter;

        protected BaseRepository(): this(IOCProvider.Instance.Get<SessionAdapter>())
        {
        }

        private BaseRepository(SessionAdapter sessionAdapter)
        {
            _sessionAdapter = sessionAdapter;
        }

        protected ISession Session
        {
            get { return _sessionAdapter.CurrentSession; }
        }

        public void Save(T domainObject) 
        {
            Session.Save(domainObject);
        }
    }
}