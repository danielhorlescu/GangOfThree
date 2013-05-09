using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Kendo.Mvc;
using MVCSkeleton.Infrastracture.Utils.IOC;
using MVCSkeleton.Presentation.App_Start;
using MVCSkeleton.Presentation.ApplicationInterfaces;

namespace MVCSkeleton.Presentation
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterSiteMap();
        }

        private void RegisterSiteMap()
        {
            string menu = "menu";
            string appDataMenuSitemapPath = "~/App_Data/menu.sitemap";
            if (!SiteMapManager.SiteMaps.ContainsKey(menu))
            {
                SiteMapManager.SiteMaps.Register<XmlSiteMap>(menu,
                                                             sitmap => sitmap.LoadFrom(appDataMenuSitemapPath));
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            IOCProvider.Instance.Get<ISessionService>().Commit();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            IOCProvider.Instance.Get<ISessionService>().Dispose();
        }
    }
}