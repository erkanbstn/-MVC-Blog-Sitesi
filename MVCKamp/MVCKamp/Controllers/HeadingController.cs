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
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        HeadingValidation hv = new HeadingValidation();
        public ActionResult MainHeading()
        {
            var x = hm.Listele();
            return View(x);
        }
        public ActionResult HeadingReport()
        {
            var x = hm.Listele();
            return View(x);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> deger = (from x in cm.Listele()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryID.ToString()
                                          }).ToList();

            List<SelectListItem> deger2 = (from c in wm.Listele()
                                           select new SelectListItem
                                           {
                                               Text = c.WriterName + " " + c.WriterSurname,
                                               Value = c.WriterID.ToString()
                                           }).ToList();
            ViewBag.dgr = deger;
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading h)
        {
            ValidationResult vr = hv.Validate(h);
            if (vr.IsValid)
            {
                
                h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                hm.TEkle(h);
                return RedirectToAction("MainHeading");
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
        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> deger2 = (from c in wm.Listele()
                                           select new SelectListItem
                                           {
                                               Text = c.WriterName + " " + c.WriterSurname,
                                               Value = c.WriterID.ToString()
                                           }).ToList();
            List<SelectListItem> deger = (from x in cm.Listele()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryID.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;
            ViewBag.dgr2 = deger2;

            var x2 = hm.IDGetir(id);
            return View(x2);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading h)
        {
            ValidationResult vr = hv.Validate(h);
            if (vr.IsValid)
            {
                h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                hm.TGuncelle(h);
                return RedirectToAction("MainHeading");
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
        public ActionResult DeleteHeading(int id)
        {
            var x = hm.IDGetir(id);
            x.HeadingStatus = false;
            hm.TSil(x);
            return RedirectToAction("MainHeading");
        }
    }
}