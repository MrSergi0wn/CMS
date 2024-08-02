using CMS.AppSettings;
using CMS.Models.Models.CMSComponents;
using CMS.ServicesManager;

namespace CMS.Context
{
    public class DomainContext
    {
        private readonly IServicesManager servicesManager;

        private readonly IAppSettingsConfig appSettingsConfig;

        private readonly IEnumerable<ComponentModel> Components;

        public DomainContext(IServicesManager servicesManager, IAppSettingsConfig appSettingsConfig)
        {
            this.servicesManager = servicesManager;
            this.appSettingsConfig = appSettingsConfig;

            var qwe = this.servicesManager.FileSystemService.GetPathToCmsComponents(this.appSettingsConfig!
                .GetAppSettings()
                .JsonFilePath!);
            this.Components = this.servicesManager!.DeserializeService.DeserializeJsonFile(
                qwe).Components;
        }

        public IEnumerable<ComponentModel> GetComponents()
        {
            return this.Components;
        }
    }
}
