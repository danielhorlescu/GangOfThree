using System.Collections.Generic;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;
using MVCSkeleton.Infrastracture.Utils.Mapper;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Application
{
    public class MenuItemService : IMenuItemService
    {
        private IMenuItemRepository menuItemRepository;
        private readonly IMapper mapper;

        public MenuItemService(IMenuItemRepository menuItemRepository, IMapper mapper)
        {
            this.menuItemRepository = menuItemRepository;
            this.mapper = mapper;
        }

        public List<RootMenuItemDTO> GetRootMenuItems()
        {
            List<MenuItem> rootMenuItems = menuItemRepository.GetRootMenuItems();
            return mapper.Map(rootMenuItems, new List<RootMenuItemDTO>());
        }
    }
}