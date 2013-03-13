using MVCSkeleton.ApplicationStartup;
using MVCSkeleton.Mapper.Modules;

namespace MVCSkeleton.Mapper
{
    internal class AutoMapperApplicationStartupModule : IApplicationStartupModule
    {
        public void Load()
        {
            var mapperConfigurator = new MapperConfigurator();
            mapperConfigurator.Load(new IMapperModule[] { new ApplicationModule() });
            mapperConfigurator.AssertConfigurationIsValid();
        }
    }
}