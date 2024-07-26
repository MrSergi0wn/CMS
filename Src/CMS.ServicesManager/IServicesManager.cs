using CMS.Services.DeserializeService;

namespace CMS.ServicesManager;

public interface IServicesManager
{
    IDeserializeService DeserializeService { get; }
}