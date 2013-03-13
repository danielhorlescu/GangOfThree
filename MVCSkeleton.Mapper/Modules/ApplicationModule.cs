using MVCSkeleton.DTOs;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Mapper.Modules
{
    internal class ApplicationModule : IMapperModule
    {
        public void Load()
        {
            AutoMapper.Mapper.CreateMap<User, UserDTO>();
            AutoMapper.Mapper.CreateMap<UserDTO, User>();
        }
    }
}