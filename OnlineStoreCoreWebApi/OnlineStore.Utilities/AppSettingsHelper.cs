using System;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace OnlineStore.Utilities
{
    public class AppSettingsHelper
    {
        public static string GetAppSettings(string key)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfigurationRoot Configuration = builder.Build();

            var value = Configuration.GetSection($"AppSettings:{key}").Value;

            return value;
        }
    }
}
