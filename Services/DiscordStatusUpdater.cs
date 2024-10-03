
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordStatusRotationUI.Services
{
    public class DiscordStatusUpdater
    {
        private readonly string _apiUrl = "https://discord.com/api/v9/users/@me/settings";
        private readonly HttpClient _client;

        public DiscordStatusUpdater(string token)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Authorization", token);
        }

        public async Task<bool> UpdateStatus(string currentQuote)
        {
            var payload = new
            {
                custom_status = new
                {
                    text = currentQuote
                }
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _client.PatchAsync(_apiUrl, content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }

}