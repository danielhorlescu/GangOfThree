using System.Collections.Generic;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public List<Product> GetProducts()
        {
            throw new System.NotImplementedException();
        }
    }
}
