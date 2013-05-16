using System;
using System.Collections.Generic;
using System.Linq;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;
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

        public ProductDTO Get(Guid id)
        {
            return mapper.Map(productRepository.Get(id), new ProductDTO());
        }

        public List<ProductDTO> GetAll()
        {
            return mapper.Map(productRepository.GetAll(), new List<ProductDTO>());
        }

        public List<ProductDTO> GetAll(IEnumerable<Guid> ids)
        {
            return mapper.Map(productRepository.GetAll(obj => ids.Contains(obj.Id)), new List<ProductDTO>());
        }

        public Guid Create(ProductDTO productDto)
        {
            return productRepository.Save(mapper.Map(productDto, new Product()));
        }

        public void Delete(Guid productId)
        {
            productRepository.Delete(productId);
        }

        public void Delete(IEnumerable<Guid> productIds)
        {
            productRepository.Delete(productIds);
        }

        public void Update(ProductDTO productDto)
        {
            Product product = productRepository.Get(productDto.Id);

            mapper.Map(productDto, product);
        }
    }
}