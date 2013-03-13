using MVCSkeleton.Infrastracture.Utils.Mapper;
using MVCSkeleton.Mapper;
using StructureMap;

namespace MVCSkeleton.IOC.Modules
{
    internal class InfrastructureModule
    {
        public void Initialize(IInitializationExpression initializationExpression)
        {
            initializationExpression.For<IMapper>().Singleton().Use<MapperImpl>();
        }
    }
}