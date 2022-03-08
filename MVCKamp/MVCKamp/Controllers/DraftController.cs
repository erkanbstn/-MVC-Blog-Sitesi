using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKamp.Controllers
{
    public class DraftController : Controller
    {
        DraftManager dm = new DraftManager(new EFDraftDal());
        public ActionResult MainDraft()
        {
            string mail = Session["WriterMail"].ToString();
            var x = dm.DraftList(mail);
            return View(x);
        }
        public ActionResult DraftDetail(int id)
        {
            var x = dm.IDListele(id);
            return View(x);
        }
    }
}