using MVCSkeleton.Application.Session;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework
{
    public class EntityFrameworkSessionAdapter : ISessionAdapter
    {
        private IDatabaseFactory sessionFactory;

        private IDatabaseFactory SessionFactory
        {
            get { return sessionFactory ?? (sessionFactory = new DatabaseFactory()); }
        }

        internal MVCSkeletonDataContext CurrentSession
        {
            get
            {
                return SessionFactory.Get();
            }
        }

        public void Commit()
        {
            if (sessionFactory == null)
            {
                return;
            }
            CurrentSession.SaveChanges();
            CurrentSession.Dispose();
        }


        public void Dispose()
        {
            if (sessionFactory == null)
            {
                return;
            }
            CurrentSession.Dispose();
            sessionFactory = null;
        }
    }
}