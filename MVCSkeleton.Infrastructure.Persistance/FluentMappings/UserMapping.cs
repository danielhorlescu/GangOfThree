using FluentNHibernate.Mapping;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Infrastructure.Persistance.FluentMappings
{
    internal class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Table("Users");
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Password);
        }
    }
}