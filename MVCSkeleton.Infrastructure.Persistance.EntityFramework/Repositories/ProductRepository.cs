using System.Collections.Generic;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;
using System.Linq;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public List<Product> GetProducts()
        {
            return Session.ToList();
        }
    }
}
