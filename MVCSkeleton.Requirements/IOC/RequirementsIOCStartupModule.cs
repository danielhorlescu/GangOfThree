using MVCSkeleton.IOC.Unity;
using MVCSkeleton.IOC.Unity.Modules;

namespace MVCSkeleton.Requirements.IOC
{
    public class RequirementsIOCStartupModule : UnityApplicationStartupModule
    {
        protected override EntityFrameworkRepositoryModule GetRepositoryModule()
        {
            return new RequirementsIOCRepositoryModule();
        }
    }
}