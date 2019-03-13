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
        private readonly IDistrictService districtService;
        private readonly ICountryService countryService;
        private readonly ICityService cityService;
       // private readonly ICustomerService customerService;
        public RegionController(IRegionService regionService, IDistrictService districtService, ICountryService countryService, ICityService cityService) {
            this.regionService = regionService;
            this.districtService = districtService;
            this.countryService = countryService;
            this.cityService = cityService;
           // this.customerService = customerService;

        }
        public ActionResult Index() {
            var region = regionService.GetAll();
            return View(region);

        }
        public ActionResult Create() {

            var region = new Region();
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
        public ActionResult Edit(Guid id)
        {

            var region = regionService.Find(id);
            if (region == null)
            {
                return HttpNotFound();

            }
            return View(region);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Model.Region region)
        {
            if (ModelState.IsValid)
            {
                var model = regionService.Find(region.Id);
                model.RegionName = region.RegionName;
                model.CityId = region.CityId;
                regionService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            regionService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            return View(regionService.Find(id));
        }

    }
}