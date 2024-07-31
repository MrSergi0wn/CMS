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

        //public IActionResult Create(IEnumerable<Template> templates)
        //{

        //}

        public JsonResult GetHeaders()
        {
            return Json(this.componentsContainer.GetComponentsCollection<Header>()!);
        }

        public JsonResult GetBodies()
        {
            return Json(this.componentsContainer.GetComponentsCollection<Body>()!);
        }

        public JsonResult GetFooters()
        {
            return Json(this.componentsContainer.GetComponentsCollection<Footer>()!);
        }

        [HttpPost]
        public IActionResult CreateView(CmsComponents cmsComponents)
        {
            var qwe = new SelectedCmsComponent()
            {
                SelectedHeader =
                    this.componentsContainer.GetComponentsCollection<Header>()!.FirstOrDefault(header =>
                        header.Id.Equals(cmsComponents.SelectedHeaderId)),
                SelectedBody =
                    this.componentsContainer.GetComponentsCollection<Body>()!.FirstOrDefault(body =>
                        body.Id.Equals(cmsComponents.SelectedBodyId)),
                SelectedFooter =
                    this.componentsContainer.GetComponentsCollection<Footer>()!.FirstOrDefault(footer =>
                        footer.Id.Equals(cmsComponents.SelectedFooterId))
            };

            return this.View("NewView",qwe);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
