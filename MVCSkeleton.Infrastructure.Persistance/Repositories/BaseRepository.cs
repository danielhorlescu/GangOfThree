using MVCSkeleton.Application.Repository;
using MVCSkeleton.Application.Session;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.IOC;
using NHibernate;

namespace MVCSkeleton.Infrastructure.Persistance.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : IAggregateRoot
    {
        private readonly SessionAdapter _sessionAdapter;

        protected BaseRepository(): this(IOCProvider.Instance.Get<ISessionAdapter>())
        {
        }

        private BaseRepository(ISessionAdapter sessionAdapter)
        {
            _sessionAdapter = (SessionAdapter) sessionAdapter;
        }

        protected ISession Session
        {
            get { return _sessionAdapter.CurrentSession; }
        }

        public void Save(T domainObject) 
        {
            Session.Save(domainObject);
        }

        public T Get(long id)
        {
            return Session.Get<T>(id);
        }

        public void Delete(T domainObject)
        {
            Session.Delete(domainObject);
        }
    }
}