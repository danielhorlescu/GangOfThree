﻿using System.Linq;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories
{
    public class UserRepository : BaseRepository<User> ,IUserRepository
    {

        public bool IsValid(string userName, string password)
        {
            return Session.Any(u => u.Name == userName && u.Password == password);
        }

        public void ChangePassword(string userName, string oldPassword, string newPassword)
        {
            User user = Session.SingleOrDefault(u => u.Name == userName &&
                                                     u.Password == oldPassword);
            user.Password = newPassword;
            context.SaveChanges();
        }
    }
}