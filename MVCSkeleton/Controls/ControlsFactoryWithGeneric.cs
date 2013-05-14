using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using MVCSkeleton.Presentation.Controls.Controls;
using MVCSkeleton.Presentation.Controls.Builders;

namespace MVCSkeleton.Presentation.Controls
{
    public class ControlsFactory<TModel> : Kendo.Mvc.UI.Fluent.WidgetFactory<TModel>
    {
        public ControlsFactory(HtmlHelper<TModel> htmlHelper) : base(htmlHelper)
        {
        }

        public override Kendo.Mvc.UI.Fluent.NumericTextBoxBuilder<decimal> CurrencyTextBoxFor(Expression<Func<TModel, decimal?>> expression)
        {
            return NumericTextBoxFor(expression).Format("c");
        }

        public override Kendo.Mvc.UI.Fluent.NumericTextBoxBuilder<int> IntegerTextBoxFor(Expression<Func<TModel, int?>> expression)
        {
            return NumericTextBoxFor(expression).Format("n0").Decimals(0);
        }

        public override Kendo.Mvc.UI.Fluent.NumericTextBoxBuilder<T> NumericTextBox<T>()
        {
            return new NumericTextBoxBuilder<T>(new NumericTextBox<T>(HtmlHelper.ViewContext, Initializer, HtmlHelper.ViewData));
        }

        public override Kendo.Mvc.UI.Fluent.NumericTextBoxBuilder<double> NumericTextBox()
        {
            return new NumericTextBoxBuilder<double>(new NumericTextBox<double>(HtmlHelper.ViewContext, Initializer, HtmlHelper.ViewData));
        }
    }
}