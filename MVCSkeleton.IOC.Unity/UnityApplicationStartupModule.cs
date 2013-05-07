using System.Web.Mvc;
using MVCSkeleton.IOC.Unity.Modules;
using MVCSkeleton.Infrastracture.Utils.ApplicationStartup;
using MVCSkeleton.Infrastracture.Utils.IOC;
using Microsoft.Practices.Unity;
using Unity.Mvc3;

namespace MVCSkeleton.IOC.Unity
{
    public class UnityApplicationStartupModule : IApplicationStartupModule
    {
        public void Load()
        {
            var container = Initialize();
            //Resolver for the asp mvc controller injection
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private IUnityContainer Initialize()
        {
            var container = ((IOCProvider)IOCProvider.Instance).GetContainer();

            new PresentationModule().Initialize(container);
            new ApplicationModule().Initialize(container);
            GetRepositoryModule().Initialize(container);
            new InfrastructureModule().Initialize(container);

            return container;
        }

        protected virtual EntityFrameworkRepositoryModule GetRepositoryModule()
        {
            return new EntityFrameworkRepositoryModule();
        }
    }
}