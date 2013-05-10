using System;
using System.Collections.Generic;
using System.Data.Entity;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Domain;
using System.Linq;

namespace MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories
{
    public class MenuItemRepository : BaseRepository<MenuItem>, IMenuItemRepository
    {
        public List<MenuItem> GetRootMenuItems()
        {
            return Session.Where(mu => mu.ParentItem == null).ToList();
        }

        public MenuItem GetWithParentItem(Guid id)
        {
            return Session.Include(mu => mu.ParentItem).Single(mu=>mu.Id == id);
        }
    }
}