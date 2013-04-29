using System.Collections;
using System.Collections.Generic;
using System.Data;

using MVCSkeleton.Presentation.Controls.Controls;

namespace MVCSkeleton.Presentation.Controls.Builders
{
    public class GridBuilder<T> : Kendo.Mvc.UI.Fluent.GridBuilder<T> where T : class
    {
        public GridBuilder(Grid<T> component) : base(component)
        {
        }

        public void SetDataSource(string dataSourceViewDataKey)
        {
            Component.DataSource.Data = (IEnumerable)(Component.ViewContext.ViewData.Eval(dataSourceViewDataKey) as IEnumerable<T>);
        }

        public void SetDataSource(IEnumerable<T> dataSource)
        {
            Component.DataSource.Data = (IEnumerable)dataSource;
        }

        public void SetDataSource(DataTable dataSource)
        {
            Component.DataSource.Data = (IEnumerable)dataSource;
        }

        public void SetDataSource(DataView dataSource)
        {
            Component.DataSource.Data = (IEnumerable)dataSource.Table;
        }
    }
}