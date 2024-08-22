using CMS.Domain;

namespace CMS.Context;

public interface IDomainContext
{
    IEnumerable<ComponentModel> GetComponents();
}