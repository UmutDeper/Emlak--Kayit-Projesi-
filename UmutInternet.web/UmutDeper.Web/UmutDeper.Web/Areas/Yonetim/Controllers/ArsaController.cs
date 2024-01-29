using EmlakAppDataAcessLayer;
using EmlakAppEntityLayer;
using System.Web.Mvc;

namespace UmutDeper.Web.Areas.Yonetim.Controllers
{
    public class ArsaController : Controller
    {

        public ActionResult Index()
        {
            
            return RedirectToAction("Index", "Home", new { area = "Views" });

        }
        // GET: Yonetim/Arsa
        public ActionResult Listele()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return View(uow.ArsaRepo.ToListFULL());
            }
        }
        [Authorize]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]

        public ActionResult Ekle(Arsa arsa)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.ArsaRepo.Add(arsa);
                    uow.Save();
                    return RedirectToAction("Listele ");
                }
            }
            ModelState.AddModelError("", "Ekleme Başarısız");

            return View(arsa);
        }

        public ActionResult Düzenle(int? Id)
        {
            if (Id != null)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Arsa arsa = uow.ArsaRepo.GetItem(Id);
                    if (arsa != null)
                        return View(arsa);
                    else
                        return HttpNotFound();
                }
            }
            return RedirectToAction("Listele");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Düzenle(int? Id, Arsa arsa)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.ArsaRepo.Update(arsa);
                    uow.Save();
                    return RedirectToAction("Listele");
                }
            }
            ModelState.AddModelError("", "Düzenleme yapılamadı");
            return View(arsa);
        }

        [Authorize]
        public ActionResult Sil(int? Id)
        {
            if (Id != null)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Arsa arsa = uow.ArsaRepo.GetItem(Id);
                    if (arsa != null)
                        return View(arsa);
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
                    Arsa arsa = uow.ArsaRepo.GetItem(Id);
                    if (arsa != null)
                    {
                        uow.ArsaRepo.Remove(arsa  );
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