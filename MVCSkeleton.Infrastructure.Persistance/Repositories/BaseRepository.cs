using System.Collections.Generic;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Application.Session;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.IOC;
using NHibernate;

namespace MVCSkeleton.Infrastructure.Persistance.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : IAggregateRoot
    {
        private readonly NHiberanteSessionAdapter nHiberanteSessionAdapter;

        protected BaseRepository(): this(IOCProvider.Instance.Get<ISessionAdapter>())
        {
        }

        private BaseRepository(ISessionAdapter sessionAdapter)
        {
            nHiberanteSessionAdapter = (NHiberanteSessionAdapter) sessionAdapter;
        }

        protected ISession Session
        {
            get { return nHiberanteSessionAdapter.CurrentSession; }
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

        public void Save(IEnumerable<T> domainObjects)
        {
            throw new System.NotImplementedException();
        }
    }
}