using MVCSkeleton.Domain;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCSkeleton.DatabaseCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MVCSkeletonDataContext(null))
            {              
                Console.WriteLine("User name : ");
                var userName = Console.ReadLine();

                Console.WriteLine("User password : ");
                var userPassword = Console.ReadLine();

                var user = new User { Name = userName, Password = userPassword };
                db.Users.Add(user);
                db.SaveChanges();

                var userQuery = from u in db.Users
                                orderby u.Name
                                select u;

                foreach (var userItem in userQuery)
                {
                    Console.WriteLine(userItem.Name + " " + userItem.Password);
                }
            }
        }
    }
}
