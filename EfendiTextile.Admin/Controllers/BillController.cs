using EfendiTextile.Model;
using EfendiTextile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfendiTextile.Admin.Controllers
{[Authorize]
    public class BillController:Controller
    {
        private readonly ICustomerService customerService;
        private readonly IBillService billService;
        private readonly IProductService productService;
        public BillController(ICustomerService customerService, IBillService billService, IProductService productService) {

            this.customerService = customerService;
            this.billService = billService;
            this.productService = productService;
        }
        public ActionResult Index()
        {
            var bill = billService.GetAll();
            return View(bill);
        }
        public ActionResult Create()
        {
            var bill = new Bill();
            return View(bill);
        }
        [HttpPost]

        public ActionResult Create(Bill bill)
        {
            if (ModelState.IsValid)
            {
                billService.Insert(bill);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(Guid id)
        {

            var bill = billService.Find(id);
            if (bill == null)
            {
                return HttpNotFound();

            }
            return View(bill);
        }
        [HttpPost]

        public ActionResult Edit(Bill bill)
        {
            if (ModelState.IsValid)
            {
                var model = billService.Find(bill.Id);
                model.Description = bill.Description;
                model.Title = bill.Title;


                billService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            billService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            return View(billService.Find(id));
        }

    }
}