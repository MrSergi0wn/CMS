using CMS.Services.DeserializeService;
using CMS.Services.FileSystemService;

namespace CMS.ServicesManager;

public interface IServicesManager
{
    IDeserializeService DeserializeService { get; }

    IFileSystemService FileSystemService { get; }
}