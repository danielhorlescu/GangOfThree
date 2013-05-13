using System;
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

        public Guid Create(ProductDTO productDto)
        {
            return productRepository.Save(mapper.Map(productDto, new Product()));
        }

        public void Delete(Guid productId)
        {
            productRepository.Delete(productId);
        }

        public void Update(ProductDTO productDto)
        {
            Product product = productRepository.Get(productDto.Id);

            mapper.Map(productDto, product);
        }

        public ProductDTO Get(Guid id)
        {
            return mapper.Map(productRepository.Get(id), new ProductDTO());
        }
    }
}