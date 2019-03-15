﻿using EfendiTextile.Data;
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
      
        
        public CustomerController(ICustomerService customerService,IRegionService regionService,ICountryService countryService,ICityService cityService) {
            this.customerService = customerService;
            this.regionService = regionService;
            this.countryService = countryService;
            this.cityService = cityService;
           

        }
        public ActionResult Index()
        {
            var customer = customerService.GetAll();
            return View(customer);

        }
        public ActionResult GetCities(Guid? countryId)
        {
            using (var db = new ApplicationDbContext())
            {
                var cities = db.Cities.Where(c => c.CountryId == countryId).OrderBy(o => o.CityName).Select(x => new { x.Id, x.CityName }).ToList();
                return Json(cities);
            }
        }
        public ActionResult GetRegions(Guid? cityId)
        {
            using (var db = new ApplicationDbContext())
            {
                var regions = db.Regions.Where(c => c.CityId == cityId).OrderBy(o => o.RegionName).Select(x => new { x.Id, x.RegionName }).ToList();
                return Json(regions);
            }
        }
        public ActionResult Create()
        {
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "Id", "RegionName");
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "CountryName");
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "CityName");
           
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