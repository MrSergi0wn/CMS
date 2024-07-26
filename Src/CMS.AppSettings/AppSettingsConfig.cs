using CMS.Models.Models;
using Microsoft.Extensions.Configuration;

namespace CMS.AppSettings
{
    public class AppSettingsConfig : IAppSettingsConfig
    {
        private readonly AppSettingsModel appSettingsModel;

        private readonly IConfiguration configuration;

        public AppSettingsConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.appSettingsModel = this.CreateAppSettingsConfig();
        }

        public AppSettingsModel GetAppSettings() => this.appSettingsModel;

        private AppSettingsModel CreateAppSettingsConfig()
        {
            return new AppSettingsModel()
            {
                JsonFilePath = this.configuration["CMSComponentsJsonFileName"]
            };
        }

    }
}
