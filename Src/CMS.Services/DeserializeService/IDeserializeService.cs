using CMS.Models.Models.CMSComponents;

namespace CMS.Services.DeserializeService;

public interface IDeserializeService
{
    Root DeserializeJsonFile(string jsonFilePath);
}