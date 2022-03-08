using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKamp.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetByHeading(int id)
        {
            var x = cm.IDListele(id);
            return View(x);
        }
        Context c = new Context();
        public ActionResult AllContent(string hece)
        {
            if (!string.IsNullOrEmpty(hece))
            {
                var v = cm.ContentBul(hece);
                return View(v);
            }
            else
            {
                var v = cm.Listele();
                return View(v);
            }
        }
    }
}