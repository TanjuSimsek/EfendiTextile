using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfendiTextile.Admin.Controllers
{
    public class ControllerBase:Controller
    {
        public ApplicationUserManager userManager;
        public ControllerBase(ApplicationUserManager userManager)
        {
            this.userManager = userManager;
        }
        // bu metot tüm actionlardan önce çalışır
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
        // bu metot tüm actionlardan sonra çalışır
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //if (filterContext.Controller.ControllerContext.RouteData.Values["controller"].ToString().ToLower() != "account") { 
            var userName = filterContext.HttpContext.User.Identity.Name;
            var user = userManager.FindByNameAsync(userName).Result;
            //ViewBag.photo = "/Fotograf/" + user.Photo;
            //}
            base.OnActionExecuted(filterContext);
        }


    }
}