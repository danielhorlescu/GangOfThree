using System.Configuration;
using System.Data.Entity;
using System.Threading;
using System.Transactions;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework.FluentMappings;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework
{
    public class MVCSkeletonDataContext : DbContext
    {
        private TransactionScope _transactionScope;

        public MVCSkeletonDataContext()
            : base(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
        {
            _transactionScope = new TransactionScope();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Configurations.Add(new UserMapping());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            int managedThreadId = Thread.CurrentThread.ManagedThreadId;
            int hashCode = this.GetHashCode();
            _transactionScope.Dispose();
        }

        public void Commit()
        {
            int managedThreadId = Thread.CurrentThread.ManagedThreadId;
            int hashCode = this.GetHashCode();
           _transactionScope.Complete();
        }
    }
}