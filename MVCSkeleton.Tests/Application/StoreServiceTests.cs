using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FakeItEasy;
using MVCSkeleton.Application;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.Mapper;
using NUnit.Framework;
using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Tests.Application
{
    [TestFixture]
    public class StoreServiceTests
    {
        private IStoreRepository storeRepository;
        private IMapper mapper;

        public StoreService CreateSUT()
        {
            storeRepository = A.Fake<IStoreRepository>();
            mapper = A.Fake<IMapper>();

            return new StoreService(storeRepository, mapper);
        }

        [Test]
        public void Should_Get_All_Stores()
        {
            StoreService storeService = CreateSUT();
            var stores = new List<Store>();
            var storeDtos = new List<StoreDTO>();

            A.CallTo(() => storeRepository.GetAllStores()).Returns(stores);
            A.CallTo(() => mapper.Map(stores, storeDtos)).Returns(storeDtos);

            var retrievedStores = storeService.GetAllStores();

            Assert.IsNotNull(retrievedStores);
        }
    }
}
