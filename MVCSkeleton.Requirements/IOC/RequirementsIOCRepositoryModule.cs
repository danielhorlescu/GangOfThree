using MVCSkeleton.Application.Session;
using MVCSkeleton.IOC.Unity.Modules;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework;
using Microsoft.Practices.Unity;
using TechTalk.SpecFlow;

namespace MVCSkeleton.Requirements.IOC
{
    public class RequirementsIOCRepositoryModule : EntityFrameworkRepositoryModule
    {
        protected override void InitializeSessionAdapterBinding(IUnityContainer container)
        {
            container.RegisterType<ISessionAdapter, EntityFrameworkSessionAdapter>(new PerScenarioLifetime());
        }

        private class PerScenarioLifetime : LifetimeManager
        {
            // This is very important part and the reason why I believe mentioned
            // PerCallContext implementation is wrong.
            private readonly string key = "SessionAdapter";

            public override object GetValue()
            {
                return ScenarioContext.Current.Get<ISessionAdapter>(key);
            }

            public override void SetValue(object newValue)
            {
                if (!ScenarioContext.Current.ContainsKey(key))
                {
                    ScenarioContext.Current.Add(key, new EntityFrameworkSessionAdapter());
                }
            }

            public override void RemoveValue()
            {
                if (ScenarioContext.Current.ContainsKey(key))
                {
                    ScenarioContext.Current.Remove(key);
                }
            }
        }
    }
}