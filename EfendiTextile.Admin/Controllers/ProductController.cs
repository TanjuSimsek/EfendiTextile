using EfendiTextile.Model;
using EfendiTextile.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfendiTextile.Admin.Controllers
{
    [Authorize]
    public class ProductController:ControllerBase
    {
       
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        public ProductController(ICategoryService categoryService, IProductService productService,ApplicationUserManager userManager):base(userManager) {
            this.categoryService = categoryService;
            this.productService = productService;

        }
        public ActionResult Index() {
            var product = productService.GetAll();
            return View(product);
        }
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "CategoryName");
            var product = new Product();
            return View(product);
        }
        [HttpPost]
      
        public ActionResult Create(Product product, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(upload.FileName);
                    string extension = Path.GetExtension(fileName).ToLower();
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                    {
                        string path = Path.Combine(ConfigurationManager.AppSettings["uploadPath"], fileName);
                        upload.SaveAs(path);
                        product.Photo = fileName;
                        productService.Insert(product);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");
                    }
                }
                else
                {
                    productService.Insert(product);
                    return RedirectToAction("index");
                }

            }

            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "CategoryName",product.CategoryId);
            return View();
        }
        public ActionResult Edit(Guid id)
        {

            var product = productService.Find(id);
            if (product == null)
            {
                return HttpNotFound();

            }
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "CategoryName", product.CategoryId);
            return View(product);
        }
        [HttpPost]
    
        public ActionResult Edit(Product product, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                var model = productService.Find(product.Id);
                if (upload != null && upload.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(upload.FileName);
                    string extension = Path.GetExtension(fileName).ToLower();
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                    {
                        string path = Path.Combine(ConfigurationManager.AppSettings["uploadPath"], fileName);
                        upload.SaveAs(path);
                        model.Photo = fileName;
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");
                    }
                }
                
                model.ProductName = product.ProductName;
                model.QuantityPerUnit = product.QuantityPerUnit;
                model.BuyyingPrice = product.BuyyingPrice;
                model.UnıtsInStock = product.UnıtsInStock;
              
                productService.Update(model);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "CategoryName",product.CategoryId);
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