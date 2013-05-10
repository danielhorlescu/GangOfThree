using MVCSkeleton.Application;
using MVCSkeleton.Application.Session;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using Microsoft.Practices.Unity;

namespace MVCSkeleton.IOC.Unity.Modules
{
    public class ApplicationModule
    {
        public void Initialize(IUnityContainer container)
        {
            container.RegisterType<ISessionService, SessionService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<ICustomerService, CustomerService>();
        }
    }
}