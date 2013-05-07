using MVCSkeleton.Infrastracture.Utils.Mapper;
using MVCSkeleton.Mapper;
using Microsoft.Practices.Unity;

namespace MVCSkeleton.IOC.Unity.Modules
{
    public class InfrastructureModule
    {
        public void Initialize(IUnityContainer container)
        {
            container.RegisterType<IMapper, MapperImpl>();
        }
    }
}