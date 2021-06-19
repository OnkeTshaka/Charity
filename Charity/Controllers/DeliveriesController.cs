using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Charity.Models;
using Microsoft.AspNet.Identity;
using Charity.ViewModels;

namespace Charity.Controllers
{
    public class DeliveriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Deliveries
        public ActionResult Index()
        {
            CampaignViewModel campaign = new CampaignViewModel
            {
                Deliveries = db.Deliveries.ToList()
            };
            return View(campaign);
        }
        public ActionResult StatusChange()
        {
            CampaignViewModel campaign = new CampaignViewModel
            {
                Deliveries = db.Deliveries.ToList()
            };
            return View(campaign);
        }
        
      
        public ActionResult OnRoute(int? id)
        {
            Delivery bookingRoom = db.Deliveries.Find(id);
            OnRoute cancelled = new OnRoute();
            cancelled.Address = bookingRoom.Address;
            cancelled.DeliveryID = bookingRoom.DeliveryID;
            cancelled.image = bookingRoom.image;
            cancelled.OrganisationId = bookingRoom.OrganisationId;
            cancelled.TotalQTY = bookingRoom.TotalQTY;
           
            cancelled.status = "OnRoute";
            db.OnRoutes.Add(cancelled);
            db.Deliveries.Remove(bookingRoom);
            db.SaveChanges();
            return RedirectToAction("Index", "OnRoutes");
        }
        public ActionResult PickedUp(int? id)
        {
            Delivery deliveries = db.Deliveries.Find(id);
           
            
            if (id != null)
            {
                deliveries.status = "PICKEDUP";
                db.Entry(deliveries).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = " The Package has been picked up";
                return RedirectToAction("StatusChange");
            }
            return View();
        }


        // GET: Deliveries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.Deliveries.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // GET: Deliveries/Create
        public ActionResult Create()
        {
            ViewBag.OrganisationId = new SelectList(db.Organisations, "OrganisationId", "OrganisationName");
            return View();
        }

        // POST: Deliveries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeliveryID,Address,Clothes,Food,TotalQTY,image,status,ImageType,OrganisationId")] Delivery delivery, HttpPostedFileBase img_upload)
        {
            if (img_upload != null)
            {
                delivery.image = new byte[img_upload.ContentLength];
                img_upload.InputStream.Read(delivery.image, 0, img_upload.ContentLength);
            }
            if (ModelState.IsValid)
            {
                delivery.status = "Awaiting Pickup";
                db.Deliveries.Add(delivery);
                db.SaveChanges();
                return RedirectToAction("StatusChange");
            }
            ViewBag.OrganisationId = new SelectList(db.Organisations, "OrganisationId", "OrganisationName", delivery.OrganisationId);
            return View(delivery);
        }

        // GET: Deliveries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.Deliveries.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganisationId = new SelectList(db.Organisations, "OrganisationId", "OrganisationName");
            return View(delivery);
        }

        // POST: Deliveries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeliveryID,Address,Clothes,Food,TotalQTY,image,status,OrganisationId")] Delivery delivery, HttpPostedFileBase img_upload)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(delivery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganisationId = new SelectList(db.Organisations, "OrganisationId", "OrganisationName", delivery.OrganisationId);
            return View(delivery);
        }

        // GET: Deliveries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.Deliveries.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // POST: Deliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Delivery delivery = db.Deliveries.Find(id);
            db.Deliveries.Remove(delivery);
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
        //Image
        // Convert file to binary
        public byte[] ConvertToBytes(HttpPostedFileBase file)
        {
            BinaryReader reader = new BinaryReader(file.InputStream);
            return reader.ReadBytes((int)file.ContentLength);
        }
        //Image
        //Display File
    }
}
