using System;
using System.Configuration;
using System.Data.Entity;
using System.Transactions;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework.FluentMappings;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework
{
    public class MVCSkeletonDataContext : DbContext
    {
        private readonly TransactionScope _transactionScope;

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
            _transactionScope.Dispose();
        }

        public void Commit()
        {
            _transactionScope.Complete();
        }
    }
}