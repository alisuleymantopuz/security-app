using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthorizationFramework.UI.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult GenericError(string aspxerrorpath)
        {
            //Log
            ViewBag.ErrorMessage = "Sayfayı görme yetkiniz yoktur.";
            ViewBag.StackTrace = aspxerrorpath + " yetki problemi.";
            ViewBag.ErrorDate = DateTime.Now;
            return View();
        }

        public ActionResult SystemError(string aspxerrorpath)
        {
            //Log
            ViewBag.ErrorMessage = "Sistemde bir hata oluştu.";
            ViewBag.StackTrace = aspxerrorpath;
            ViewBag.ErrorDate = DateTime.Now;
            ViewBag.Profile = "Profil";
            ViewBag.Settings = "Ayarlar";
            ViewBag.Logout = "Çıkış";
            return View();
        }
    }
}