using CMS.AppSettings;
using CMS.Domain;
using CMS.Models.Models.CMSComponents;
using CMS.Services.DeserializeService;
using CMS.Services.FileSystemService;
using CMS.ServicesManager;
using Xunit;

namespace CMS.UnitTests
{
    public class DeserializeServiceTests : IClassFixture<TestStartup>
    {
        private readonly IServicesManager servicesManager;

        private readonly IDeserializeService deserializeService;

        private readonly IFileSystemService fileSystemService;

        private readonly IAppSettingsConfig appSettingsConfig;

        public DeserializeServiceTests(TestStartup testStartup)
        {
            this.servicesManager = testStartup.GetService<IServicesManager>();
            this.appSettingsConfig = testStartup.GetService<IAppSettingsConfig>();
            this.deserializeService = testStartup.GetService<IDeserializeService>();
            this.fileSystemService = testStartup.GetService<IFileSystemService>();
        }

        [Fact]
        public void CanGetJsonFilePath()
        {
            Assert.NotNull(this.fileSystemService.GetPathToCmsComponents(this.appSettingsConfig!.GetAppSettings().JsonFilePath!));
        }

        [Fact]
        public void CanDeserializeJsonFileAndCheckContent()
        {
            var deserializedJsonFile = this.deserializeService.DeserializeJsonFile(
                this.fileSystemService.GetPathToCmsComponents(this.appSettingsConfig!.GetAppSettings().JsonFilePath!));

            Assert.NotNull(deserializedJsonFile);
            Assert.IsType<Root>(deserializedJsonFile);
            Assert.IsType<List<ComponentModel>>(deserializedJsonFile.Components);
            Assert.True(deserializedJsonFile.Components.Count > 0);
        }
    }
}
