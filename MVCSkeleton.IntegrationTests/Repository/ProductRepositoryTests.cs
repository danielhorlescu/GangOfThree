using System;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories;
using NUnit.Framework;

namespace MVCSkeleton.IntegrationTests.Repository
{
    [TestFixture]
    public class ProductRepositoryTests : BaseIntegrationTests
    {
        private ProductRepository CreateSUT()
        {
            return new ProductRepository();
        }

        private Product CreateProduct()
        {
            var product = new Product
                {
                    Code = "SMART",
                    Name = "Samsung Nexus",
                    UnitPrice = 500,
                    UnitsInStock = 17,
                    CreationDate = DateTime.Now
                };
            return product;
        }

        [Test]
        public void Should_Delete_A_Product()
        {
            Product product = CreateProduct();

            ProductRepository productRepository = CreateSUT();
            productRepository.SaveWithCommit(product);
            productRepository.DeleteWithCommit(product);

            Product actualProduct = productRepository.Get(product.Id);

            Assert.IsNull(actualProduct);
        }

        [Test]
        public void Should_Save_A_Product()
        {
            Product expectedProduct = CreateProduct();

            ProductRepository productRepository = CreateSUT();
            productRepository.SaveWithCommit(expectedProduct);

            Product actualProduct = productRepository.Get(expectedProduct.Id);

            Assert.IsNotNull(actualProduct);
            Assert.AreEqual(expectedProduct.Id, actualProduct.Id);
        }

        [Test]
        public void Should_Update_A_Product()
        {
            Product actualProduct = CreateProduct();

            ProductRepository productRepository = CreateSUT();
            productRepository.SaveWithCommit(actualProduct);

            const string updatedName = "SMART2";
            actualProduct.Code = updatedName;
            productRepository.SaveWithCommit(actualProduct);

            Product expectedProduct = productRepository.Get(actualProduct.Id);

            Assert.IsNotNull(expectedProduct);
            Assert.AreEqual(expectedProduct.Code, updatedName);
        }
    }
}