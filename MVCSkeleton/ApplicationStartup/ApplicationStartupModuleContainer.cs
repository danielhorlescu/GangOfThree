using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;

namespace MVCSkeleton.ApplicationStartup
{
    public class ApplicationStartupModuleContainer
    {
        private static ApplicationStartupModuleContainer _instance;
        private readonly List<IApplicationStartupModule> registeredModules = new List<IApplicationStartupModule>();

        private ApplicationStartupModuleContainer()
        {
        }

        public static ApplicationStartupModuleContainer Instance
        {
            get { return _instance ?? (_instance = new ApplicationStartupModuleContainer()); }
        }

        public void Register(IApplicationStartupModule applicationStartupModule)
        {
            registeredModules.Add(applicationStartupModule);
        }

        public void RegisterModulesFromConfigurationFile()
        {
            try
            {
                InternalRegisterModulesFromConfigurationFile();
            }
            catch (Exception e)
            {
                throw new ConfigurationErrorsException("Failed to load startup modules!", e);
            }
        }

        public void LoadRegisteredModules()
        {
            foreach (var applicationStartupModule in registeredModules)
            {
                applicationStartupModule.Load();
            }
        }

        private void InternalRegisterModulesFromConfigurationFile()
        {
            NameValueCollection applicationStartupModules = (NameValueCollection)ConfigurationManager.GetSection("applicationStartupModules");
            foreach (string key in applicationStartupModules.Keys)
            {
                string[] typeAndAssembly = applicationStartupModules.Get(key).Split(',');
                string typeName = typeAndAssembly[0].Trim();
                string assemblyFile = typeAndAssembly[1].Trim();
                IApplicationStartupModule startupModule = CreateApplicationStartupModule(typeName, assemblyFile);
                Instance.Register(startupModule);
            }
        }

        private IApplicationStartupModule CreateApplicationStartupModule(string typeName, string assemblyFile)
        {
            Assembly assembly = Assembly.Load(assemblyFile);
            IApplicationStartupModule startupModule = assembly.CreateInstance(typeName) as IApplicationStartupModule;
            if (startupModule == null)
            {
                throw new ConfigurationErrorsException(string.Format("{0} from {1} is not of type IApplicationStartupModule. Please check the applicationStartupModules section of the config file!",
                                                                     typeName, assemblyFile));
            }
            return startupModule;
        }
    }
}
