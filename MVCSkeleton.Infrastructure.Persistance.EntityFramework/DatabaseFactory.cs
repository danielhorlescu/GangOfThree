using System.Transactions;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private MVCSkeletonDataContext dataContext;

        public MVCSkeletonDataContext Get()
        {
            return dataContext ?? (dataContext = new MVCSkeletonDataContext(new TransactionScope()));
        }

        public void Dispose()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}