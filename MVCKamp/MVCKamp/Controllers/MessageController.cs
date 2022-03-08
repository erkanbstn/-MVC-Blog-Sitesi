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
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidation mv = new MessageValidation();
        public ActionResult Inbox()
        {
            string mail = (string)Session["UserName"];

            ViewBag.d = mail;
            var x = mm.GetInBox(mail);
            return View(x);
        }
        public ActionResult SendBox()
        {
            string mail = (string)Session["UserName"];
            var x = mm.GetSendBox(mail);
            return View(x);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message m)
        {
            string mail = (string)Session["UserName"];
            ValidationResult vr = mv.Validate(m);
            if (vr.IsValid)
            {
                m.SenderMail = mail;
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
        public ActionResult MessageInBoxDetail(int id)
        {
            var x = mm.IDGetir(id);
            return View(x);
        }
        public ActionResult MessageSendBoxDetail(int id)
        {
            var x = mm.IDGetir(id);
            return View(x);
        }
    }
}