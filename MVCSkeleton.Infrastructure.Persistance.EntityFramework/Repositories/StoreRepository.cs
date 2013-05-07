using System;
using System.Collections.Generic;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;
using System.Linq;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        public void UpdateLastModification(long id, DateTime newTime)
        {
            var store = Session.SingleOrDefault(s => s.Id == id);
            if (store != null)
            {
                store.LastModification = newTime;
                context.SaveChanges();
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public List<Store> GetAllStores()
        {
            return new List<Store>();
        }
    }
}