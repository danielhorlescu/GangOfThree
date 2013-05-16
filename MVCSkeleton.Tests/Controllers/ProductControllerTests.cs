using System.Collections.Generic;
using System.Web.Mvc;
using FakeItEasy;
using MVCSkeleton.Infrastracture.Utils.Mapper;
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
        private IMapper mapper;

        private ProductController CreateSUT()
        {
            service = A.Fake<IProductService>();
            mapper = A.Fake<IMapper>();
            return new ProductController(service, mapper);
        }

        private List<ProductDTO> CreateProductList()
        {
            return new List<ProductDTO>
                {
                    new ProductDTO {Code = "Smart", Name = "Samsung Nexus", UnitPrice = 567, UnitsInStock = 3}
                };
        }

        [Test]
        public void Should_Get_Products()
        {
            ProductController productController = CreateSUT();
            List<ProductDTO> expectedProducts = CreateProductList();

            A.CallTo(() => service.GetAll()).Returns(expectedProducts);
            ViewResult view = productController.GetProducts();

            Assert.AreEqual(mapper.Map(expectedProducts, new List<ProductModel>()), view.Model);
        }
    }
}