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
    public class WriterController : Controller
    {
        // GET: Writer


        WriterManager wm = new WriterManager(new EFWriterDal());
        WriterValidation wv = new WriterValidation();
        public ActionResult MainWriter()
        {
            var x = wm.Listele();
            return View(x);
        }
        public ActionResult DeleteWriter(int id)
        {
            var x = wm.IDGetir(id);
            wm.TSil(x);
            return RedirectToAction("MainWriter");
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer w)
        {
            ValidationResult vr = wv.Validate(w);
            if (vr.IsValid)
            {
                w.WriterStatus = true;
                wm.TEkle(w);
                return RedirectToAction("MainWriter");
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
        public ActionResult UpdateWriter(int id)
        {
            var x = wm.IDGetir(id);
            return View(x);
        }
        [HttpPost]
        public ActionResult UpdateWriter(Writer c)
        {
            ValidationResult vr = wv.Validate(c);
            if (vr.IsValid)
            {
                wm.TGuncelle(c);
                return RedirectToAction("MainWriter");
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