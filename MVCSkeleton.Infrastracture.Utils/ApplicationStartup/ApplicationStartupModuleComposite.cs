using System.Collections.Generic;

namespace MVCSkeleton.Infrastracture.Utils.ApplicationStartup
{
    public class ApplicationStartupModuleComposite : IApplicationStartupModule
    {
        private readonly List<IApplicationStartupModule> _modules = new List<IApplicationStartupModule>();

        public ApplicationStartupModuleComposite(params IApplicationStartupModule[] modules)
        {
            _modules = new List<IApplicationStartupModule>(modules);
        }

        public void Load()
        {
            foreach (var applicationStartupModule in _modules)
            {
                applicationStartupModule.Load();
            }
        }
    }
}