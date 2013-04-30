using System.Collections.Generic;
using MVCSkeleton.Presentation.DTOs;

namespace MVCSkeleton.Presentation.ApplicationInterfaces
{
    public interface IMenuItemService
    {
        List<RootMenuItemDTO> GetRootMenuItems();
    }
}