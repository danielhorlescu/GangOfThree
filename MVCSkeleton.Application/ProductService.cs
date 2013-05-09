using System.Collections.Generic;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Infrastracture.Utils.Mapper;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Application
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public List<ProductDTO> GetProducts()
        {
            return mapper.Map(productRepository.GetAll(), new List<ProductDTO>());
        }
    }
}