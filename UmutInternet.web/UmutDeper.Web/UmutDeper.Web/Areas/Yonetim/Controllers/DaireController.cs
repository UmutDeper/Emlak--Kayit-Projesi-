using EmlakAppDataAcessLayer;
using EmlakAppEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UmutDeper.Web.Areas.Yonetim
{
    public class DaireController : Controller
    {
        // GET: Yonetim/Daire

        public ActionResult Index()
        {

            return RedirectToAction("Index", "Home", new { area = "Views" });

        }
        public ActionResult Listele()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return View(uow.DaireRepo.ToListFULL());
            }
        }
 
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]

        public ActionResult Ekle (Daire daire)
        {
            if (ModelState.IsValid)
            {
                using(UnitOfWork uow =new UnitOfWork())
                {
                    uow.DaireRepo.Add(daire);
                    uow.Save();
                    return RedirectToAction("Listele ");
                }
            }
            ModelState.AddModelError("", "Ekleme Başarısız");

            return View(daire);
        }

        public ActionResult Düzenle(int? Id)
        {
            if (Id != null)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Daire daire = uow.DaireRepo.GetItem(Id);
                    if (daire != null)
                        return View(daire);
                    else
                        return HttpNotFound();
                }
            }
            return RedirectToAction("Listele");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Düzenle(int? Id, Daire daire )
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.DaireRepo.Update     ( daire);
                    uow.Save();
                    return RedirectToAction("Listele");
                }
            }
            ModelState.AddModelError("", "Düzenleme yapılamadı");
            return View(daire);
        }

        [Authorize]
        public ActionResult Sil(int? Id)
        {
            if (Id != null)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Daire daire = uow.DaireRepo.GetItem(Id);
                    if (daire != null)
                        return View(daire);
                    else
                        return HttpNotFound();
                }
            }
            return RedirectToAction("Listele");
        }
        [HttpPost, ValidateAntiForgeryToken,ActionName("Sil")]

        public ActionResult SilOnay(int? Id)
        {
            if (Id   != null)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Daire daire = uow.DaireRepo.GetItem(Id);
                    if (daire != null)
                    {
                        uow.DaireRepo.Remove(daire);
                        uow.Save();
                        return RedirectToAction("Listele");
                    }
                    else
                        return HttpNotFound();
                }
            }
            return RedirectToAction("Listele");
        }
    }
}