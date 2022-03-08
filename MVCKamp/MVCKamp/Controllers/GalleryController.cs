using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKamp.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult MainGallery()
        {
            return View();
        }
    }
}