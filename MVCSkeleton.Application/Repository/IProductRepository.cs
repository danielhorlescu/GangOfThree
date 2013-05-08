using System.Collections.Generic;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Application.Repository
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
    }
}