using MVCSkeleton.Application;
using MVCSkeleton.Application.Session;
using MVCSkeleton.ApplicationInterfaces;
using StructureMap;

namespace MVCSkeleton.IOC.Modules
{
    internal class ApplicationModule
    {
        public void Initialize(IInitializationExpression initializationExpression)
        {
            initializationExpression.For<ISessionService>().Use<SessionService>();
            initializationExpression.For<IUserService>().Use<UserService>();
        }
    }
}