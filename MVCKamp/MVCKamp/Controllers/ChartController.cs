using EntityLayer.Concrete;
using MVCKamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKamp.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult AnaChart()
        {
            return View();
        }

        public ActionResult CateChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryChart> BlogList()
        {
            List<CategoryChart> cc = new List<CategoryChart>();
            cc.Add(new CategoryChart()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            cc.Add(new CategoryChart()
            {
                CategoryName = "Bilişim",
                CategoryCount = 15
            });
            cc.Add(new CategoryChart()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 19
            });
            cc.Add(new CategoryChart()
            {
                CategoryName = "Gezi",
                CategoryCount = 7
            });
            return cc;
        }
    }
}