using EfendiTextile.Data;
using EfendiTextile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfendiTextile.Admin.Controllers
{
    [Authorize]
    public class HomeController : ControllerBase
    {   private readonly IProductService productService;
        public HomeController(ApplicationUserManager userManager, IProductService productService) : base(userManager) {
            this.productService = productService;
        }
        public ActionResult Index()
        {
            ViewBag.UserCount = userManager.Users.Count();
            ViewBag.ProductCount = productService.GetAll().Count();
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