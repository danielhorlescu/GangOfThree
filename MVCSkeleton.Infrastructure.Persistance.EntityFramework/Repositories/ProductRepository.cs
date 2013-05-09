using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
    }
}
