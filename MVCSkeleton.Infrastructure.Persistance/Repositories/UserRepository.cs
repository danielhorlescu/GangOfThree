using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Infrastructure.Persistance.Repositories
{
    public class UserRepository : BaseRepository<User> ,IUserRepository
    {
        public bool IsValid(string userName, string password)
        {
            User user = Session.QueryOver<User>().Where(u => u.Name == userName && u.Password == password).SingleOrDefault();
            return user != null;
        }

        public void ChangePassword(string userName, string oldPassword, string newPassword)
        {
            User user = Session.QueryOver<User>().Where(u => u.Name == userName &&
                u.Password == oldPassword).SingleOrDefault();
            user.Password = newPassword;
            Session.SaveOrUpdate(user);
        }
    }
}