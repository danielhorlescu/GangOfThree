using System.Web.Mvc;

using Kendo.Mvc;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI.Html;

namespace MVCSkeleton.Presentation.Controls.Controls
{
    public class Grid<T> : Kendo.Mvc.UI.Grid<T> where T : class
    {
        public Grid(ViewContext viewContext, IJavaScriptInitializer initializer, IUrlGenerator urlGenerator, IGridHtmlBuilderFactory htmlBuilderFactory) 
            : base(viewContext, initializer, urlGenerator, htmlBuilderFactory)
        {
        }

        protected override void WriteHtml(System.Web.UI.HtmlTextWriter writer)
        {
            foreach (var gridColumnBase in VisibleColumns)
            {
                if (gridColumnBase.Member != null)
                {
                    gridColumnBase.HtmlAttributes.Add("data-PropertyName", gridColumnBase.Member);
                }
            }
            base.WriteHtml(writer);
        }
    }
}