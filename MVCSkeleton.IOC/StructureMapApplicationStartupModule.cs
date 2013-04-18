using System.Web.Http;
using System.Web.Mvc;
using MVCSkeleton.ApplicationStartup;
using MVCSkeleton.IOC.Modules;
using StructureMap;

namespace MVCSkeleton.IOC
{
    internal class StructureMapApplicationStartupModule : IApplicationStartupModule
    {
        public void Load()
        {
            IContainer container = Initialize();
            //Resolver for the asp mvc controller injection
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);
        }

        private IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
                                         {
                                             new PresentationModule().Initialize(x);
                                             new ApplicationModule().Initialize(x);
                                            // new NHibernateRepositoryModule().Initialize(x);
                                             new EntityFrameworkRepositoryModule().Initialize(x);
                                             new InfrastructureModule().Initialize(x);
                                         });

            return ObjectFactory.Container;
        }

        private void SetInterfaceDefaultBindings()
        {
            ObjectFactory.Configure(registry => registry.Scan(x =>
                                                                  {
                                                                      x.AssembliesFromApplicationBaseDirectory();
                                                                      x.WithDefaultConventions();
                                                                  }));
        }
    }
}