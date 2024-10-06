using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordStatusRotationUI.Models
{
    public class AppConfig
    {
        [JsonProperty("app_ver")]
        public string? AppVer { get; set; }
        [JsonProperty("timer_span")]
        public string? TimerSpan { get; set; }

    }
}
