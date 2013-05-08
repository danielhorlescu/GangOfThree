using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FakeItEasy;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.Controllers;
using MVCSkeleton.Presentation.DTOs;
using MVCSkeleton.Presentation.Models;
using NUnit.Framework;

namespace MVCSkeleton.Tests.Controllers
{
    [TestFixture]
    public class ProductControllerTests
    {
        private IProductService service;

        private ProductController CreateSUT()
        {
            service = A.Fake<IProductService>();
            return new ProductController(service);
        }

        [Test]
        public void Should_Get_Products()
        {
            ProductController productController = CreateSUT();
            List<ProductDTO> expectedProducts = CreateProductList();

            A.CallTo(() => service.GetProducts()).Returns(expectedProducts);
            ViewResult view = productController.GetProducts();

            Assert.AreEqual(expectedProducts, ((ProductModel)view.Model).Products);
        }

        private List<ProductDTO> CreateProductList()
        {
            return new List<ProductDTO>
                {
                    new ProductDTO {Code = "Smart", Name = "Samsung Nexus", UnitPrice = 567, UnitsInStock = 3, CreationDate = DateTime.Now}
                };
        }
    }
}