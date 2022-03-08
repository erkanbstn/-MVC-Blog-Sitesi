using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EFAboutDal());
        AboutValidation av = new AboutValidation();
        public ActionResult MainAbout()
        {
            var x = am.Listele();
            return View(x);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About a)
        {
            ValidationResult vr = av.Validate(a);
            if (vr.IsValid)
            {
                am.TEkle(a);
                return RedirectToAction("MainAbout");
            }
            else
            {
                foreach (var item in vr.Errors)
                {
                    ModelState.AddModelError(item.ErrorMessage, item.PropertyName);
                }
            }
            return RedirectToAction("MainAbout");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

    }
}