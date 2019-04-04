using EfendiTextile.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfendiTextile.Admin.Controllers
{
    [Authorize]
    public class HomeController : ControllerBase
    {
        public HomeController(ApplicationUserManager userManager) : base(userManager) {

        }
        public ActionResult Index()
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