using CMS.AppSettings;
using CMS.Domain;
using CMS.ServicesManager;

namespace CMS.Context
{

    public class DomainContext : IDomainContext
    {
        private readonly IServicesManager servicesManager;

        private readonly IAppSettingsConfig appSettingsConfig;

        private readonly IEnumerable<ComponentModel> Components;

        public DomainContext(IServicesManager servicesManager, IAppSettingsConfig appSettingsConfig)
        {
            this.servicesManager = servicesManager;
            this.appSettingsConfig = appSettingsConfig;

            this.Components = this.servicesManager!.DeserializeService.DeserializeJsonFile(
                this.servicesManager.FileSystemService.GetPathToCmsComponents(this.appSettingsConfig!
                    .GetAppSettings()
                    .JsonFilePath!)).Components!;
        }

        public IEnumerable<ComponentModel> GetComponents()
        {
            return this.Components;
        }
    }
}
