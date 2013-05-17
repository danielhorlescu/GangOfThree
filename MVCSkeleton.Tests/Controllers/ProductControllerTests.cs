using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FakeItEasy;
using MVCSkeleton.Infrastracture.Utils.Comparer;
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
        private Guid productId;

        private ProductController CreateSUT()
        {
            service = A.Fake<IProductService>();
            mapper = A.Fake<IMapper>();
            return new ProductController(service, mapper);
        }

        private ProductModel CreateProductModel(Guid? id = null)
        {
            return new ProductModel
            {
                Id = id ?? Guid.Empty,
                Code = "SMART",
                Name = "Samsung Nexus",
                CategoryId = Guid.Parse("4CEAC9D2-CA6C-494E-B309-539A86178896"),
                UnitPrice = 234,
                UnitsInStock = 2
            };
        }

        [Test]
        public void Should_List_Products()
        {
            CreateSUT().List();

            A.CallTo(() => service.GetAll()).MustHaveHappened();
            A.CallTo(() => mapper.Map(new List<ProductDTO>(), new List<ProductModel>())).WithAnyArguments().MustHaveHappened();
        }

        [Test]
        public void Should_Load_An_Empty_Product()
        {
            ViewResult result = CreateSUT().Edit((Guid?) null);

            Assert.IsTrue(ObjectComparer.AreObjectsEqual(new ProductModel(), result.Model));
        }

        [Test]
        public void Should_Load_Existing_Product_For_Editing()
        {
            productId = Guid.NewGuid();

            CreateSUT().Edit(productId);

            A.CallTo(() => service.Get(productId)).WithAnyArguments().MustHaveHappened();
            A.CallTo(() => mapper.Map(new ProductDTO(), new ProductModel())).WithAnyArguments().MustHaveHappened();
        }

        [Test]
        public void Should_Save_New_Product()
        {
            CreateSUT().Edit(CreateProductModel());

            A.CallTo(() => service.Create(new ProductDTO())).WithAnyArguments().MustHaveHappened();
            A.CallTo(() => mapper.Map(new ProductModel(), new ProductDTO())).WithAnyArguments().MustHaveHappened();
        }

        [Test]
        public void Should_Update_Product()
        {
            CreateSUT().Edit(CreateProductModel(Guid.NewGuid()));

            A.CallTo(() => service.Update(new ProductDTO())).WithAnyArguments().MustHaveHappened();
            A.CallTo(() => mapper.Map(new ProductModel(), new ProductDTO())).WithAnyArguments().MustHaveHappened();
        }

        [Test]
        public void Should_Delete_Product()
        {
            CreateSUT().Delete(new ProductModel());

            A.CallTo(() => service.Delete(Guid.NewGuid())).WithAnyArguments().MustHaveHappened();
        }

        [Test]
        public void Should_Delete_Selected_Products()
        {
            CreateSUT().DeleteSelected(new List<ProductModel>());

            A.CallTo(() => service.Delete(new List<Guid>())).WithAnyArguments().MustHaveHappened();
        }
    }
}