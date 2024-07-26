using CMS.Services.DeserializeService;
using CMS.ServicesManager;
using Xunit;

namespace CMS.UnitTests
{
    public class DeserializeServiceTests
    {
        private readonly IServicesManager servicesManager; 

        private readonly IDeserializeService deserializeService;

        public DeserializeServiceTests(IServicesManager servicesManager)
        {
            this.servicesManager = servicesManager;
            this.deserializeService = this.servicesManager.DeserializeService;
        }

        [Fact]
        public void CanDeserializeJsonFile()
        {
            //this.deserializeService.DeserializeJsonFile()
        }
    }
}
