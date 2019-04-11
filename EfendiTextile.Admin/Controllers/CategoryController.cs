using EfendiTextile.Model;
using EfendiTextile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfendiTextile.Admin.Controllers
{
    public class CategoryController:ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService,ApplicationUserManager userManager):base(userManager) {

            this.categoryService = categoryService;

        }
        public ActionResult Index()
        {
            var region = categoryService.GetAll();
            return View(region);

        }
        public ActionResult Create()
        {

            var category = new Category();
            return View(category);

        }
        [HttpPost]
        public ActionResult Create(Category category)
        {

            if (ModelState.IsValid)
            {

                categoryService.Insert(category);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(Guid id)
        {

            var category = categoryService.Find(id);
            if (category == null)
            {
                return HttpNotFound();

            }
            return View(category);
        }
        [HttpPost]
      
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var model = categoryService.Find(category.Id);
                model.CategoryName = category.CategoryName;
                model.Description = category.Description;
                categoryService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            categoryService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            return View(categoryService.Find(id));
        }
    }
}