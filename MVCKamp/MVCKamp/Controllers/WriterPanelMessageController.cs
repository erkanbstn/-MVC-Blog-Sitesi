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
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());
        DraftManager dm = new DraftManager(new EFDraftDal());
        MessageValidation mv = new MessageValidation();
        public ActionResult Inbox()
        {
            string mail = Session["WriterMail"].ToString();
            var x = mm.GetInBox(mail);
            return View(x);
        }
        public ActionResult SendBox()
        {
            string mail = Session["WriterMail"].ToString();
            var x = mm.GetSendBox(mail);
            return View(x);
        }
        public PartialViewResult MessageSideBar()
        {
            return PartialView();
        }
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message m)
        {
            ValidationResult vr = mv.Validate(m);
            if (vr.IsValid)
            {
                m.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.TEkle(m);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var i in vr.Errors)
                {
                    ModelState.AddModelError(i.PropertyName, i.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult Draft()
        {
            string mail = Session["WriterMail"].ToString();
            var x = dm.DraftList(mail);
            return View(x);
        }
    }
}