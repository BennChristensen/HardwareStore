using HardwareStoreCommon.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly HardwareStoreContext dbContext = new HardwareStoreContext();
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel();
            viewModel.Tools = dbContext.GetAvailableTools();
            return View(viewModel);
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}