using System.Data.Entity.ModelConfiguration;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework.FluentMappings
{
    internal class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            HasKey(u => u.Id);
            Property(u => u.Name).HasMaxLength(200).IsRequired();
            Property(u => u.Password).HasMaxLength(200).IsRequired();
        }
    }
}