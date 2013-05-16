using System;
using System.Collections.Generic;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.Mapper;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Application
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository storeRepository;
        private readonly IMapper mapper;

        public StoreService(IStoreRepository storeRepository, IMapper mapper)
        {
            this.storeRepository = storeRepository;
            this.mapper = mapper;
        }

        public void Create(StoreDTO storeDTO)
        {
            storeRepository.Save(mapper.Map(storeDTO, new Store()));
        }

        public void Delete(Guid storeId)
        {
            storeRepository.Delete(storeId);
        }

        public List<StoreDTO> GetAllStores()
        {
           return mapper.Map(storeRepository.GetAll(), new List<StoreDTO>());
        }

        public void Update(StoreDTO target)
        {
            var store = storeRepository.Get(target.Id);
            mapper.Map(target, store);
        }
    }
}
