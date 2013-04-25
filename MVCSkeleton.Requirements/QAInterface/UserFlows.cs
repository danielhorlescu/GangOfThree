using MVCSkeleton.Infrastracture.Utils.IOC;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Requirements.QAInterface
{
    public static class UserFlows
    {
        public static UserDTO CreateUser(string userName, string password)
        {
            UserDTO user = new UserDTO();
            user.Name = userName;
            user.Password = password;
            IOCProvider.Instance.Get<IUserService>().CreateUser(user);
            return user;
        }
    }
}