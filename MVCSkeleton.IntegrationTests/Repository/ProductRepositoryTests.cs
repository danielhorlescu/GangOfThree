using System;
using System.Collections.Generic;
using System.Linq;
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

        private List<Product> CreateProducts()
        {
            return new List<Product>
                {
                    new Product
                        {
                            Code = "SMART",
                            Name = "Samsung Nexus",
                            UnitPrice = 500,
                            UnitsInStock = 17,
                            CreationDate = DateTime.Now
                        },
                    new Product
                        {
                            Code = "SMART2",
                            Name = "Samsung Nexus2",
                            UnitPrice = 400,
                            UnitsInStock = 7,
                            CreationDate = DateTime.Now
                        }
                };
        }

        [Test]
        public void Should_Delete_A_Product()
        {
            ProductRepository productRepository = CreateSUT();

            Product product = CreateProduct();

            productRepository.SaveWithCommit(product);
            productRepository.DeleteWithCommit(product);

            Product actualProduct = productRepository.Get(product.Id);

            Assert.IsNull(actualProduct);
        }

        [Test]
        public void Should_Delete_A_List_Of_Products()
        {
            ProductRepository productRepository = CreateSUT();

            List<Product> products = CreateProducts();

            productRepository.SaveWithCommit(products);

            List<Guid> productIds = products.Select((p, index) => p.Id).ToList();

            productRepository.DeleteWithCommit(productIds);

            IEnumerable<Product> actualProducts = productRepository.GetAll(obj => productIds.Contains(obj.Id));

            Assert.IsEmpty(actualProducts);
        }

        [Test]
        public void Should_Save_A_Product()
        {
            ProductRepository productRepository = CreateSUT();

            Product expectedProduct = CreateProduct();

            productRepository.SaveWithCommit(expectedProduct);

            Product actualProduct = productRepository.Get(expectedProduct.Id);

            Assert.IsNotNull(actualProduct);
            Assert.AreEqual(expectedProduct.Id, actualProduct.Id);
        }

        [Test]
        public void Should_Update_A_Product()
        {
            ProductRepository productRepository = CreateSUT();

            Product actualProduct = CreateProduct();

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