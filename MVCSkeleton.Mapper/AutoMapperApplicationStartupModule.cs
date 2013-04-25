using MVCSkeleton.Infrastracture.Utils.ApplicationStartup;
using MVCSkeleton.Mapper.Modules;

namespace MVCSkeleton.Mapper
{
    public class AutoMapperApplicationStartupModule : IApplicationStartupModule
    {
        public void Load()
        {
            var mapperConfigurator = new MapperConfigurator();
            mapperConfigurator.Load(new IMapperModule[] {new ApplicationModule()});
            mapperConfigurator.AssertConfigurationIsValid();
        }
    }
}