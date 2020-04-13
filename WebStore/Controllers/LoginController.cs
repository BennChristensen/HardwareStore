using HardwareStoreCommon.Models;
using HardwareStoreCommon.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class LoginController : Controller
    {
        private readonly HardwareStoreContext dbContext = new HardwareStoreContext();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login)
        {

            Customer foundCustomer = dbContext.Customers.Where(c => c.UserName == login.UserName).FirstOrDefault();
            if (foundCustomer == null)
            {
                login.ErrorMessage = "Der er ingen kunder med det brugernavn. Forsøg igen";
                login.UserName = "";
                return View("../Home/Login", login);
            }
            return View("../Home/Index", new HomeViewModel { Customer = foundCustomer, Tools = dbContext.GetAvailableTools()});
        }
    }
}