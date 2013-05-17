using System;
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
            CreateSUT().GetAll();

            A.CallTo(() => productRepository.GetAll()).MustHaveHappened();

            IEnumerable<Product> products = new List<Product>();

            A.CallTo(() => mapper.Map(products, new List<ProductDTO>())).WithAnyArguments().MustHaveHappened();
        }

        [Test]
        public void Should_Create_A_Product()
        {
            CreateSUT().Create(new ProductDTO());

            A.CallTo(() => productRepository.Save(new Product())).WithAnyArguments().MustHaveHappened();
        }

        [Test]
        public void Should_Delete_A_Product()
        {
            CreateSUT().Delete(Guid.NewGuid());

            A.CallTo(() => productRepository.Delete(Guid.NewGuid())).WithAnyArguments().MustHaveHappened();
        }

        [Test]
        public void Should_Update_A_Product()
        {
            CreateSUT().Update(new ProductDTO());

            A.CallTo(() => productRepository.Get(Guid.NewGuid())).WithAnyArguments().MustHaveHappened();
            A.CallTo(() => mapper.Map(new ProductDTO(), new Product())).WithAnyArguments().MustHaveHappened();
        }
    }
}