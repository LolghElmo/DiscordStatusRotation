using DiscordStatusRotationUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordStatusRotationUI.Services
{
    public class StatusDataManager
    {
        private readonly string _jsonFilePath;

        public StatusDataManager(string jsonFileName)
        {
            _jsonFilePath = Path.Combine(Application.StartupPath, jsonFileName);
        }

        public StatusData LoadStatusData()
        {
            if (!File.Exists(_jsonFilePath))
            {
                StatusData defaultData = new StatusData
                {
                    DiscordToken = String.Empty,
                    Quotes = new List<string>(),
                    current_index = 0
                };

                SaveStatusData(defaultData);
                return defaultData;
            }
            else
            {
                string jsonContent = File.ReadAllText(_jsonFilePath);
                return JsonConvert.DeserializeObject<StatusData>(jsonContent);
            }
        }

        public void SaveStatusData(StatusData statusData)
        {
            string jsonContent = JsonConvert.SerializeObject(statusData, Formatting.Indented);
            File.WriteAllText(_jsonFilePath, jsonContent);
        }
    }
}
