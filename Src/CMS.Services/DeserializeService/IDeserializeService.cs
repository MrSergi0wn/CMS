using CMS.Models.ViewModels;

namespace CMS.Services.DeserializeService;

public interface IDeserializeService
{
    TemplateViewModel DeserializeJsonFile(string jsonFilePath);
}