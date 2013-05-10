using System.Collections.Generic;
using FakeItEasy;
using MVCSkeleton.Application;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.Mapper;
using MVCSkeleton.Presentation.DTOs;
using NUnit.Framework;

namespace MVCSkeleton.Tests.Application
{
    [TestFixture]
    public class ProductServiceTests
    {
        private IProductRepository productRepository;
        private IMapper mapper;

        private ProductService CreateSUT()
        {
            productRepository = A.Fake<IProductRepository>();
            mapper = A.Fake<IMapper>();
            return new ProductService(productRepository, mapper);
        }

        [Test]
        public void Should_Get_Products()
        {
            ProductService productService = CreateSUT();
            List<Product> products = new List<Product>();
            List<ProductDTO> productDtos = new List<ProductDTO>();

            A.CallTo(() => productRepository.GetAll()).Returns(products);
            A.CallTo(() => mapper.Map(products, productDtos)).Returns(productDtos);

            List<ProductDTO> actualProductDtos = productService.GetProducts();

            Assert.IsNotNull(actualProductDtos);
        }
    }
}