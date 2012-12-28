using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nop.Core.Configuration;

namespace Nop.Plugin.Widgets.SamplePlugin
{
    public class SamplePluginSettings : ISettings
    {
        public string WidgetZone { get; set; }
        public string Greeting { get; set; }
    }
}
