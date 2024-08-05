using CMS.Models.Models.CMSComponents;
using CMS.Repository;

namespace CMS.Services
{
    public class HomeService : IHomeService
    {
        public readonly IRepository repository;

        public HomeService(IRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<BuilderViewModel> GetHeaders()
        {
            return this.repository.GetHeaders().Select(component => new BuilderViewModel(component));
        }

        public IEnumerable<BuilderViewModel> GetBodies()
        {
            return this.repository.GetBodies().Select(component => new BuilderViewModel(component));
        }

        public IEnumerable<BuilderViewModel> GetFooter()
        {
            return this.repository.GetFooters().Select(component => new BuilderViewModel(component));
        }
    }
}
