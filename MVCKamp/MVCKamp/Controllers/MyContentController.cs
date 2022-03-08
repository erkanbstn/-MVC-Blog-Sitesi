using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKamp.Controllers
{
    public class MyContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        public ActionResult GetByHeading(int id)
        {
            var x = cm.IDListele(id);
            return View(x);
        }
        public ActionResult GetByWriterContent()
        {
            int id = Convert.ToInt32(Session["WriterID"]);
            var x = cm.WriterContent(id);
            return View(x);
        }
    }
}