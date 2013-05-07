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
           CurrentSession.Commit();
           CurrentSession.Dispose();
        }


        public void CommitWithoutDispose()
        {
            if (sessionFactory == null)
            {
                return;
            }
            CurrentSession.Commit();
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