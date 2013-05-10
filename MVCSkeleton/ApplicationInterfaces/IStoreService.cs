using System.Collections.Generic;
using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Presentation.ApplicationInterfaces
{
    public interface IStoreService
    {
        void Create(StoreDTO storeDTO);

        void Delete(StoreDTO storeDTO);
        List<StoreDTO> GetAllStores();
    }
}