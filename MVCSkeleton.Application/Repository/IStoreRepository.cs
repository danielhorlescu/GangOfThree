using System;
using System.Collections.Generic;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Application.Repository
{
    public interface IStoreRepository: IBaseRepository<Store>
    {
        void UpdateLastModification(Guid id, DateTime newTime);
    }
}