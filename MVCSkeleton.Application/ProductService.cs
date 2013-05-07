using System.Collections.Generic;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.Mapper;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository producRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.producRepository = productRepository;
            this.mapper = mapper;
        }

        public List<ProductDTO> GetProducts()
        {
            List<Product> rootMenuItems = producRepository.GetProducts();
            return mapper.Map(rootMenuItems, new List<ProductDTO>());
        }
    }
}