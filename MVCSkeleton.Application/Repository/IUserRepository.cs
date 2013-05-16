using MVCSkeleton.Domain;

namespace MVCSkeleton.Application.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool Exists(string userName, string password);

        void ChangePassword(string userName, string oldPassword, string newPassword);
    }
}