using CMS.Models.Models.CMSComponents;
using CMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        public readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public IActionResult Index()
        {
            return View(new HomeViewModel());
        }

        public JsonResult GetHeaders()
        {
            return Json(this.homeService.GetHeaders());
        }

        public JsonResult GetBodies()
        {
            return Json(this.homeService.GetBodies());
        }

        public JsonResult GetFooters()
        {
            return Json(this.homeService.GetFooter());
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
