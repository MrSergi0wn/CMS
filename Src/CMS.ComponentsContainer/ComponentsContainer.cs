using CMS.AppSettings;
using CMS.Models.Models.CMSComponents;
using CMS.ServicesManager;

namespace CMS.ItemsContainer
{
    public class ComponentsContainer : IComponentsContainer
    {
        private readonly IServicesManager serviceManager;

        private readonly IAppSettingsConfig appSettingsConfig;

        private readonly Root Components;

        public ComponentsContainer(IServicesManager serviceManager, IAppSettingsConfig appSettingsConfig)
        {
            this.serviceManager = serviceManager;
            this.appSettingsConfig = appSettingsConfig;

            this.Components = this.serviceManager!.DeserializeService.DeserializeJsonFile(
                this.serviceManager.FileSystemService.GetPathToCmsComponents(this.appSettingsConfig!.GetAppSettings()
                    .JsonFilePath!))!;
        }

        public Root GetComponents()
        {
            return this.Components!;
        }
    }
}
