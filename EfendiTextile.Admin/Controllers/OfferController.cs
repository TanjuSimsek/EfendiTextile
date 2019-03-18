using EfendiTextile.Model;
using EfendiTextile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfendiTextile.Admin.Controllers
{
    [Authorize]
    public class OfferController:Controller
    {
        private readonly IProductService productService;
        private readonly ICustomerService customerService;
        private readonly IOfferService offerService;
        public OfferController(IProductService productService, ICustomerService customerService, IOfferService offerService) {
            this.productService = productService;
            this.customerService = customerService;
            this.offerService = offerService;

        }
        public ActionResult Index()
        {
            var offer = offerService.GetAll();
            return View(offer);
        }
        public ActionResult Create()
        {
            ViewBag.OfferId = new SelectList(offerService.GetAll(), "Id", "CategoryName");
            var product = new Product();
            return View(product);
        }
        [HttpPost]

        public ActionResult Create(Offer offer)
        {
            if (ModelState.IsValid)
            {
                offerService.Insert(offer);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(Guid id)
        {

            var offer = offerService.Find(id);
            if (offer == null)
            {
                return HttpNotFound();

            }
            return View(offer);
        }
        [HttpPost]

        public ActionResult Edit(Offer offer)
        {
            if (ModelState.IsValid)
            {
                var model = offerService.Find(offer.Id);
                model.Description = offer.Description;
                model.OfferPrice = offer.OfferPrice;
                

                offerService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            offerService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            return View(offerService.Find(id));
        }

    }
}