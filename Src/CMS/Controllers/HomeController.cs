using System.Collections;
using System.Diagnostics;
using CMS.ItemsContainer;
using CMS.Models;
using CMS.Models.Models.CMSComponents;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IComponentsContainer componentsContainer;


        public HomeController(IComponentsContainer componentsContainer)
        {
            this.componentsContainer = componentsContainer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetHeaders()
        {
            var qwe = this.componentsContainer.GetComponents().Components.Where(c => c.Type.Equals("forHeader"));
            return Json(qwe);
        }

        public JsonResult GetBodies()
        {
            return Json(this.componentsContainer.GetComponents().Components.Where(c => c.Type.Equals("forBody")));
        }

        public JsonResult GetFooters()
        {
            return Json(this.componentsContainer.GetComponents().Components.Where(c => c.Type.Equals("forFooter")));
        }

        [HttpPost]
        public IActionResult CreateView(Root cmsComponents)
        {
            return this.View("NewView", cmsComponents);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
