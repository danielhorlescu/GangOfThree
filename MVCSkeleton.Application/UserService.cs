using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.Mapper;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            _mapper = mapper;
        }

        public void CreateUser(UserDTO userDto)
        {
            userRepository.Save(_mapper.Map(userDto, new User()));
        }

        public bool IsValid(string userName, string password)
        {
            return userRepository.IsValid(userName, password);
        }

        public void ChangePassword(string userName, string oldPassword, string newPassword)
        {
            userRepository.ChangePassword(userName, oldPassword, newPassword);
        }
    }
}