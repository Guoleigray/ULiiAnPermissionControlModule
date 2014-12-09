using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PermissionModule;
using Sample.Models;

namespace Sample.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string userName, string password)
        {
            if (userName.ToUpperInvariant() == "ULIIAN" && password.ToUpperInvariant() == "123456")
            {
                Session[SessionName.PermissionSessionName] = new List<PermissionModel>()
                {
                    new PermissionModel() {ResourceName = "aaa"},
                    new PermissionModel() {ResourceName = "ccc"}
                };
                return RedirectToAction("Test1");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ResourceCustomerName("aaa")]
        public ActionResult Test1()
        {
            return View();
        }

        [HttpPost]
        [ResourceCustomerName("bbb")]
        public ActionResult Test1(int id)
        {
            return View();
        }

        [ResourceCustomerName("ccc")]
        public ActionResult Test2()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult NoPermission()
        {
            return View();
        }
    }
}
