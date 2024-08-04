using CMS.Models.Models.CMSComponents;
using CMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository repository;

        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetHeaders()
        {
            return Json(this.repository.GetHeaders().Select(component => new BuilderViewModel(component)).ToList());
        }

        public JsonResult GetBodies()
        {
            return Json(this.repository.GetBodies().Select(component => new BuilderViewModel(component)).ToList());
        }

        public JsonResult GetFooters()
        {
            return Json(this.repository.GetFooters().Select(component => new BuilderViewModel(component)).ToList());
        }

        [HttpPost]
        public IActionResult CreateView(HomeViewModel homeViewModel)
        {
            var resultViewModel = new ResultViewModel()
            {
                HeaderOuterHtml = homeViewModel.SelectedHeader,
                BodyOuterHtml = homeViewModel.SelectedBody,
                FooterOuterHtml = homeViewModel.SelectedFooter
            };

            return this.View("ResultView", resultViewModel);
        }
    }
}
