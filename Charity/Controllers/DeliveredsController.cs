using Charity.Models;
using Charity.ViewModels;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Charity.Controllers
{
    public class DeliveredsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Delivereds
        public ActionResult Index()
        {
            CampaignViewModel campaign = new CampaignViewModel
            {
               Delivereds = db.Delivereds.Where(e => e.status == "OnRoute").ToList()
            };
            return View(campaign);
        }

        // GET: Delivereds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivered delivered = db.Delivereds.Find(id);
            if (delivered == null)
            {
                return HttpNotFound();
            }
            return View(delivered);
        }

        // GET: Delivereds/Create
        public ActionResult Create()
        {
            ViewBag.OrganisationId = new SelectList(db.Organisations, "OrganisationId", "OrganisationName");
            return View();
        }

        // POST: Delivereds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeliveryID,OrganisationId,Address,Clothes,Food,TotalQTY,image,status")] Delivered delivered)
        {
            if (ModelState.IsValid)
            {
                db.Delivereds.Add(delivered);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganisationId = new SelectList(db.Organisations, "OrganisationId", "OrganisationName", delivered.OrganisationId);
            return View(delivered);
        }

        // GET: Delivereds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivered delivered = db.Delivereds.Find(id);
            if (delivered == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganisationId = new SelectList(db.Organisations, "OrganisationId", "OrganisationName");
            return View(delivered);
        }

        // POST: Delivereds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeliveryID,OrganisationId,Address,Clothes,Food,TotalQTY,image,status")] Delivered delivered)
        {
            if (ModelState.IsValid)
            {
                db.Entry(delivered).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganisationId = new SelectList(db.Organisations, "OrganisationId", "OrganisationName", delivered.OrganisationId);
            return View(delivered);
        }

        // GET: Delivereds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivered delivered = db.Delivereds.Find(id);
            if (delivered == null)
            {
                return HttpNotFound();
            }
            return View(delivered);
        }

        // POST: Delivereds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Delivered delivered = db.Delivereds.Find(id);
            db.Delivereds.Remove(delivered);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
