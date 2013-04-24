using MVCSkeleton.Mapper;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof (PreApplicationStart), "InitializeMappings")]
namespace MVCSkeleton.Mapper
{
    public static class PreApplicationStart
    {
        public static void InitializeMappings()
        {
            new AutoMapperApplicationStartupModule().Load();
        }
    }
}