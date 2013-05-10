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
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public StoreService(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public void Create(StoreDTO storeDTO)
        {
            _storeRepository.Save(_mapper.Map(storeDTO, new Store()));
        }

        public void Delete(Guid storeId)
        {
            _storeRepository.Delete(storeId);
        }

        public List<StoreDTO> GetAllStores()
        {            
            return _mapper.Map(_storeRepository.GetAll(), new List<StoreDTO>());
        }
    }
}
