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
using PagedList;
using PagedList.Mvc;
using FluentValidation;
namespace MVCKamp.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        HeadingValidation hv = new HeadingValidation();
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        ContentManager ccm = new ContentManager(new EFContentDal());
        WriterValidation wv = new WriterValidation();

        Context c = new Context();
        [HttpGet]
        public ActionResult WriterProfile()
        {
            int id = Convert.ToInt32(Session["WriterID"]);
            var x = wm.IDGetir(id);
            return View(x);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer w)
        {
            ValidationResult vr = wv.Validate(w);
            if (vr.IsValid)
            {
                wm.TGuncelle(w);
                return View();
            }
            else
            {
                foreach (var i in vr.Errors)
                {
                    ModelState.AddModelError(i.PropertyName, i.ErrorMessage);
                }
                return View();
            }
        }
        public ActionResult MyHeading()
        {
            string mail = (string)Session["WriterMail"];
            int wid = wm.MailBul(mail);
            var x = hm.GetWriterHeading(wid);
            return View(x);
        }
        public ActionResult AllHeadings(int sayfa = 1)
        {
            var x = hm.Listele().ToPagedList(sayfa, 6);
            return View(x);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> deger = (from x in hm.Listele()
                                          select new SelectListItem
                                          {
                                              Text = x.HeadingName,
                                              Value = x.HeadingID.ToString()
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
            int p = Convert.ToInt32(Session["WriterID"]);
            ValidationResult vr = hv.Validate(h);
            if (vr.IsValid)
            {
                h.WriterID = p;
                h.HeadingStatus = true;
                h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                hm.TEkle(h);
                return RedirectToAction("MyHeading");
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
            List<SelectListItem> deger = (from x in hm.Listele()
                                          select new SelectListItem
                                          {
                                              Text = x.HeadingName,
                                              Value = x.HeadingID.ToString()
                                          }).ToList();
            List<SelectListItem> deger2 = (from x in cm.Listele()
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
                h.HeadingStatus = true;
                int id = Convert.ToInt32(Session["WriterID"]);
                h.WriterID = id;
                h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                hm.TGuncelle(h);
                return RedirectToAction("MyHeading");
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
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            List<SelectListItem> deger = (from x in hm.Listele()
                                          select new SelectListItem
                                          {
                                              Text = x.HeadingName,
                                              Value = x.HeadingID.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content d)
        {
            int id = Convert.ToInt32(Session["WriterID"]);
            d.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            d.WriterID = id;
            d.ContentStatus = true;
            ccm.TEkle(d);
            return RedirectToAction("MyHeading");
        }
    }


}