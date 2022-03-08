using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager cm = new ContentManager(new EFContentDal());
        public ActionResult Headings()
        {
            var list = hm.Listele();
            return View(list);
        }
        public PartialViewResult Content(int id = 0)
        {
            var list = cm.HeadingContent(id);
            var list2 = cm.Listele();
            if(id != 0)
            {
                return PartialView(list);
            }
            else
            {
                return PartialView(list2);
            }
        }

    }
}