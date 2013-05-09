using System.Web.Mvc;
using Kendo.Mvc;
using Kendo.Mvc.Infrastructure;

namespace MVCSkeleton.Presentation.Controls.Controls
{
    public class Menu : Kendo.Mvc.UI.Menu
    {
        public Menu(ViewContext viewContext, IJavaScriptInitializer initializer, IUrlGenerator urlGenerator, INavigationItemAuthorization authorization)
            : base(viewContext, initializer, urlGenerator, authorization)
        {
        }
    }
}