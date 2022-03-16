using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery
{
    internal static class AppService
    {
        private static readonly string basePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        public static T InitOptions<T>(string section) where T : new()
        {
            var config = InitConfig();
            var configBinder = new T();
            config.GetSection(section).Bind(configBinder);
            return configBinder;
        }
        public static bool AddOrUpdateAppSetting<T>(string sectionPathKey, T value)
        {
            try
            {
                var filePath = Path.Combine(basePath, "appsettings.json");
                //var newFilePath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
                //var filePath = Path.GetFullPath("appsettings.json");
                //var filePath = "appsettings.json";
                var configJson = File.ReadAllText(filePath);
                var settings = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>> (configJson);
                settings[sectionPathKey] = value;
                var updatedConfigJson = Newtonsoft.Json.JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, updatedConfigJson);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing app settings | {0}", ex.Message);
                return false;
            }
        }

        public static IConfigurationRoot InitConfig() => new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile($"appsettings.json", true, true)
                .AddEnvironmentVariables()
                .Build();

        public static string GetBasePath() => basePath;
    }
}
