namespace MVCSkeleton.Presentation.Controls
{
    public static class HtmlHelperExtension
    {
        public static ControlsFactory<TModel> Controls<TModel>(this System.Web.Mvc.HtmlHelper<TModel> helper)
        {
            return new ControlsFactory<TModel>(helper);
        }
    }
}