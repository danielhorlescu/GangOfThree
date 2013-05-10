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
        private readonly NHiberanteSessionAdapter _nHiberanteSessionAdapter;

        protected BaseRepository(): this(IOCProvider.Instance.Get<ISessionAdapter>())
        {
        }

        private BaseRepository(ISessionAdapter sessionAdapter)
        {
            _nHiberanteSessionAdapter = (NHiberanteSessionAdapter) sessionAdapter;
        }

        protected ISession Session
        {
            get { return _nHiberanteSessionAdapter.CurrentSession; }
        }

        public T Save(T domainObject) 
        {
            Session.Save(domainObject);
            return domainObject;
        }

        public T Get(long id)
        {
            return Session.Get<T>(id);
        }

        public void Delete(T domainObject)
        {
            Session.Delete(domainObject);
        }


        public List<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Save(System.Collections.Generic.IEnumerable<T> domainObjects)
        {
            throw new System.NotImplementedException();
        }
    }
}