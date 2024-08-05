using CMS.Models.Models.CMSComponents;
using CMS.Services;
using Xunit;

namespace CMS.UnitTests
{
    public class ServiceTests : IClassFixture<TestStartup>
    {
        private readonly IHomeService homeService;

        public ServiceTests(TestStartup testStartup)
        {
            this.homeService = testStartup.GetService<IHomeService>();
        }

        [Fact]
        public void CheckHomeService()
        {
            var headers = this.homeService.GetHeaders();
            Assert.NotNull(headers);
            Assert.IsType<BuilderViewModel>(headers.FirstOrDefault());

            var bodies = this.homeService.GetBodies();
            Assert.NotNull(this.homeService.GetBodies());
            Assert.IsType<BuilderViewModel>(bodies.FirstOrDefault());

            var footer = this.homeService.GetFooter();
            Assert.NotNull(this.homeService.GetFooter());
            Assert.IsType<BuilderViewModel>(footer.FirstOrDefault());
        }
    }
}
