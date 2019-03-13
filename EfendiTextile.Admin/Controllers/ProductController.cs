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
    public class ProductController:Controller
    {
       
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        public ProductController(ICategoryService categoryService, IProductService productService) {
            this.categoryService = categoryService;
            this.productService = productService;

        }
        public ActionResult Index() {
            var product = productService.GetAll();
            return View(product);
        }
        public ActionResult Create()
        {
            var product = new Product();
            return View(product);
        }
        [HttpPost]
      
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
               productService.Insert(product);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(Guid id)
        {

            var product = productService.Find(id);
            if (product == null)
            {
                return HttpNotFound();

            }
            return View(product);
        }
        [HttpPost]
    
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var model = productService.Find(product.Id);
                model.ProductName = product.ProductName;
                model.QuantityPerUnit = product.QuantityPerUnit;
                model.BuyyingPrice = product.BuyyingPrice;
                model.UnıtsInStock = product.UnıtsInStock;
              
                productService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
           productService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            return View(productService.Find(id));
        }
    }
}