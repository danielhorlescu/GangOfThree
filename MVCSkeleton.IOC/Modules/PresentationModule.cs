using System.Web.Mvc;
using MVCSkeleton.ApplicationInterfaces;
using MVCSkeleton.Authentication;
using StructureMap;

namespace MVCSkeleton.IOC.Modules
{
    internal class PresentationModule
    {
        public void Initialize(IInitializationExpression initializationExpression)
        {
            initializationExpression.For<IControllerActivator>().Use<StructureMapControllerActivator>();
            initializationExpression.For<IFormsAuthentication>().Singleton().Use<FormsAuthenticationService>();
        }
    }
}