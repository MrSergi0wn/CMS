

using System.Diagnostics;
using CMS.AppSettings;
using CMS.Models;
using CMS.Services.DeserializeService;
using CMS.ServicesManager;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicesManager servicesManager;

        private readonly IDeserializeService deserializeService;

        private readonly IAppSettingsConfig appSettingsConfig;

        public HomeController(IServicesManager servicesManager, IAppSettingsConfig appSettingsConfig)
        {
            this.servicesManager = servicesManager;
            this.deserializeService = this.servicesManager!.DeserializeService;
            this.appSettingsConfig = appSettingsConfig;
        }

        public IActionResult Index()
        {
            var templateViewModel =
                this.deserializeService.DeserializeJsonFile(this.appSettingsConfig.GetAppSettings()
                    .JsonFilePath!);

            return View(templateViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
