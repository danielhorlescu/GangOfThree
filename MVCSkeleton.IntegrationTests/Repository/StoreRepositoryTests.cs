using System;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories;
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
        public void Should_Update_Store()
        {
            var createdStore = CreateStore();
            var storeRepository = CreateSUT();

            storeRepository.SaveWithCommit(createdStore);
            var updatedName = "test NAme";

            var store = storeRepository.Get(createdStore.Id);
            store.Name = updatedName;
            storeRepository.Save(store);            

            var retrievedStore = storeRepository.Get(createdStore.Id);

            Assert.IsNotNull(retrievedStore);            
            Assert.AreEqual(createdStore.Id, retrievedStore.Id);
            Assert.AreEqual(updatedName, retrievedStore.Name);
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
            var createdStore = new Store {Name = "Store name", Email = "store@store.com", CreationDate = DateTime.Now, UpdateDate = DateTime.Now};
            return createdStore;
        }
    }    
}