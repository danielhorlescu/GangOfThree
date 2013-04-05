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
            initializationExpression.For<ISessionAdapter>().Singleton().Use
                <EntityFrameworkSessionAdapter>();
            initializationExpression.For<IUserRepository>().Singleton().Use<Infrastructure.Persistance.EntityFramework.Repositories.UserRepository>();
        }
    }
}