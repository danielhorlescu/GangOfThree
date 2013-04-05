using MVCSkeleton.Application.Session;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework
{
    public class EntityFrameworkSessionAdapter : ISessionAdapter
    {
        private IDatabaseFactory sessionFactory;

        private IDatabaseFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    sessionFactory = new DatabaseFactory();
                }
                return sessionFactory;
            }
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
            MVCSkeletonDataContext mvcSkeletonDataContext = sessionFactory.Get();
            mvcSkeletonDataContext.Commit();
            mvcSkeletonDataContext.Dispose();
        }

        public void Rollback()
        {
            if (sessionFactory == null)
            {
                return;
            }
            sessionFactory.Dispose();
        }
    }
}