using System;
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
            AutoMapper.Mapper.CreateMap<ProductModel, ProductDTO>();
            AutoMapper.Mapper.CreateMap<ProductDTO, Product>().IgnoreAllNonExisting().ForMember(dest => dest.Id, opt => opt.Condition(productDto => productDto.Id != Guid.Empty));
            AutoMapper.Mapper.CreateMap<CustomerDTO, Customer>().IgnoreAllNonExisting();
            AutoMapper.Mapper.CreateMap<CustomerModel, CustomerDTO>();

            AutoMapper.Mapper.CreateMap<Store, StoreDTO>();            
            AutoMapper.Mapper.CreateMap<StoreDTO, Store>().IgnoreAllNonExisting().ForMember(dest => dest.Id, opt => opt.Condition(storeDto => storeDto.Id != Guid.Empty));
            AutoMapper.Mapper.CreateMap<StoreDTO, StoreModel>();
            AutoMapper.Mapper.CreateMap<StoreModel, StoreDTO>();
        }
    }
}