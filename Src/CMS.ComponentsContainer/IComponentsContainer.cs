using CMS.Models.Models.CMSComponents;

namespace CMS.ItemsContainer;

public interface IComponentsContainer
{
    CmsComponents GetComponents();

    IEnumerable<T>? GetComponentsCollection<T>() where T : IViewComponent;
}