using System.Collections.Generic;
using System.Web.Routing;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;

namespace Nop.Plugin.Widgets.SamplePlugin
{
    /// <summary>
    /// Live person provider
    /// </summary>
    public class SamplePluginPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ISettingService _settingService;
        private readonly SamplePluginSettings _samplePluginSettings;

        public SamplePluginPlugin(ISettingService settingService,
            SamplePluginSettings samplePluginSettings)
        {
            this._settingService = settingService;
            this._samplePluginSettings = samplePluginSettings;
        }

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return !string.IsNullOrWhiteSpace(_samplePluginSettings.WidgetZone)
                       ? new List<string>() { _samplePluginSettings.WidgetZone }
                       : new List<string>() { "productdetails_overview_top" };
        }

        /// <summary>
        /// Gets a route for provider configuration
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "WidgetsSamplePlugin";
            routeValues = new RouteValueDictionary() { { "Namespaces", "Nop.Plugin.Widgets.SamplePlugin.Controllers" }, { "area", null } };
        }

        /// <summary>
        /// Gets a route for displaying widget
        /// </summary>
        /// <param name="widgetZone">Widget zone where it's displayed</param>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "PublicInfo";
            controllerName = "WidgetsSamplePlugin";
            routeValues = new RouteValueDictionary()
            {
                {"Namespaces", "Nop.Plugin.Widgets.SamplePlugin.Controllers"},
                {"area", null},
                {"widgetZone", widgetZone}
            };
        }
        
        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //settings
            var settings = new SamplePluginSettings()
            {
                WidgetZone = "",
                Greeting = "Hi!"
            };
            _settingService.SaveSetting(settings);

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.SamplePlugin.Greeting", "Enter your greeting here");

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<SamplePluginSettings>();

            //locales
            this.DeletePluginLocaleResource("Plugins.Widgets.SamplePlugin.SampleString");

            base.Uninstall();
        }
    }
}
