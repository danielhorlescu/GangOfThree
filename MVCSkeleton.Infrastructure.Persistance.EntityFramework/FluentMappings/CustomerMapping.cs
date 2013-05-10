using MVCSkeleton.Domain;
using System.Data.Entity.ModelConfiguration;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework.FluentMappings
{
    internal class CustomerMapping : EntityTypeConfiguration<Customer>
    {
        public CustomerMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.AddressId).HasMaxLength(100);
            Property(x => x.Name).HasMaxLength(50).IsRequired();
            Property(x => x.Surname).HasMaxLength(50).IsRequired();
        }
    }
}
