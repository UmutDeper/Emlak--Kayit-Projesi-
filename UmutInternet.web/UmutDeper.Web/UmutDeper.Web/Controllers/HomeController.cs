using EmlakAppDataAcessLayer;
using EmlakAppDataAcessLayer.AppDBcontext;
using EmlakAppDataAcessLayer.ConcreteRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace UmutDeper.Web.Controllers
{

    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            UnitOfWork uof = new UnitOfWork();
                var data =uof.ArsaRepo.ToListFULL();
            return View();
        }

        public ActionResult Daire()
        {
            UnitOfWork uof = new UnitOfWork();
            var data = uof.DaireRepo.ToListFULL();
            return RedirectToAction("Listele", "Daire", new { area = "Yonetim" });

        }

        public ActionResult Dukkan()
        {
            UnitOfWork uof = new UnitOfWork();
            var data = uof.DukkanRepo.ToListFULL();
            return RedirectToAction("Listele", "Dukkan", new { area = "Yonetim" });

        }

       
        public ActionResult Arsa()
        {
            UnitOfWork uof = new UnitOfWork();
            var data = uof.ArsaRepo.ToListFULL();
            return RedirectToAction("Listele", "Arsa", new { area = "Yonetim" });
        
        }

        [Authorize]
        public ActionResult Hakkinda()
        {
            return View();
        }
    }
}