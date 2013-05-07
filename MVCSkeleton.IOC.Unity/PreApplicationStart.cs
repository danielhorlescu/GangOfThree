using MVCSkeleton.IOC.Unity;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof (PreApplicationStart), "InitializeIOCBindings")]

namespace MVCSkeleton.IOC.Unity
{
    public static class PreApplicationStart
    {
        public static void InitializeIOCBindings()
        {
            new UnityApplicationStartupModule().Load();
        }
    }
}