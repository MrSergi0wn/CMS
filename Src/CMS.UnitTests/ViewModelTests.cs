using CMS.Domain;
using CMS.Models.Models.CMSComponents;
using CMS.Repository;
using Xunit;

namespace CMS.UnitTests
{
    public class ViewModelTests : IClassFixture<TestStartup>
    {
        private readonly IRepository repository;

        private readonly HomeViewModel homeViewModel;

        private readonly ResultViewModel resultViewModel;

        public ViewModelTests(TestStartup testStartup)
        {
            this.repository = testStartup.GetService<IRepository>();

            this.homeViewModel = new HomeViewModel()
            {
                SelectedHeader = this.repository.GetHeaders().Select(component => new BuilderViewModel(component)).First().OuterHtml,
                SelectedBody = this.repository.GetBodies().Select(component => new BuilderViewModel(component)).First().OuterHtml,
                SelectedFooter = this.repository.GetFooters().Select(component => new BuilderViewModel(component)).First().OuterHtml
            };

            this.resultViewModel = new ResultViewModel()
            {
                HeaderOuterHtml = this.homeViewModel.SelectedHeader,
                BodyOuterHtml = this.homeViewModel.SelectedBody,
                FooterOuterHtml = this.homeViewModel.SelectedFooter
            };
        }

        [Fact]
        public void CheckHomeViewMode()
        {
            Assert.NotNull(this.homeViewModel);
            Assert.IsType<HomeViewModel>(this.homeViewModel);
            Assert.NotEmpty(this.homeViewModel.SelectedHeader!);
            Assert.NotEmpty(this.homeViewModel.SelectedBody!);
            Assert.NotEmpty(this.homeViewModel.SelectedFooter!);
        }

        [Fact]
        public void CheckBuilderViewModel()
        {
            var newBuilderViewModel = new BuilderViewModel(this.repository.GetHeaders().First());

            Assert.NotNull(newBuilderViewModel);
            Assert.IsType<BuilderViewModel>(newBuilderViewModel);
            Assert.NotEmpty(newBuilderViewModel.ComponentName);
            Assert.NotEmpty(newBuilderViewModel.ComponentClass);
            Assert.NotEmpty(newBuilderViewModel.ComponentColor);
            Assert.NotEmpty(newBuilderViewModel.ComponentTag);
        }

        [Fact]
        public void CheckResultViewModel()
        {
            Assert.NotNull(this.resultViewModel);
            Assert.IsType<ResultViewModel>(this.resultViewModel);
            Assert.NotEmpty(this.resultViewModel.HeaderOuterHtml!);
            Assert.NotEmpty(this.resultViewModel.BodyOuterHtml!);
            Assert.NotEmpty(this.resultViewModel.FooterOuterHtml!);
        }

    }
}
