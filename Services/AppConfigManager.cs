using DiscordStatusRotationUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordStatusRotationUI.Services
{
    public class AppConfigManager
    {
        private readonly string _jsonFilePath;

        public AppConfigManager(string jsonFileName)
        {
            _jsonFilePath = Path.Combine(Application.StartupPath, jsonFileName);
        }

        public AppConfig LoadConfigData()
        {
            if (!File.Exists(_jsonFilePath))
            {
                AppConfig defaultData = new AppConfig
                {
                    AppVer="0.0.0",
                    TimerSpan="00:05:00"
                };

                SaveStatusData(defaultData);
                return defaultData;
            }
            else
            {
                string jsonContent = File.ReadAllText(_jsonFilePath);
                return JsonConvert.DeserializeObject<AppConfig>(jsonContent);
            }
        }

        public void SaveStatusData(AppConfig appConfig)
        {
            string jsonContent = JsonConvert.SerializeObject(appConfig, Formatting.Indented);
            File.WriteAllText(_jsonFilePath, jsonContent);
        }
    }

}
