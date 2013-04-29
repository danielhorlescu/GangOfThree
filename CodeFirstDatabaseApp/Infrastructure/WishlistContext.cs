using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDatabaseApp
{
    public class WishlistContext : DbContext  
    {
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
