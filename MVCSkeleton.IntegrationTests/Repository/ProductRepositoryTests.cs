using System;
using MVCSkeleton.Application.Session;
using MVCSkeleton.Domain;
using MVCSkeleton.IOC;
using MVCSkeleton.Infrastracture.Utils.ApplicationStartup;
using MVCSkeleton.Infrastracture.Utils.IOC;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories;
using MVCSkeleton.Mapper;
using NUnit.Framework;

namespace MVCSkeleton.IntegrationTests.Repository
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            new ApplicationStartupModuleComposite(new IApplicationStartupModule[] { new StructureMapApplicationStartupModule(),
                new AutoMapperApplicationStartupModule() }).Load();
        }

        private ProductRepository CreateSUT()
        {
            return new ProductRepository();
        }

        [Test]
        public void Should_Save_A_Product()
        {
            Product expectedProduct = CreateProduct();

            ProductRepository productRepository = CreateSUT();
            productRepository.Save(expectedProduct);

            Product actualProduct = productRepository.Get(expectedProduct.Id);

            Assert.IsNotNull(actualProduct);
            Assert.AreEqual(expectedProduct.Id, actualProduct.Id);
        }

        [Test]
        public void Should_Delete_A_Product()
        {
            Product product = CreateProduct();

            ProductRepository productRepository = CreateSUT();
            productRepository.Save(product);
            productRepository.Delete(product);

            Product actualProduct = productRepository.Get(product.Id);

            Assert.IsNull(actualProduct);
        }

        [Test]
        public void Should_Update_A_Product()
        {
            Product actualProduct = CreateProduct();

            ProductRepository productRepository = CreateSUT();
            productRepository.Save(actualProduct);

            const string updatedName = "SMART2";
            actualProduct.Code = updatedName;
            productRepository.Save(actualProduct);

            Product expectedProduct = productRepository.Get(actualProduct.Id);

            Assert.IsNotNull(expectedProduct);
            Assert.AreEqual(expectedProduct.Code, updatedName);
        }

        private Product CreateProduct()
        {
            Product product = new Product {Code = "SMART", Name = "Samsung Nexus", UnitPrice = 500, UnitsInStock = 17, CreationDate = DateTime.Now};
            return product;
        }
    }
}
