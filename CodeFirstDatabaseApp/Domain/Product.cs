using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstDatabaseApp
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MoreDescription { get; set; }

        public int WishlistId { get; set; }
        public virtual Wishlist Wishlist { get; set; }
    }
}
