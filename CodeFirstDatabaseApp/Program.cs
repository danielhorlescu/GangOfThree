using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDatabaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new WishlistContext())
            {
                Console.Write("Enter a name for the new Wishlist :");
                var name = Console.ReadLine();

                var wishlist = new Wishlist { Name = name };
                db.Wishlists.Add(wishlist);
                db.SaveChanges();

                var query = from o in db.Wishlists
                            orderby o.Name
                            select o;

                foreach (var order1 in query)
                {
                    Console.WriteLine(order1.Name);
                }
            }
        }
    }
}
