using System.Collections.Generic;
using System.Web.Mvc;
using Kendo.Mvc;
using Kendo.Mvc.UI;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.DTOs;
using MVCSkeleton.Presentation.Models;

namespace MVCSkeleton.Presentation.Controllers
{
    public class MenuController : Controller
    {
        public ViewResult LoadMenu()
        {
            if (!SiteMapManager.SiteMaps.ContainsKey("menu"))
            {
                SiteMapManager.SiteMaps.Register<XmlSiteMap>("menu", sitmap => sitmap.LoadFrom("~/App_Data/menu.sitemap"));
            }
            return View();
        }
    }
}