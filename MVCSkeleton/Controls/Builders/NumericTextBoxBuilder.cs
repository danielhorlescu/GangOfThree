using MVCSkeleton.Presentation.Controls.Controls;
namespace MVCSkeleton.Presentation.Controls.Builders
{
    public class NumericTextBoxBuilder<T> : Kendo.Mvc.UI.Fluent.NumericTextBoxBuilder<T> where T : struct
    {
        public NumericTextBoxBuilder(NumericTextBox<T> component) : base(component)
        {
        }
    }
}