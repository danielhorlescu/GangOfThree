using MVCSkeleton.Application.Repository;
using MVCSkeleton.Application.Session;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework;
using StructureMap;

namespace MVCSkeleton.IOC.Modules
{
    internal class EntityFrameworkRepositoryModule
    {
        public void Initialize(IInitializationExpression initializationExpression)
        {
            initializationExpression.For<ISessionAdapter>().HybridHttpOrThreadLocalScoped().Use
                <EntityFrameworkSessionAdapter>();
            initializationExpression.For<IUserRepository>().Use<Infrastructure.Persistance.EntityFramework.Repositories.UserRepository>();
        }
    }
}