using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Application.Session;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.IOC;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T :class, IAggregateRoot
    {
        protected readonly MVCSkeletonDataContext context;
        private IDbSet<T> _dbSet;

        protected BaseRepository(): this(IOCProvider.Instance.Get<ISessionAdapter>())
        {
        }

        private BaseRepository(ISessionAdapter sessionAdapter)
        {
            context = ((EntityFrameworkSessionAdapter)sessionAdapter).CurrentSession;
            context.Configuration.AutoDetectChangesEnabled = true;
            _dbSet = context.Set<T>();
        }

        public IDbSet<T> Session
        {
            get { return _dbSet; }
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

        public virtual IEnumerable<T> GetAll()
        {
            return Session.ToList();
        }
    }
}