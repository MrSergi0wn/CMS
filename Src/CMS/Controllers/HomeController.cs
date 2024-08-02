using System.Collections;
using System.Diagnostics;
using CMS.ItemsContainer;
using CMS.Models;
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
            var headersBuilder = this.repository.GetHeaders().Select(component => new BuilderViewModel(component)).ToList();

            return Json(headersBuilder);
        }

        public JsonResult GetBodies()
        {
            var bodiesBuilder = this.repository.GetBodies().Select(component => new BuilderViewModel(component)).ToList();

            return Json(bodiesBuilder);
        }

        public JsonResult GetFooters()
        {
            var footersBuilder = this.repository.GetFooters().Select(component => new BuilderViewModel(component)).ToList();

            return Json(footersBuilder);
        }

        [HttpPost]
        public IActionResult CreateView(HomeViewModel homeViewModel)
        {
            var qwe = new ResultViewModel()
            {
                HeaderOuterHtml = homeViewModel.SelectedHeader,
                BodyOuterHtml = homeViewModel.SelectedBody,
                FooterOuterHtml = homeViewModel.SelectedFooter
            };

            return this.View("ResultView", qwe);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
