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
            initializationExpression.For<ISessionService>().Singleton().Use<SessionService>();
            initializationExpression.For<IUserService>().Singleton().Use<UserService>();
        }
    }
}