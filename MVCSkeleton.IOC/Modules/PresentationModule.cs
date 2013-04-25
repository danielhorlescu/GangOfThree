using System.Web.Mvc;
using MVCSkeleton.IOC.ControllerResolver;
using MVCSkeleton.Presentation.Authentication;
using StructureMap;

namespace MVCSkeleton.IOC.Modules
{
    public class PresentationModule
    {
        public void Initialize(IInitializationExpression initializationExpression)
        {
            initializationExpression.For<IControllerActivator>().Use<StructureMapControllerActivator>();
            initializationExpression.For<IFormsAuthentication>().Use<FormsAuthenticationService>();
        }
    }
}