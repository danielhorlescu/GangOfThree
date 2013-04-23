using MVCSkeleton.Infrastracture.Utils.IOC;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.ApplicationStartup;
using TechTalk.SpecFlow;

namespace MVCSkeleton.Requirements.Initialization
{
    [Binding]
    public static class TestInitializer
    {
        [BeforeScenario]
        public static void RegisterIOC()
        {
            ApplicationStartupModuleContainer.Instance.RegisterModulesFromConfigurationFile();
            ApplicationStartupModuleContainer.Instance.LoadRegisteredModules();
        }

        [AfterScenario()]
        public static void AfterScenario()
        {
            IOCProvider.Instance.Get<ISessionService>().Rollback();
        }
    }
}