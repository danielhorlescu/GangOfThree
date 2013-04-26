using System.Web.Mvc;
using Kendo.Mvc;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI.Html;

namespace MVCSkeleton.Controls.Controls
{
    public class Grid<T> : Kendo.Mvc.UI.Grid<T> where T : class
    {
        public Grid(ViewContext viewContext, IJavaScriptInitializer initializer, IUrlGenerator urlGenerator, IGridHtmlBuilderFactory htmlBuilderFactory) 
            : base(viewContext, initializer, urlGenerator, htmlBuilderFactory)
        {
        }
    }
}