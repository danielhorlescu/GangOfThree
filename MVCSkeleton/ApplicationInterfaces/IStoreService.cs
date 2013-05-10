using System;
using System.Collections.Generic;
using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Presentation.ApplicationInterfaces
{
    public interface IStoreService
    {
        void Create(StoreDTO storeDTO);

        void Delete(Guid storeId);
        List<StoreDTO> GetAllStores();
    }
}