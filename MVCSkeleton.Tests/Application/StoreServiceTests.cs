using System;
using System.Collections.Generic;
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
        private IStoreRepository _storeRepository;
        private IMapper _mapper;

        private StoreService CreateSUT()
        {
            _storeRepository = A.Fake<IStoreRepository>();
            _mapper = A.Fake<IMapper>();

            return new StoreService(_storeRepository, _mapper);
        }

        [Test]
        public void Should_Get_All_Stores()
        {
            StoreService storeService = CreateSUT();
            var stores = new List<Store>();
            var storeDtos = new List<StoreDTO>();

            A.CallTo(() => _storeRepository.GetAll()).Returns(stores);
            A.CallTo(() => _mapper.Map(stores, storeDtos)).Returns(storeDtos);

            var retrievedStores = storeService.GetAllStores();

            Assert.IsNotNull(retrievedStores);
        }

        [Test]
        public void Should_Create_A_Store()
        {
            StoreService storeService = CreateSUT();
           
            var initialGuid = Guid.NewGuid();
            var returnedStore = new Store { Id = initialGuid };

            storeService.Create(new StoreDTO { Id = initialGuid });
            A.CallTo(()=> _storeRepository.Save(returnedStore)).WithAnyArguments().MustHaveHappened();            
        }

        [Test]
        public void Should_Delete_A_Store()
        {
            StoreService storeService = CreateSUT();

            var initialGuid = Guid.NewGuid();
            var returnedStore = new Store { Id = initialGuid };

            storeService.Delete(new StoreDTO { Id = initialGuid });
            A.CallTo(() => _storeRepository.Delete(returnedStore)).WithAnyArguments().MustHaveHappened();         
        }
    }
}
