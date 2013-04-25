using MVCSkeleton.IOC;
using MVCSkeleton.Infrastracture.Utils.ApplicationStartup;
using MVCSkeleton.Infrastracture.Utils.IOC;
using MVCSkeleton.Mapper;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using TechTalk.SpecFlow;

namespace MVCSkeleton.Requirements.Initialization
{
    [Binding]
    public static class TestInitializer
    {
        [BeforeScenario]
        public static void RegisterIOC()
        {
            new ApplicationStartupModuleComposite(new IApplicationStartupModule[] 
            { new StructureMapApplicationStartupModule(), new AutoMapperApplicationStartupModule() }).Load();
        }

        [AfterScenario()]
        public static void AfterScenario()
        {
            IOCProvider.Instance.Get<ISessionService>().Rollback();
        }
    }
}