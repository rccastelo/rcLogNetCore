using System.IO;
using Microsoft.Extensions.Configuration;

namespace rcLogWebNetCore
{
     public class Settings
    {
        private static string GetSettings(string pSecao, string pChave) 
        {
            IConfigurationRoot configuration;
            IConfigurationSection section;

            ConfigurationBuilder builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            
            configuration = builder.Build();

            section = configuration.GetSection(pSecao);

            return section.GetValue<string>(pChave);
        }

        public static string GetSetting(string pChave)
        {
            return GetSettings("Settings", pChave);
        }

        public static string GetConnectionString()
        {
            return GetSettings("ConnectionStrings", "DefaultConnection");
        }

        public static string GetConnectionString(string pChave)
        {
            return GetSettings("ConnectionStrings", pChave);
        }
    }
}
