using MVCSkeleton.IOC.Unity;
using MVCSkeleton.Infrastracture.Utils.ApplicationStartup;
using MVCSkeleton.Mapper;
using NUnit.Framework;

namespace MVCSkeleton.IntegrationTests.Repository
{
    public class BaseRepositoryTests
    {
        [SetUp]
        public virtual void SetUp()
        {
            new ApplicationStartupModuleComposite(new IApplicationStartupModule[]
                {
                    new UnityApplicationStartupModule(),
                    new AutoMapperApplicationStartupModule()
                }).Load();
        }
    }
}