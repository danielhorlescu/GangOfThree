using StructureMap;

namespace MVCSkeleton.Infrastracture.Utils.IOC
{
    public class IOCProvider : IIOCProvider
    {
        private static IOCProvider instance;

        private IOCProvider()
        {
        }

        public static IIOCProvider Instance
        {
            get { return instance ?? (instance = new IOCProvider()); }
        }

        public T Get<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }
    }
}