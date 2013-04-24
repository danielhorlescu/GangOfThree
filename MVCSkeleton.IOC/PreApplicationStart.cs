[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MVCSkeleton.IOC.PreApplicationStart), "InitializeIOCBindings")]

namespace MVCSkeleton.IOC
{
    public static class PreApplicationStart
    {
        public static void InitializeIOCBindings()
        {
            new StructureMapApplicationStartupModule().Load();
        }
    }
}