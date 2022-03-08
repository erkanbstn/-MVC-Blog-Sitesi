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

namespace MVCKamp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryValidation cv = new CategoryValidation();

        CategoryManager m = new CategoryManager(new EFCategoryDal());
        [Authorize(Roles="B")]
        public ActionResult MainCategory()
        {
            var kategoriler = m.Listele();
            return View(kategoriler);

        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            ValidationResult vr = cv.Validate(c);
            if (vr.IsValid)
            {
                m.TEkle(c);
                return RedirectToAction("MainCategory");

            }
            else
            {
                foreach (var item in vr.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var x = m.IDGetir(id);
            m.TSil(x);
            return RedirectToAction("MainCategory");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var u = m.IDGetir(id);
            return View(u);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category c)
        {
            ValidationResult vr = cv.Validate(c);
            if (vr.IsValid)
            {
                m.TGuncelle(c);
                return RedirectToAction("MainCategory");
            }
            else
            {
                foreach(var item in vr.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}