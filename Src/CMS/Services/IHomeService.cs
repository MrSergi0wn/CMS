using CMS.Models.Models.CMSComponents;

namespace CMS.Services;

public interface IHomeService
{
    IEnumerable<BuilderViewModel> GetHeaders();
    IEnumerable<BuilderViewModel> GetBodies();
    IEnumerable<BuilderViewModel> GetFooter();
}