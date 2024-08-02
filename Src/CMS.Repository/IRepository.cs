using CMS.Models.Models.CMSComponents;

namespace CMS.Repository;

public interface IRepository
{
    IEnumerable<ComponentModel> GetHeaders();
    IEnumerable<ComponentModel> GetBodies();
    IEnumerable<ComponentModel> GetFooters();
}