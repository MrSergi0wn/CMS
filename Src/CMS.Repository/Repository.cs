using CMS.Context;
using CMS.Domain;

namespace CMS.Repository
{
    public class Repository : IRepository
    {
        private readonly IDomainContext domainContext;

        private readonly IEnumerable<ComponentModel> components;

        public Repository(IDomainContext domainContext)
        {
            this.domainContext = domainContext;
            this.components = this.domainContext.GetComponents();
        }

        public IEnumerable<ComponentModel> GetHeaders()
        {
            return this.components.Where(c => c.Type!.Equals("forHeader"));
        }

        public IEnumerable<ComponentModel> GetBodies()
        {
            return this.components.Where(c => c.Type!.Equals("forBody"));
        }

        public IEnumerable<ComponentModel> GetFooters()
        {
            return this.components.Where(c => c.Type!.Equals("forFooter"));
        }
    }
}
