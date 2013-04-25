using System.Collections;
using System.Data;
using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI.Html;
using MVCSkeleton.Controls.Builders;
using MVCSkeleton.Controls.Controls;
using System.Collections.Generic;

namespace MVCSkeleton.Controls
{
    public class ControlsFactory : Kendo.Mvc.UI.Fluent.WidgetFactory
    {
        public ControlsFactory(HtmlHelper htmlHelper) : base(htmlHelper)
        {
        }

        public override Kendo.Mvc.UI.Fluent.AutoCompleteBuilder AutoComplete()
        {
            return new AutoCompleteBuilder(new AutoComplete(HtmlHelper.ViewContext, Initializer, HtmlHelper.ViewData, UrlGenerator));
        }

        public override Kendo.Mvc.UI.Fluent.ComboBoxBuilder ComboBox()
        {
            return new ComboBoxBuilder(new ComboBox(HtmlHelper.ViewContext, Initializer, HtmlHelper.ViewData, UrlGenerator));
        }

        public override Kendo.Mvc.UI.Fluent.DateTimePickerBuilder DateTimePicker()
        {
            return new DateTimePickerBuilder(new DateTimePicker(HtmlHelper.ViewContext, Initializer, HtmlHelper.ViewData));
        }

        public override Kendo.Mvc.UI.Fluent.DropDownListBuilder DropDownList()
        {
            return new DropDownListBuilder(new DropDownList(HtmlHelper.ViewContext, Initializer, HtmlHelper.ViewData, UrlGenerator));
        }

        public override Kendo.Mvc.UI.Fluent.GridBuilder<T> Grid<T>()
        {
            return new GridBuilder<T>(new Grid<T>(HtmlHelper.ViewContext, Initializer, UrlGenerator, DI.Current.Resolve<IGridHtmlBuilderFactory>()));
        }

        public override Kendo.Mvc.UI.Fluent.GridBuilder<T> Grid<T>(string dataSourceViewDataKey)
        {
            GridBuilder<T> gridBuilder = (GridBuilder<T>) Grid<T>();
            gridBuilder.SetDataSource(dataSourceViewDataKey);
            return gridBuilder;
        }

        public override Kendo.Mvc.UI.Fluent.GridBuilder<T> Grid<T>(IEnumerable<T> dataSource)
        {
            GridBuilder<T> gridBuilder = (GridBuilder<T>) Grid<T>();
            gridBuilder.SetDataSource(dataSource);
            return gridBuilder;
        }

        public override Kendo.Mvc.UI.Fluent.GridBuilder<DataRowView> Grid(DataTable dataSource)
        {
            GridBuilder<DataRowView> gridBuilder = (GridBuilder<DataRowView>) Grid<DataRowView>();
            gridBuilder.SetDataSource(dataSource);
            return gridBuilder;
        }

        public override Kendo.Mvc.UI.Fluent.GridBuilder<DataRowView> Grid(DataView dataSource)
        {
            GridBuilder<DataRowView> gridBuilder = (GridBuilder<DataRowView>) Grid<DataRowView>();
            gridBuilder.SetDataSource(dataSource);
            return gridBuilder;
        }
    }
}