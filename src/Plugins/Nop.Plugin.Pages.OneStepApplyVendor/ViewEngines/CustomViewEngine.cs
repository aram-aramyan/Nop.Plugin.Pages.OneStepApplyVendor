using Nop.Web.Framework.Themes;

namespace Nop.Plugin.Pages.OneStepApplyVendor.ViewEngines
{
    public class CustomViewEngine: ThemeableRazorViewEngine
    {
        public CustomViewEngine()
        {
            PartialViewLocationFormats = new[] { "~/Plugins/Pages.OneStepApplyVendor/Views/{0}.cshtml" };
            ViewLocationFormats = new[] { "~/Plugins/Pages.OneStepApplyVendor/Views/{0}.cshtml" };
        }
    }
}
