namespace MVCSkeleton.Controls
{
    public static class HtmlHelperExtension
    {
        public static ControlsFactory Controls(this System.Web.Mvc.HtmlHelper helper)
        {
            return new ControlsFactory(helper);
        }
    }
}