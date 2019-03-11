using EfendiTextile.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfendiTextile.Admin.Controllers
{
    public class RegionController:Controller
    {
        private readonly IRegionService regionService;
        public RegionController(IRegionService regionService) {
            this.regionService = regionService;

        }
        public ActionResult Index() {
            var region = regionService.GetAll();
            return View(region);

        }
        public ActionResult Create() {

            var region = new Region();
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "Id", "İlçe");
            return View(region);

        }
        [HttpPost]
        public ActionResult Create(Model.Region region)
        {

            if (ModelState.IsValid) {

                regionService.Insert(region);
                return RedirectToAction("Index");
            }
           
            return View();

        }

    }
}