﻿using System;
using MVCSkeleton.Application;
using MVCSkeleton.Infrastracture.Utils.IOC;
using MVCSkeleton.IntegrationTests.Repository;
using MVCSkeleton.Presentation.DTOs;
using NUnit.Framework;

namespace MVCSkeleton.IntegrationTests.Service
{
    [TestFixture]
    public class ProductServiceTests : BaseIntegrationTests
    {
        private ProductService CreateSUT()
        {
            return IOCProvider.Instance.Get<ProductService>();
        }

        [Test]
        public void Should_Save_A_Product()
        {
            ProductService service = CreateSUT();

            ProductDTO expectedProductDto = CreateProductDTOWithouthId();
            Guid productId = service.Create(expectedProductDto);
            Commit();

            ProductDTO actualProductDto = service.Get(productId);

            Assert.IsNotNull(actualProductDto);
            Assert.AreEqual(productId, actualProductDto.Id);
        }

        [Test]
        public void Should_Update_A_Product()
        {
            ProductService service = CreateSUT();

            ProductDTO productDto = CreateProductDTOWithouthId();
            Guid productId = service.Create(productDto);
            Commit();

            ProductDTO expectedDto = CreateProductDTOWithId(productId);
            service.Update(expectedDto);
            Commit();

            ProductDTO actualDto = service.Get(expectedDto.Id);

            Assert.AreEqual(expectedDto, actualDto);
        }

        [Test]
        public void Should_Delete_A_Product()
        {
            ProductService service = CreateSUT();

            ProductDTO productDto = CreateProductDTOWithouthId();
            Guid productId = service.Create(productDto);
            Commit();

            service.Delete(productId);
            Commit();

            ProductDTO actualProductDto = service.Get(productId);

            Assert.IsNull(actualProductDto);
        }

        private ProductDTO CreateProductDTOWithId(Guid productId)
        {
            return new ProductDTO
            {
                Id = productId,
                Code = "SMART2",
                Name = "Samsung Nexus2",
                CategoryId = Guid.Parse("4CEAC9D2-CA6C-494E-B309-539A86178876"),
                UnitPrice = 534,
                UnitsInStock = 8
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