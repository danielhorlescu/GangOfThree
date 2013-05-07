using MVCSkeleton.Application;
using MVCSkeleton.Application.Session;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using StructureMap;

namespace MVCSkeleton.IOC.Modules
{
    public class ApplicationModule
    {
        public void Initialize(IInitializationExpression initializationExpression)
        {
            initializationExpression.For<ISessionService>().Use<SessionService>();
            initializationExpression.For<IUserService>().Use<UserService>();
            initializationExpression.For<IMenuItemService>().Use<MenuItemService>();
            initializationExpression.For<ICustomerService>().Use<CustomerService>();
        }
    }
}