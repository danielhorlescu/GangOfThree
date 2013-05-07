using MVCSkeleton.Application.Repository;
using MVCSkeleton.Application.Session;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework;
using StructureMap;

namespace MVCSkeleton.IOC.Modules
{
    public class EntityFrameworkRepositoryModule
    {
        public void Initialize(IInitializationExpression initializationExpression)
        {
            InitializeSessionAdapterBinding(initializationExpression);
            initializationExpression.For<IUserRepository>().Use<Infrastructure.Persistance.EntityFramework.Repositories.UserRepository>();
            initializationExpression.For<IMenuItemRepository>().Use<Infrastructure.Persistance.EntityFramework.Repositories.MenuItemRepository>();
            initializationExpression.For<IProductRepository>().Use<Infrastructure.Persistance.EntityFramework.Repositories.ProductRepository>();
        }

        protected virtual void InitializeSessionAdapterBinding(IInitializationExpression initializationExpression)
        {
            initializationExpression.For<ISessionAdapter>().HybridHttpOrThreadLocalScoped().Use
                <EntityFrameworkSessionAdapter>();
        }
    }
}