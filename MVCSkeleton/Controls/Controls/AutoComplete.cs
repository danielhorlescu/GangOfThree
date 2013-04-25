using System.Web.Mvc;
using Kendo.Mvc;
using Kendo.Mvc.Infrastructure;

namespace MVCSkeleton.Controls.Controls
{
    public class AutoComplete : Kendo.Mvc.UI.AutoComplete
    {
        public AutoComplete(ViewContext viewContext, IJavaScriptInitializer initializer, ViewDataDictionary viewData, IUrlGenerator urlGenerator) 
            : base(viewContext, initializer, viewData, urlGenerator)
        {
        }
    }
}