using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        // GET: AdminCategory
        public ActionResult Index()
        {
            var result = cm.GetList();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            //cm.CategoryAdd(p);
            CategoryValidatior categoryValidatior = new CategoryValidatior(); // validator nesnesi oluşturuldu.
            ValidationResult results = categoryValidatior.Validate(p); // parametreden gelen p yi categoryValidatior nesnesindeki değerleri validate et.
            if (results.IsValid)
            {
                cm.CategoryAddBL(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(); // ekleme işlemi gerçekleştikten sonra "" içindeki metoda yönlendir.
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = cm.GetById(id);
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var categoryvalue = cm.GetById(id);
            return View(categoryvalue);

        }

        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
            //cm.CategoryAdd(p);
            CategoryValidatior categoryValidatior = new CategoryValidatior(); // validator nesnesi oluşturuldu.
            ValidationResult results = categoryValidatior.Validate(p); // parametreden gelen p yi categoryValidatior nesnesindeki değerleri validate et.
            if (results.IsValid)
            {
                cm.CategoryAddBL(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(); // ekleme işlemi gerçekleştikten sonra "" içindeki metoda yönlendir.
        }
    }
}