using EmlakAppDataAcessLayer;
using EmlakAppEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UmutDeper.Web.Areas.Yonetim.Controllers
{
    public class DukkanController : Controller
    {

        public ActionResult Index()
        {

            return RedirectToAction("Index", "Home", new { area = "Views" });

        }

        // GET: Yonetim/Dukkan
        public ActionResult Listele()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return View(uow.DukkanRepo.ToListFULL());
            }
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]

        public ActionResult Ekle(Dukkan dukkan)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.DukkanRepo.Add(dukkan);
                    uow.Save();
                    return RedirectToAction("Listele ");
                }
            }
            ModelState.AddModelError("", "Ekleme Başarısız");

            return View(dukkan);
        }
        public ActionResult Düzenle(int? Id)
        {
            if (Id != null)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Dukkan dukkan = uow.DukkanRepo.GetItem(Id);
                    if (dukkan != null)
                        return View();
                    else
                        return HttpNotFound();
                }
            }
            return RedirectToAction("Listele");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Düzenle(int? Id, Dukkan dukkan)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.DukkanRepo.Update(dukkan);
                    uow.Save();
                    return RedirectToAction("Listele");
                }
            }
            ModelState.AddModelError("", "Düzenleme yapılamadı");
            return View(dukkan);
        }


        public ActionResult Sil(int? Id)
        {
            if (Id != null)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Dukkan dukkan = uow.DukkanRepo.GetItem(Id);
                    if (dukkan != null)
                        return View(dukkan);
                    else
                        return HttpNotFound();
                }
            }
            return RedirectToAction("Listele");
        }
        [HttpPost, ValidateAntiForgeryToken, ActionName("Sil")]

        public ActionResult SilOnay(int? Id)
        {
            if (Id != null)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Dukkan dukkan = uow.DukkanRepo.GetItem(Id);
                    if (dukkan != null)
                    {
                        uow.DukkanRepo.Remove(dukkan);
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