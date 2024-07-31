using CMS.AppSettings;
using CMS.Models.Models.CMSComponents;
using CMS.ServicesManager;

namespace CMS.ItemsContainer
{
    public class ComponentsContainer : IComponentsContainer
    {
        private readonly IServicesManager serviceManager;

        private readonly IAppSettingsConfig appSettingsConfig;

        private readonly CmsComponents Components;

        private IEnumerable<Header>? Headers {get; set; }

        private IEnumerable<Body>? Bodies {get; set; }

        private IEnumerable<Footer>? Footers {get; set; }

        public ComponentsContainer(IServicesManager serviceManager, IAppSettingsConfig appSettingsConfig)
        {
            this.serviceManager = serviceManager;
            this.appSettingsConfig = appSettingsConfig;

            this.Components = this.serviceManager!.DeserializeService.DeserializeJsonFile(
                this.serviceManager.FileSystemService.GetPathToCmsComponents(this.appSettingsConfig!.GetAppSettings()
                    .JsonFilePath!))!;

            this.Headers = this.Components.Headers;
            this.Bodies = this.Components.Bodies;
            this.Footers = this.Components.Footers!;
        }

        public CmsComponents GetComponents()
        {
            return this.Components!;
        }

        public IEnumerable<T>? GetComponentsCollection<T>() where T : IViewComponent
        {
            return typeof(T).Name switch
            {
                nameof(Header) => (IEnumerable<T>)this.Headers!,
                nameof(Body) => (IEnumerable<T>)this.Bodies!,
                nameof(Footer) => (IEnumerable<T>)this.Footers!,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
