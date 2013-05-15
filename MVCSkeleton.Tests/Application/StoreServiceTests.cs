using System;
using System.Collections.Generic;
using FakeItEasy;
using MVCSkeleton.Application;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.Mapper;
using MVCSkeleton.Presentation.DTOs;
using NUnit.Framework;

namespace MVCSkeleton.Tests.Application
{
    [TestFixture]
    public class StoreServiceTests
    {
        private IStoreRepository storeRepository;
        private IMapper mapper;

        private StoreService CreateSUT()
        {
            storeRepository = A.Fake<IStoreRepository>();
            mapper = A.Fake<IMapper>();

            return new StoreService(storeRepository, mapper);
        }

        [Test]
        public void Should_Get_All_Stores()
        {
            CreateSUT().GetAllStores();

            A.CallTo(() => storeRepository.GetAll()).MustHaveHappened();
            IEnumerable<Store> source = new List<Store>();
            A.CallTo(() => mapper.Map(source, new List<StoreDTO>())).WithAnyArguments().MustHaveHappened();
        }

        [Test]
        public void Should_Create_A_Store()
        {
            StoreService storeService = CreateSUT();
            storeService.Create(new StoreDTO());

            A.CallTo(() => storeRepository.Save(new Store())).WithAnyArguments().MustHaveHappened();
        }

        [Test]
        public void Should_Update_A_Store()
        {
            StoreService storeService = CreateSUT();
            storeService.Update(new StoreDTO());

            A.CallTo(() => mapper.Map(new StoreDTO(), new Store())).WithAnyArguments().MustHaveHappened();
        }

        [Test]
        public void Should_Delete_A_Store()
        {
            StoreService storeService = CreateSUT();
            storeService.Delete(Guid.NewGuid());

            A.CallTo(() => storeRepository.Delete(Guid.NewGuid())).WithAnyArguments().MustHaveHappened();
        }
    }
}