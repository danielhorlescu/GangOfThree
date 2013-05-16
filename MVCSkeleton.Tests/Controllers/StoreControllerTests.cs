using System;
using System.Collections.Generic;
using FakeItEasy;
using Kendo.Mvc.UI;
using MVCSkeleton.Infrastracture.Utils.Mapper;
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
        private IStoreService service;
        private IMapper mapper;

        private StoreController CreateSUT()
        {
            service = A.Fake<IStoreService>();
            mapper = A.Fake<IMapper>();
            return new StoreController(service, mapper);
        }

        [Test]
        public void Should_Get_All_Stores()
        {
            StoreController storeController = CreateSUT();
            storeController.Index();

            A.CallTo(() => service.GetAllStores()).MustHaveHappened();
        }

        [Test]
        public void Should_Create_A_Store()
        {
            StoreController storeController = CreateSUT();
            storeController.Store_Create(new DataSourceRequest(), CreateStoreModels());

            A.CallTo(() => service.Create(new StoreDTO())).WithAnyArguments().MustHaveHappened();
        }

        [Test]
        public void Should_Update_A_Store()
        {
            StoreController storeController = CreateSUT();
            storeController.Store_Update(new DataSourceRequest(), CreateStoreModels());

            A.CallTo(() => service.Update(new StoreDTO())).WithAnyArguments().MustHaveHappened();
        }

        [Test]
        public void Should_Delete_A_Store()
        {
            StoreController storeController = CreateSUT();
            storeController.Store_Delete(CreateStoreModels());

            A.CallTo(()=>service.Delete(Guid.NewGuid())).WithAnyArguments().MustHaveHappened();
        }

        private IEnumerable<StoreModel> CreateStoreModels()
        {
            return new List<StoreModel>
                {
                    new StoreModel { Id = Guid.NewGuid(), Name = "testDTO", Email = "test@test.com" },
                    new StoreModel { Id = Guid.NewGuid(), Name =  "secondTestDTO", Email = "test2@test.com"}
                };
        }
    }
}
