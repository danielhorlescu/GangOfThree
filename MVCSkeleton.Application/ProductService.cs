using System.Collections.Generic;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Infrastracture.Utils.Mapper;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Application
{
    public class ProductService : IProductService
    {
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            throw new System.NotImplementedException();
        }

        public List<ProductDTO> GetProducts()
        {
            throw new System.NotImplementedException();
        }
    }
}