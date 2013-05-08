using System.Collections.Generic;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.DTOs;
using MVCSkeleton.Presentation.Models;

namespace MVCSkeleton.Presentation.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuItemService service;

        public MenuController(IMenuItemService service)
        {
            this.service = service;
        }

        public MenuController()
        {
            
        }

        public ViewResult GetRootMenuItems()
        {
            List<RootMenuItemDTO> rootMenuItemDtos = service.GetRootMenuItems();
            return View(new MenuModel {RootItems = Map(rootMenuItemDtos)});
        }

        private List<MenuItem> Map(List<RootMenuItemDTO> rootMenuItemDtos)
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            foreach (var rootMenuItemDto in rootMenuItemDtos)
            {
                menuItems.Add(Map(rootMenuItemDto, new MenuItem()));
            }
            return menuItems;
        }

        private MenuItem Map(RootMenuItemDTO menuDTO, MenuItem menuItem)
        {
            menuItem.HtmlAttributes["Id"] = menuDTO.Id;
            menuItem.Text = menuDTO.Name;
            return menuItem;
        }
    }
}