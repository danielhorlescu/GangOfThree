using System.Data.Entity.ModelConfiguration;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework.FluentMappings
{
    internal class StoreMapping: EntityTypeConfiguration<Store>
    {
        public StoreMapping()
        {
            HasKey(s => s.Id);
            Property(s => s.Name).HasMaxLength(255).IsRequired();
            Property(s => s.Email).HasMaxLength(255).IsRequired();
            Property(s => s.CreationDate).IsRequired();
            Property(s => s.LastModification).IsRequired();
        }
    }
}
