using System;
using System.Collections.Generic;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;
using System.Linq;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        public void UpdateLastModification(Guid id, DateTime newTime)
        {
            var store = Session.SingleOrDefault(s => s.Id == id);
            if (store != null)
            {
                store.UpdateDate = newTime;
                context.SaveChanges();
            }
            else
            {
                throw new NullReferenceException();
            }
        }        
    }
}