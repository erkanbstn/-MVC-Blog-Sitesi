using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
        ContactValidation cv = new ContactValidation();
        public ActionResult MainContact()
        {
            var c = cm.Listele();
            return View(c);
        }
        public ActionResult ContactDetail(int id)
        {
            var x = cm.IDGetir(id);
            return View(x);
        }
        public PartialViewResult MessageSideBar()
        {
            return PartialView();
        }
    }
}