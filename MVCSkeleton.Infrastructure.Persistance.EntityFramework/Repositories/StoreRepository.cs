using System;
using System.Collections.Generic;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;
using System.Linq;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {

    }
}