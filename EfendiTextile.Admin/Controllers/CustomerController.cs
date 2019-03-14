using EfendiTextile.Model;
using EfendiTextile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfendiTextile.Admin.Controllers
{
    public class CustomerController:Controller
    {
       
        private readonly ICustomerService customerService;
        private readonly IRegionService regionService;
        private readonly ICountryService countryService;
        private readonly ICityService cityService;
        private readonly IDistrictService districtService;
        
        public CustomerController(ICustomerService customerService,IRegionService regionService,ICountryService countryService,ICityService cityService,IDistrictService districtService) {
            this.customerService = customerService;
            this.regionService = regionService;
            this.countryService = countryService;
            this.cityService = cityService;
            this.districtService = districtService;

        }
        public ActionResult Index()
        {
            var customer = customerService.GetAll();
            return View(customer);

        }
        public ActionResult Create()
        {
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "Id", "RegionName");
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "CountryName");
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "CityName");
            ViewBag.DistrictId = new SelectList(regionService.GetAll(), "Id", "DistrictName");
            var customer = new Customer();
            return View(customer);

        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {

            if (ModelState.IsValid)
            {

                customerService.Insert(customer);
                return RedirectToAction("Index");
            }
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "Id", "RegionName", customer.RegionId);
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "CityName", customer.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "CountryName", customer.CountryId);
            ViewBag.DistrictId = new SelectList(districtService.GetAll(), "Id", "DistrictName", customer.DistrictId);




            return View();

        }
        public ActionResult Edit(Guid id)
        {

            var customer = customerService.Find(id);
            if (customer == null)
            {
                return HttpNotFound();

            }
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "Id", "RegionName", customer.RegionId);
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "CityName", customer.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "CountryName", customer.CountryId);
            ViewBag.DistrictId = new SelectList(districtService.GetAll(), "Id", "DistrictName", customer.DistrictId);



            return View(customer);
        }
        [HttpPost]

        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var model = customerService.Find(customer.Id);
                model.CustomerName = customer.CustomerName;
                model.CustomerSurname = customer.CustomerSurname;
                model.Phone = customer.Phone;
                model.Email = customer.Email;
                model.Debt = customer.Debt;
                model.Demand = customer.Demand;
                model.Balance = customer.Balance;
                
                model.Address = customer.Address;
                customerService.Update(model);
                return RedirectToAction("Index");
            }
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "Id", "RegionName", customer.RegionId);
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "CityName", customer.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "CountryName", customer.CountryId);
            ViewBag.DistrictId = new SelectList(districtService.GetAll(), "Id", "DistrictName", customer.DistrictId);



            return View();
        }
        public ActionResult Delete(Guid id)
        {
            customerService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            return View(customerService.Find(id));
        }

    }
}