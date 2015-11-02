using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Pro.Assur.Models;

namespace Pro.Assur.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<RedirectToRouteResult> Save(Devis devis)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");

            using (var db =new AssurContext())
            {
                devis.DevisGuid = Guid.NewGuid();
                devis.DateDemande = DateTime.Now;
                db.Devises.Add(devis);
                await db.SaveChangesAsync();
                await SendEmail.Report(devis);
                return RedirectToAction("ThankYou");
            }
        }

        [Authorize(Roles = "Administrator")]
        public async Task<ViewResult> DevisView()
        {
            using (var db = new AssurContext())
            {
                var model = await db.Devises.OrderByDescending(d=>d.DateDemande).ToListAsync();
                return View(model);
            }         
        }
        
        public ActionResult Delete(Guid devisGuid)
        {           
            using (var db = new AssurContext())
            {
                var devis = db.Devises.Find(devisGuid);
                db.Devises.Remove(devis);
                db.Entry(devis).State = EntityState.Deleted;
                 db.SaveChanges();
                return RedirectToAction("Demandes");
            }
        }

        public ActionResult ThankYou()
        {
            ViewBag.Message = "Demande reçu";

            return View();
        }

        [Authorize(Roles = "Administrator")]
        public async Task<ViewResult> Demandes(int? page)
        {
            using (var db = new AssurContext())
            {

                //db.Devises.AddRange(SeedData.Seed(100));
                //await db.SaveChangesAsync();

                var pageno = page == null ? 1 : int.Parse(page.ToString());
                const int pageSize = 10;
                var totalCount = await db.Devises.CountAsync();
                
                var pager = new Pager<Devis>(
                    await db.Devises
                    .OrderByDescending(d=>d.Nom)
                    .Skip((pageno - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(), pageno, pageSize, totalCount);

                return View(pager);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}