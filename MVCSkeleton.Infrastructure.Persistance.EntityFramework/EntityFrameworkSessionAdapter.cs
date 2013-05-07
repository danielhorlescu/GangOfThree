using MVCSkeleton.Application.Session;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework
{
    public class EntityFrameworkSessionAdapter : ISessionAdapter
    {
        private IDatabaseFactory sessionFactory;

        public EntityFrameworkSessionAdapter()
        {
            int a = 0;
        }

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

        public void CommitWithoutDispose()
        {
            if (sessionFactory == null)
            {
                return;
            }
            MVCSkeletonDataContext mvcSkeletonDataContext = sessionFactory.Get();
            mvcSkeletonDataContext.Commit();
        }
    }
}