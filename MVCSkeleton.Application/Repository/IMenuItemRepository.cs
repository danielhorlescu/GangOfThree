using System.Collections.Generic;
using MVCSkeleton.Domain;

namespace MVCSkeleton.Application.Repository
{
    public interface IMenuItemRepository
    {
        List<MenuItem> GetRootMenuItems();
    }
}