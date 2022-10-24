using ET.Models;
using ET_BLL.IBllService;
using ET_DAL.Repository;
using ET_ENTITY.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ET.Controllers
{
    public class ExpenseController : Controller
    {
        private IBLLGenericService<DailyExpence> _bLLGenericService1;
        private IBLLGenericService<ExpCategories> _bLLGenericCategory;
        public ExpenseController(IBLLGenericService<DailyExpence> bLLGenericService, IBLLGenericService<ExpCategories> category)
        {
            _bLLGenericService1 = bLLGenericService;
            _bLLGenericCategory = category;
        }
        // GET: ExpenseController
        public ActionResult Index()
        {
            List<DailyExViewModel> dailies = new List<DailyExViewModel>();
            DailyExViewModel model = null;
            List<DailyExpence> dailyExpences = _bLLGenericService1.GetAll().ToList();
            List<ExpCategories> categories = _bLLGenericCategory.GetAll().ToList();

                      var expenseData = (from p in dailyExpences
                          join e in categories
                          on p.categories.CategoryId equals e.CategoryId
                          select new
                          {
                              e.CategoryName,
                              p.ExpenceDate,
                              p.Amount,
                              p.ExpenceId
                              
                          }).ToList();

            foreach (var item in expenseData)
            {
                model = new DailyExViewModel();
                model.ExpenceDate = item.ExpenceDate.ToShortDateString();
                model.Amount = item.Amount;
                model.CategoryName = item.CategoryName;
                model.ExpenceId = item.ExpenceId;
                dailies.Add(model);
            }
            
            return View(dailies);
        }

        // GET: ExpenseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExpenseController/Create
        public ActionResult Create()
        {
            DailyExpenseVModel dailyExpence = new DailyExpenseVModel();
            dailyExpence.categories = _bLLGenericCategory.GetAll().ToList();
            return View(dailyExpence);
        } 

        // POST: ExpenseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DailyExpenseVModel model)
        {
            DailyExpence expence = new DailyExpence();
            try
            {
                if (ModelState.IsValid)
                {
                    expence.ExpenceDate = model.ExpenceDate;
                    expence.Amount = model.Amount;
                    expence.categories = _bLLGenericCategory.GetById(model.CategoryId);
                    expence.categories.CategoryId = model.CategoryId;

                    _bLLGenericService1.AddItems(expence);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExpenseController/Edit/5
        public ActionResult Edit(int id)
        {
            DailyExpence dailyExpence = new DailyExpence();
            try
            {
                dailyExpence = _bLLGenericService1.GetById(id);

                List<SelectListItem> catgories = new List<SelectListItem>();
                catgories = _bLLGenericCategory.GetAll().Select(x => new SelectListItem { Text = x.CategoryName, Value = x.CategoryId.ToString() }).Where(x=>x.Value ==dailyExpence.categories.CategoryId.ToString()).ToList();
                ViewBag.Categories = catgories;
            }
            catch (System.Exception)
            {

                throw;
            }
            return View(dailyExpence);
        }

        // POST: ExpenseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DailyExpence expence)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    expence.ExpenceDate = expence.ExpenceDate;
                    expence.Amount = expence.Amount;
                    expence.categories = _bLLGenericCategory.GetById(expence.CategoryId);
                    expence.categories.CategoryId = expence.CategoryId;

                    _bLLGenericService1.UpdateItem(expence);

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExpenseController/Delete/5
        public ActionResult Delete(int id)
        {
            DailyExpence dailyExpence = _bLLGenericService1.GetById(id);
            return View(dailyExpence);
        }

        // POST: ExpenseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _bLLGenericService1.RemoveItem(id); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchExpense(DailyExViewModel models)
        {
            DateTime fDate = Convert.ToDateTime(models.FromDate);
            DateTime tDate = Convert.ToDateTime(models.ToDate); 
            List<DailyExViewModel> dailies = new List<DailyExViewModel>();
            DailyExViewModel model = null;
            List<DailyExpence> dailyExpences = _bLLGenericService1.GetAll().ToList();
            List<ExpCategories> categories = _bLLGenericCategory.GetAll().ToList();

            var expenseData = (from p in dailyExpences
                               join e in categories
                               on p.categories.CategoryId equals e.CategoryId
                               where p.ExpenceDate <= tDate && p.ExpenceDate >= fDate
                               select new
                               {
                                   e.CategoryName,
                                   p.ExpenceDate,
                                   p.Amount,
                               }).ToList();

            foreach (var item in expenseData)
            {
                model = new DailyExViewModel();
                model.ExpenceDate = item.ExpenceDate.ToShortDateString();
                model.Amount = item.Amount;
                model.CategoryName = item.CategoryName;
                dailies.Add(model);
            }

            return View(dailies);
        }
    }
}
