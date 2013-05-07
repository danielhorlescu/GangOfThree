using System.Configuration;
using System.Data.Entity;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework.FluentMappings;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework
{
    public class MVCSkeletonDataContext : DbContext
    {

        public MVCSkeletonDataContext()
            : base(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new MenuItemMapping());
            modelBuilder.Configurations.Add(new CustomerMapping());

        }

        public void Commit()
        {
            SaveChanges();
        }
    }
}