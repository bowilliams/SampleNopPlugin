using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Nop.Web.Framework;

namespace Nop.Plugin.Widgets.SamplePlugin.Models
{
    public class ConfigurationModel
    {
        public ConfigurationModel()
        {
            AvailableZones = new List<SelectListItem>();
        }

        [NopResourceDisplayName("Admin.ContentManagement.Widgets.ChooseZone")]
        public string ZoneId { get; set; }
        public IList<SelectListItem> AvailableZones { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.SamplePlugin.Greeting")]
        [AllowHtml]
        public string Greeting { get; set; }
    }
}
