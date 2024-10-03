using Newtonsoft.Json;
using System.Collections.Generic;

namespace DiscordStatusRotationUI.Models
{
    public class StatusData
    {
        [JsonProperty("discord_token")]
        public string? DiscordToken { get; set; }

        [JsonProperty("quotes")]
        public List<string>? Quotes { get; set; }

        [JsonProperty("current_index")]
        public int current_index { get; set; }
    }
}
