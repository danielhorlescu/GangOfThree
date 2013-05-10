using System.Data.Entity.ModelConfiguration;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework.FluentMappings
{
    internal class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            HasKey(p => p.Id);
            Property(p => p.CreationDate).IsRequired();
            Property(p => p.Code).HasMaxLength(20).IsRequired();
            Property(p => p.Name).HasMaxLength(100).IsRequired();
            Property(p => p.UnitPrice).IsRequired();
            Property(p => p.UnitsInStock).IsRequired();
        }
    }
}