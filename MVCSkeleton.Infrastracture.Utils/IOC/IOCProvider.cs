using Microsoft.Practices.Unity;

namespace MVCSkeleton.Infrastracture.Utils.IOC
{
    public class IOCProvider : IIOCProvider
    {
        private static IOCProvider instance;
        private readonly UnityContainer unityContainer;

        private IOCProvider()
        {
            unityContainer = new UnityContainer();
        }

        public static IIOCProvider Instance
        {
            get { return instance ?? (instance = new IOCProvider()); }
        }

        public T Get<T>()
        {
            //return ObjectFactory.GetInstance<T>();
            return unityContainer.Resolve<T>();
        }

        public IUnityContainer GetContainer()
        {
            return unityContainer;
        }
    }
}