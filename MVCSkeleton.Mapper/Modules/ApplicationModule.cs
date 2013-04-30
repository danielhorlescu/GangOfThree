using MVCSkeleton.Domain;
using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Mapper.Modules
{
    internal class ApplicationModule : IMapperModule
    {
        public void Load()
        {
            AutoMapper.Mapper.CreateMap<User, UserDTO>();
            AutoMapper.Mapper.CreateMap<UserDTO, User>();
            AutoMapper.Mapper.CreateMap<MenuItem, RootMenuItemDTO>();
        }
    }
}