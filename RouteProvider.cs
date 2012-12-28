using System.Web.Mvc;
using System.Web.Routing;
using Nop.Web.Framework.Mvc.Routes;

namespace Nop.Plugin.Widgets.SamplePlugin
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Plugin.Widgets.SamplePlugin.Configure",
                 "Plugins/WidgetsSamplePlugin/Configure",
                 new { controller = "WidgetsSamplePlugin", action = "Configure" },
                 new[] { "Nop.Plugin.Widgets.SamplePlugin.Controllers" }
            );
            routes.MapRoute("Plugin.Widgets.SamplePlugin.PublicInfo",
                            "Plugins/WidgetsSamplePlugin/PublicInfo",
                            new {controller = "WidgetsSamplePlugin", action = "PublicInfo"},
                            new[] {"Nop.Plugin.Widgets.SamplePlugin.Controllers"}
                );
        }
        public int Priority
        {
            get
            {
                return 0;
            }
        }
    }
}
