using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UmutDeper.Web.Models;

namespace UmutDeper.Web.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            if (Request.QueryString["ReturnUrl"] != null)
            {
                TempData.Add("ReturnUrl", Request.QueryString["ReturnUrl"]);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(Kullanıcı model)
        {
            if (model.Eposta == "umutdeper@gmail.com" && model.parola == "1234")
            {
                FormsAuthentication.SetAuthCookie(model.Eposta, false);

                if (TempData["ReturnUrl"] != null)
                {
                    var url = TempData["ReturnUrl"].ToString();
                    TempData.Clear();
                    return Redirect(url);
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Logout()
        {

            var cookie = FormsAuthentication.GetAuthCookie("deneme@gmail.com", false);

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}