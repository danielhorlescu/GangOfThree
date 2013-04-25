using System.Web.Mvc;
using Kendo.Mvc;
using Kendo.Mvc.Infrastructure;

namespace MVCSkeleton.Controls.Controls
{
    public class DropDownList : Kendo.Mvc.UI.DropDownList
    {
        public DropDownList(ViewContext viewContext, IJavaScriptInitializer initializer, ViewDataDictionary viewData, IUrlGenerator urlGenerator) 
            : base(viewContext, initializer, viewData, urlGenerator)
        {
        }
    }
}