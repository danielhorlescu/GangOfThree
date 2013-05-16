using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Presentation.ApplicationInterfaces
{
    public interface IUserService
    {
        void CreateUser(UserDTO userDto);

        bool Exists(string userName, string password);

        void ChangePassword(string name, string oldPassword, string newPassword);
    }
}