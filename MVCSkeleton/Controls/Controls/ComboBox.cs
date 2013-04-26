using System.Web.Mvc;
using Kendo.Mvc;
using Kendo.Mvc.Infrastructure;

namespace MVCSkeleton.Controls.Controls
{
    public class ComboBox : Kendo.Mvc.UI.ComboBox
    {
        public ComboBox(ViewContext viewContext, IJavaScriptInitializer initializer, ViewDataDictionary viewData, IUrlGenerator urlGenerator) 
            : base(viewContext, initializer, viewData, urlGenerator)
        {
        }
    }
}