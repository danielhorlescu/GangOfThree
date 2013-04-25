using MVCSkeleton.IOC;
using MVCSkeleton.IOC.Modules;

namespace MVCSkeleton.Requirements.IOC
{
    public class RequirementsIOCStartupModule : StructureMapApplicationStartupModule
    {
        protected override EntityFrameworkRepositoryModule GetRepositoryModule()
        {
            return new RequirementsIOCRepositoryModule();
        }
    }
}