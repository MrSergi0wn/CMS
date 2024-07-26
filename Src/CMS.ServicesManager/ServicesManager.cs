using CMS.Services.DeserializeService;

namespace CMS.ServicesManager
{
    public class ServicesManager : IServicesManager
    {
        private readonly Lazy<IDeserializeService> deserializeService;

        public ServicesManager()
        {
            this.deserializeService = new Lazy<IDeserializeService>(() => new DeserializeService());
        }

        public IDeserializeService DeserializeService => this.deserializeService.Value;
    }
}
