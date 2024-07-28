namespace CMS.Services.FileSystemService;

public interface IFileSystemService
{
    string GetBaseDirectory();
    string GetPathToCmsComponents(string fileName);
}