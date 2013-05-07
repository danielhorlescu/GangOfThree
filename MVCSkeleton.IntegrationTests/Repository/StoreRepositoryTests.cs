using System;
using MVCSkeleton.Application.Session;
using MVCSkeleton.Domain;
using MVCSkeleton.IOC;
using MVCSkeleton.Infrastracture.Utils.ApplicationStartup;
using MVCSkeleton.Infrastracture.Utils.IOC;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories;
using MVCSkeleton.Mapper;
using NUnit.Framework;

namespace MVCSkeleton.IntegrationTests.Repository
{
    [TestFixture]
    public class StoreRepositoryTests : BaseRepositoryTests
    {
        private StoreRepository CreateSUT()
        {
            return new StoreRepository();
        }

        [Test]
        public void Should_Create_A_Store()
        {
            var createdStore = CreateStore();
            var storeRepository = CreateSUT();                

            storeRepository.Save(createdStore);
            var retrievedStore = storeRepository.Get(createdStore.Id);

            Assert.IsNotNull(retrievedStore);
            Assert.AreEqual(createdStore.Id, retrievedStore.Id);
        }

        [Test]
        public void Should_Update_Store_LastModification()
        {
            var createdStore = CreateStore();
            var storeRepository = CreateSUT();

            storeRepository.Save(createdStore);
            var updatedTime = DateTime.Now;

            storeRepository.UpdateLastModification(createdStore.Id, updatedTime);

            var retrievedStore = storeRepository.Get(createdStore.Id);

            Assert.IsNotNull(retrievedStore);            
            Assert.AreEqual(createdStore.Id, retrievedStore.Id);
            Assert.AreEqual(updatedTime, retrievedStore.LastModification);
        }

        [Test]
        public void Should_Delete_Store()
        {
            var createdStore = CreateStore();
            var storeRepository = CreateSUT();

            storeRepository.Save(createdStore);
            storeRepository.Delete(createdStore);

            var retrievedStore = storeRepository.Get(createdStore.Id);

            Assert.IsNull(retrievedStore);
        }

        private Store CreateStore()
        {
            Store createdStore = new Store {Name = "Store name", Email = "store@store.com", CreationDate = DateTime.Now, LastModification = DateTime.Now};
            return createdStore;
        }
    }    
}