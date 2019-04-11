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
    public class OrderController:ControllerBase
    {   
        private readonly IProductService productService;
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService, IProductService productService,ApplicationUserManager userManager):base(userManager)
        {
            this.orderService = orderService;
            this.productService = productService;

        }
        
        public ActionResult Index()
        {
            var order = orderService.GetAll();
            return View(order);

        }
        public ActionResult Create()
        {

            var order = new Order();
            return View(order);

        }
        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                orderService.Insert(order);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(Guid id)
        {

            var order = orderService.Find(id);
            if (order == null)
            {
                return HttpNotFound();

            }
            return View(order);
        }
        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                var model = orderService.Find(order.Id);
                model.UnitPrice = order.UnitPrice;
                model.Quantity = order.Quantity;

                orderService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            orderService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            return View(orderService.Find(id));
        }

    }
}