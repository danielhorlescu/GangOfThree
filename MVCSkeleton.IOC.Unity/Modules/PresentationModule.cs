using MVCSkeleton.Presentation.Authentication;
using Microsoft.Practices.Unity;

namespace MVCSkeleton.IOC.Unity.Modules
{
    public class PresentationModule
    {
        public void Initialize(IUnityContainer container)
        {
            container.RegisterType<IFormsAuthentication, FormsAuthenticationService>();
        }
    }
}