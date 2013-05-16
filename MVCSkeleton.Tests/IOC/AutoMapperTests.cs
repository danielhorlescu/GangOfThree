using System;
using MVCSkeleton.Domain;
using MVCSkeleton.Mapper;
using MVCSkeleton.Presentation.DTOs;
using NUnit.Framework;

namespace MVCSkeleton.Tests.IOC
{
    [TestFixture]
    public class AutoMapperTests
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            new AutoMapperApplicationStartupModule().Load();
        }
       
        [Test]
        public void Should_Ignore_Mapping_If_ProductDto_Id_Equals_Guid_Empty()
        {
            ProductDTO productDto = CreateProductDTOWithouthId();

            Product product = CreateProductWithId();

            AutoMapper.Mapper.Map(productDto, product);

            Assert.AreNotEqual(product.Id, Guid.Empty);
        }

        private Product CreateProductWithId()
        {
            return new Product
            {
                Id = Guid.Parse("0C4B3EB3-0315-4061-82F1-F804755ABCFF")
            };
        }

        private ProductDTO CreateProductDTOWithouthId()
        {
            return new ProductDTO
            {
                Code = "SMART",
                Name = "Samsung Nexus",
                CategoryId = Guid.Parse("4CEAC9D2-CA6C-494E-B309-539A86178896"),
                UnitPrice = 234,
                UnitsInStock = 2
            };
        }
    }
}