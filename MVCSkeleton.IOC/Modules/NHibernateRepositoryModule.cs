using MVCSkeleton.Application.Repository;
using MVCSkeleton.Application.Session;
using MVCSkeleton.Infrastructure.Persistance;
using MVCSkeleton.Infrastructure.Persistance.Repositories;
using StructureMap;

namespace MVCSkeleton.IOC.Modules
{
    internal class NHibernateRepositoryModule
    {
        public void Initialize(IInitializationExpression initializationExpression)
        {
            initializationExpression.For<ISessionAdapter>().Singleton().Use
                <NHiberanteSessionAdapter>();
            initializationExpression.For<IUserRepository>().Singleton().Use<UserRepository>();
        }
    }
}