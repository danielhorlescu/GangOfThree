using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;

namespace MVCSkeleton.Controls.Controls
{
    public class DateTimePicker : Kendo.Mvc.UI.DateTimePicker
    {
        public DateTimePicker(ViewContext viewContext, IJavaScriptInitializer initializer, ViewDataDictionary viewData) 
            : base(viewContext, initializer, viewData)
        {
        }
    }
}