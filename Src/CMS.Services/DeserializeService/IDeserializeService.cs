using CMS.Models.Models.CMSComponents;

namespace CMS.Services.DeserializeService;

public interface IDeserializeService
{
    IEnumerable<Template> DeserializeJsonFile(string jsonFilePath);
}