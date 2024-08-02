namespace CMS.Services.FileSystemService
{
    public class FileSystemService : IFileSystemService
    {
        public string GetBaseDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public string GetPathToCmsComponents(string fileName)
        {
            return Path.Combine(this.GetBaseDirectory(), fileName);
        }
    }
}
