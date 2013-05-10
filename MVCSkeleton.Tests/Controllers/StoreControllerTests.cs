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
    public class StoreControllerTests
    {
        private IStoreService _service;

        private StoreController CreateSUT()
        {
            _service = A.Fake<IStoreService>();
            return new StoreController(_service);
        }

        [Test]
        public void Should_Get_All_Stores()
        {
            StoreController storeController = CreateSUT();
            var expectedStores = CreateStoreList();

            A.CallTo(() => _service.GetAllStores()).Returns(expectedStores);
            ViewResult view = storeController.GetAllStores();

            Assert.AreEqual(expectedStores, ((StoreGridModel)view.Model).StoreModels);
        }

        private List<StoreDTO> CreateStoreList()
        {
            return new List<StoreDTO> {new StoreDTO {Id = Guid.NewGuid(), Name = "testDTO", Email = "test@test.com"}};
        }
    }
}
