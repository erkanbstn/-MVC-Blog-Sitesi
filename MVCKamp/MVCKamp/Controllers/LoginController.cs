using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;
using System.Web.Security;
namespace MVCKamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();
        WriterLoginManager wm = new WriterLoginManager(new EFWriterDal());
        AdminManager am = new AdminManager(new EFAdminDal());

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin a)
        {
            var x = am.AdminBul(a.AdminUserName, a.AdminUserPassword);
            if (x != null)
            {
                FormsAuthentication.SetAuthCookie(x.AdminUserName, false);
                Session["UserName"] = x.AdminUserName;
                Session["AdminID"] = x.AdminID;
                return RedirectToAction("MainCategory", "Category");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer a)
        {
            var writer = wm.YazarGetir(a.WriterMail, a.WriterPassword);
            if (writer != null)
            {
                FormsAuthentication.SetAuthCookie(writer.WriterMail, false);
                Session["WriterMail"] = writer.WriterMail;
                Session["WriterID"] = writer.WriterID;
                return RedirectToAction("MyHeading", "WriterPanel");
            }
            else
            {
                return View();
            }
        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings","Default");
        }
    }
}