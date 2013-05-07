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
            AutoMapper.Mapper.CreateMap<UserDTO, User>();
            AutoMapper.Mapper.CreateMap<MenuItem, RootMenuItemDTO>();
            AutoMapper.Mapper.CreateMap<Customer, CustomerDTO>();
            AutoMapper.Mapper.CreateMap<CustomerDTO, Customer>();
            AutoMapper.Mapper.CreateMap<CustomerDTO, CustomerModel>();
            AutoMapper.Mapper.CreateMap<CustomerModel, CustomerDTO>();
        }
    }
}