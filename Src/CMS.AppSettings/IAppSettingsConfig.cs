using CMS.Models.Models;

namespace CMS.AppSettings;

public interface IAppSettingsConfig
{
    AppSettingsModel GetAppSettings();
}