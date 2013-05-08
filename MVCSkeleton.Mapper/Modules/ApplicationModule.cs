using MVCSkeleton.Domain;
using MVCSkeleton.Presentation.DTOs;
using MVCSkeleton.Presentation.Models;

namespace MVCSkeleton.Mapper.Modules
{
    internal class ApplicationModule : IMapperModule
    {
        public void Load()
        {
            AutoMapper.Mapper.CreateMap<User, UserDTO>();
            AutoMapper.Mapper.CreateMap<UserDTO, User>().IgnoreAllNonExisting();
            AutoMapper.Mapper.CreateMap<Product, ProductDTO>();
            AutoMapper.Mapper.CreateMap<ProductDTO, ProductModel>();
        }
    }
}