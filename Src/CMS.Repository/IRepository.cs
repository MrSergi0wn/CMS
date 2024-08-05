using CMS.Domain;

namespace CMS.Repository;

public interface IRepository
{
    IEnumerable<ComponentModel> GetHeaders();
    IEnumerable<ComponentModel> GetBodies();
    IEnumerable<ComponentModel> GetFooters();
}