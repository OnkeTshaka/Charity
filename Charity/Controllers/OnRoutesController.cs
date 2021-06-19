using Charity.Models;
using Charity.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Charity.Controllers
{
    public class OnRoutesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OnRoutes
        public ActionResult Index()
        {
            CampaignViewModel campaign = new CampaignViewModel
            {
                OnRoutes = db.OnRoutes.Where(e => e.status == "OnRoute").ToList()
            };
            return View(campaign);
        }
        public ActionResult Delivered(int? id)
        {
            OnRoute bookingRoom = db.OnRoutes.Find(id);
            Delivered cancelled = new Delivered();
            cancelled.Address = bookingRoom.Address;
            cancelled.DeliveryID = bookingRoom.DeliveryID;
            cancelled.image = bookingRoom.image;
            cancelled.OrganisationId = bookingRoom.OrganisationId;
            cancelled.TotalQTY = bookingRoom.TotalQTY;

            cancelled.status = "OnRoute";
            db.Delivereds.Add(cancelled);
            db.OnRoutes.Remove(bookingRoom);
            db.SaveChanges();
            return RedirectToAction("index", "Delivereds");
        }

        // GET: OnRoutes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnRoute onRoute = db.OnRoutes.Find(id);
            if (onRoute == null)
            {
                return HttpNotFound();
            }
            return View(onRoute);
        }

        // GET: OnRoutes/Create
        public ActionResult Create()
        {
            ViewBag.OrganisationId = new SelectList(db.Organisations, "OrganisationId", "OrganisationName");
            return View();
        }

        // POST: OnRoutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeliveryID,OrganisationId,Address,Clothes,Food,TotalQTY,image,status")] OnRoute onRoute)
        {
            if (ModelState.IsValid)
            {
                db.OnRoutes.Add(onRoute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganisationId = new SelectList(db.Organisations, "OrganisationId", "OrganisationName", onRoute.OrganisationId);
            return View(onRoute);
        }

        // GET: OnRoutes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnRoute onRoute = db.OnRoutes.Find(id);
            if (onRoute == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganisationId = new SelectList(db.Organisations, "OrganisationId", "OrganisationName");
            return View(onRoute);
        }

        // POST: OnRoutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeliveryID,OrganisationId,Address,Type,Item_name,QTY,image,status")] OnRoute onRoute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(onRoute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganisationId = new SelectList(db.Organisations, "OrganisationId", "OrganisationName", onRoute.OrganisationId);
            return View(onRoute);
        }

        // GET: OnRoutes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnRoute onRoute = db.OnRoutes.Find(id);
            if (onRoute == null)
            {
                return HttpNotFound();
            }
            return View(onRoute);
        }

        // POST: OnRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OnRoute onRoute = db.OnRoutes.Find(id);
            db.OnRoutes.Remove(onRoute);
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
