using CMS.Models.Models.CMSComponents;

namespace CMS.Services.DeserializeService;

public interface IDeserializeService
{
    CmsComponents DeserializeJsonFile(string jsonFilePath);
}