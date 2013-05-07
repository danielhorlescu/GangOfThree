using MVCSkeleton.IOC;
using MVCSkeleton.Infrastracture.Utils.ApplicationStartup;
using MVCSkeleton.Mapper;
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
        }
    }
}