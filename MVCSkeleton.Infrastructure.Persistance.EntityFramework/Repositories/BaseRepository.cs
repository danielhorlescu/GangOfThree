using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Application.Session;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.IOC;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IAggregateRoot
    {
        private readonly ISessionAdapter sessionAdapter;
        protected MVCSkeletonDataContext context;
        private IDbSet<T> dbSet;

        protected BaseRepository() : this(IOCProvider.Instance.Get<ISessionAdapter>())
        {
        }

        private BaseRepository(ISessionAdapter sessionAdapter)
        {
            this.sessionAdapter = sessionAdapter;
        }

        protected IDbSet<T> Session
        {
            get
            {
                if (context == null)
                {
                    context = ((EntityFrameworkSessionAdapter) sessionAdapter).CurrentSession;
                    context.Configuration.AutoDetectChangesEnabled = true;
                    dbSet = context.Set<T>();
                }
                return dbSet;
            }
        }

        public void Save(IEnumerable<T> domainObjects)
        {
            foreach (var domainObject in domainObjects)
            {
                Save(domainObject);
            }
        }

        public void Save(T domainObject)
        {
            Session.Add(domainObject);
            context.SaveChanges();
        }

        public T Get(long id)
        {
            return Session.Find(id);
        }

        public void Delete(T domainObject)
        {
            Session.Remove(domainObject);
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return Session.ToList();
        }
    }
}