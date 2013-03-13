using MVCSkeleton.DTOs;

namespace MVCSkeleton.ApplicationInterfaces
{
    public interface IUserService
    {
        void CreateUser(UserDTO userDto);

        bool IsValid(string userName, string password);

        void ChangePassword(string name, string oldPassword, string newPassword);
    }
}