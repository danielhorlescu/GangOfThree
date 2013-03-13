using MVCSkeleton.Application.Repository;
using MVCSkeleton.Application.Session;
using MVCSkeleton.Infrastructure.Persistance;
using MVCSkeleton.Infrastructure.Persistance.Repositories;
using StructureMap;

namespace MVCSkeleton.IOC.Modules
{
    internal class RepositoryModule
    {
        public void Initialize(IInitializationExpression initializationExpression)
        {
            initializationExpression.For<ISessionAdapter>().Singleton().Use
                <SessionAdapter>();
            initializationExpression.For<IUserRepository>().Singleton().Use<UserRepository>();
        }
    }
}