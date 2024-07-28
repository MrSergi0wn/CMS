using CMS.Services.DeserializeService;
using CMS.Services.FileSystemService;

namespace CMS.ServicesManager
{
    public class ServicesManager : IServicesManager
    {
        private readonly Lazy<IDeserializeService> deserializeService;

        private readonly Lazy<IFileSystemService> fileSystemService;

        public ServicesManager()
        {
            this.deserializeService = new Lazy<IDeserializeService>(() => new DeserializeService());
            this.fileSystemService = new Lazy<IFileSystemService>(() => new FileSystemService());
        }

        public IDeserializeService DeserializeService => this.deserializeService.Value;

        public IFileSystemService FileSystemService => this.fileSystemService.Value;
    }
}
