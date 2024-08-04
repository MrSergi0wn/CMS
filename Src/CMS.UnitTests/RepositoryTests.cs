using CMS.Domain;
using CMS.Models.Models.CMSComponents;
using CMS.Repository;
using Xunit;

namespace CMS.UnitTests
{
    public class RepositoryTests : IClassFixture<TestStartup>
    {
        private readonly IRepository repository;

        public RepositoryTests(TestStartup testStartup)
        {
            this.repository = testStartup.GetService<IRepository>();
        }

        [Fact]
        public void RepositoryNotNull()
        {
            Assert.NotNull(this.repository);
        }

        [Fact]
        public void CanGetComponentsFromRepository()
        {
            var headers = this.repository.GetHeaders();
            Assert.NotNull(headers);
            Assert.IsType<ComponentModel>(headers.FirstOrDefault());

            var bodies = this.repository.GetBodies();
            Assert.NotNull(bodies);
            Assert.IsType<ComponentModel>(bodies.FirstOrDefault());

            var footers = this.repository.GetFooters();
            Assert.NotNull(footers);
            Assert.IsType<ComponentModel>(footers.FirstOrDefault());
        }

        [Fact]
        public void ValidateHeaderComponent()
        {
            var headers = this.repository.GetHeaders();
            var header = headers.FirstOrDefault();
            Assert.NotNull(header);

            Assert.Equivalent(header, new ComponentModel()
            {
                ComponentName = "Заголовок №1",
                Type = "forHeader",
                Properties = new Dictionary<string, string>()
                {
                    {"rep_tag", "div"},
                    {"rep_color", "black"},
                    {"rep_class", "form-label"}
                },
                HtmlTemplate = "PHJlcF90YWcgY2xhc3M9InJlcF9jbGFzcyIgc3R5bGU9ImNvbG9yOnJlcF9jb2xvciI+" +
                               "DQogICAg0JDRgNGF0LjRgtC10LrRgtGD0YDQsCDQuCDRiNCw0LHQu9C+0L3RiyDQv9GA" +
                               "0L7QtdC60YLQuNGA0L7QstCw0L3QuNGPDQogICAgPGg1IGNsYXNzPSJyZXBfY2xhc3Mi" +
                               "PtCf0YDQuNC80LXQvdGP0LnRgtC1INGI0LDQsdC70L7QvdGLINC/0YDQvtC10LrRgtC4" +
                               "0YDQvtCy0LDQvdC40Y8g0LggU09MSUQg0LIg0YDQsNC30YDQsNCx0L7RgtC60LU8L2g1" +
                               "Pg0KPC9yZXBfdGFnPg=="
            });
        }

        [Fact]
        public void CheckThatOuterHtmlIsNullWhenHtmlTemplateEmpty()
        {
            var component = new ComponentModel()
            {
                ComponentName = "Заголовок №1",
                Type = "forHeader",
                Properties = new Dictionary<string, string>()
                {
                    {"rep_tag", "div"},
                    {"rep_color", "black"},
                    {"rep_class", "form-label"}
                },
                HtmlTemplate = ""
            };

            Assert.Equal(component.OuterHtml, string.Empty);
        }
    }
}
