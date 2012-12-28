using System.Web.Mvc;
using Nop.Plugin.Widgets.SamplePlugin.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Widgets.SamplePlugin.Controllers
{
    public class WidgetsSamplePluginController : Controller
    {
        private readonly SamplePluginSettings _samplePluginSettings;
        private readonly ISettingService _settingService;

        public WidgetsSamplePluginController(SamplePluginSettings samplePluginSettings, ISettingService settingService)
        {
            this._samplePluginSettings = samplePluginSettings;
            this._settingService = settingService;
        }

        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure()
        {
            var model = new ConfigurationModel();
            model.Greeting = _samplePluginSettings.Greeting;

            model.ZoneId = _samplePluginSettings.WidgetZone;
            model.AvailableZones.Add(new SelectListItem() { Text = "Before left side column", Value = "left_side_column_before" });
            model.AvailableZones.Add(new SelectListItem() { Text = "After left side column", Value = "left_side_column_after" });
            model.AvailableZones.Add(new SelectListItem() { Text = "Before right side column", Value = "right_side_column_before" });
            model.AvailableZones.Add(new SelectListItem() { Text = "After right side column", Value = "right_side_column_after" });

            return View("Nop.Plugin.Widgets.SamplePlugin.Views.WidgetsSamplePlugin.Configure", model);
        }

        [HttpPost]
        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
                return Configure();

            //save settings
            _samplePluginSettings.Greeting = model.Greeting;
            _samplePluginSettings.WidgetZone = model.ZoneId;
            _settingService.SaveSetting(_samplePluginSettings);

            return Configure();
        }

        [ChildActionOnly]
        public ActionResult PublicInfo(string widgetZone)
        {
            var model = new PublicInfoModel();
            model.Greeting = _samplePluginSettings.Greeting;

            return View("Nop.Plugin.Widgets.SamplePlugin.Views.WidgetsSamplePlugin.PublicInfo", model);
        }
    }
}