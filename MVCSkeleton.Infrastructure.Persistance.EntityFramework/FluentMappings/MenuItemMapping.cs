using System.Data.Entity.ModelConfiguration;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework.FluentMappings
{
    internal class MenuItemMapping : EntityTypeConfiguration<MenuItem>
    {
        public MenuItemMapping()
        {
            HasKey(u => u.Id);
            HasOptional(u => u.ParentItem);
            Property(u => u.Controller).HasMaxLength(100);
            Property(u => u.Action).HasMaxLength(100);
            Property(u => u.Name).HasMaxLength(200).IsRequired();
        }
    }
}