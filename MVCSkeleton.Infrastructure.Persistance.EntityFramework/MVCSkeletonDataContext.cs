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

        public MVCSkeletonDataContext(TransactionScope transactionScope)
            : base(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
        {
            _transactionScope = transactionScope;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new MenuItemMapping());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (_transactionScope != null)
            {
                _transactionScope.Dispose();
            }

        }

        public void Commit()
        {
            if (_transactionScope != null)
            {
                _transactionScope.Complete();
            }
        }
    }
}