using MVCSkeleton.Application.Session;
using MVCSkeleton.IOC.Modules;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework;
using StructureMap;
using TechTalk.SpecFlow;

namespace MVCSkeleton.Requirements.IOC
{
    public class RequirementsIOCRepositoryModule : EntityFrameworkRepositoryModule
    {
        protected override void InitializeSessionAdapterBinding(IInitializationExpression initializationExpression)
        {
            initializationExpression.For<ISessionAdapter>().Use(GetSessionAdapter(null));
        }

        private ISessionAdapter GetSessionAdapter(IContext context)
        {
            if (!ScenarioContext.Current.ContainsKey("SessionAdapter"))
            {
                var entityFrameworkSessionAdapter = new EntityFrameworkSessionAdapter();
                ScenarioContext.Current.Add("SessionAdapter", entityFrameworkSessionAdapter);
                return entityFrameworkSessionAdapter;
            }
            return ScenarioContext.Current.Get<ISessionAdapter>("SessionAdapter");
        }
    }
}