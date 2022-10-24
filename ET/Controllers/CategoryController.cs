using ET_ENTITY.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using ET_BLL.IBllService;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ET.Controllers
{
    public class CategoryController : Controller
    {
        private IBLLGenericService<ExpCategories> _bLLGenericService;
        public CategoryController(IBLLGenericService<ExpCategories> service)
        {
            _bLLGenericService=service; 
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            List<ExpCategories> expCategories = _bLLGenericService.GetAll().ToList();
            return View(expCategories);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpCategories model) 
        {
            try
            {
                List<ExpCategories> expCategories = _bLLGenericService.GetAll().ToList();

                var catValue = expCategories.FirstOrDefault(x => x.CategoryName == model.CategoryName);

                if (catValue != null)
                {
                    ViewBag.CategoryName = "Category is already exist!";
                    return View();
                }

                _bLLGenericService.AddItems(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/0
        public ActionResult Edit(int id)
        {
            ExpCategories expCategory = _bLLGenericService.GetById(id);
            return View(expCategory);
        }

        // POST: Category/Edit/0
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ExpCategories model)
        {
            ExpCategories categories = new ExpCategories();
            try
            {
                List<ExpCategories> expCategories = _bLLGenericService.GetAll().ToList();

                if (expCategories.Any(x => x.CategoryName == model.CategoryName))
                {
                    ViewBag.CategoryName = "Category is already exist!";
                    return View();
                }
                categories.CategoryName = model.CategoryName;
                categories.CategoryId = model.CategoryId;
                _bLLGenericService.UpdateItem(categories);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Category/Delete/0
        public ActionResult Delete(int id)
        {
            ExpCategories expCategory = _bLLGenericService.GetById(id);

            return View(expCategory);
        }

        // POST: Category/Delete/0
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _bLLGenericService.RemoveItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
