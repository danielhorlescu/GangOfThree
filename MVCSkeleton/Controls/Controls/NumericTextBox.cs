using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;

namespace MVCSkeleton.Presentation.Controls.Controls
{
    public class NumericTextBox<T> : Kendo.Mvc.UI.NumericTextBox<T> where T : struct
    {
        public NumericTextBox(ViewContext viewContext, IJavaScriptInitializer javaScriptInitializer, ViewDataDictionary viewData)
            : base(viewContext, javaScriptInitializer, viewData)
        {
        }
    }
}