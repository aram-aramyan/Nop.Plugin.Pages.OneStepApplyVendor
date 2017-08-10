using System.Web.Routing;
using Nop.Web.Framework.Mvc.Routes;
using Nop.Web.Framework.Localization;
using Nop.Plugin.Pages.OneStepApplyVendor.ViewEngines;

namespace Nop.Plugin.Pages.OneStepApplyVendor
{
    public class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            System.Web.Mvc.ViewEngines.Engines.Add(new CustomViewEngine());

            routes.Remove(routes["ApplyVendorAccount"]);

            routes.MapLocalizedRoute("ApplyVendorAccount",
                "vendor/apply",
                new { controller = "Vendor", action = "ApplyVendor" },
                new[] { "Nop.Plugin.Pages.OneStepApplyVendor.Controllers" });

        }

        // process after the defaul RouteProvider to override it
        public int Priority => -1;
    }
}