using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Charity.Models;
using Charity.ViewModels;

namespace Project.Controllers.ManageStaff
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CommentsRatings
        public ActionResult Index()
        {
            CampaignViewModel campaign = new CampaignViewModel
            {
                Comments = db.Comments.ToList()
            };
            return View(campaign);
        }

        // GET: CommentsRatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment commentsRating = db.Comments.Find(id);
            if (commentsRating == null)
            {
                return HttpNotFound();
            }
            return View(commentsRating);
        }

        // GET: CommentsRatings/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(FormCollection form)
        {
            var comment = form["Comment"].ToString();
            var articleId = int.Parse(form["ArticleId"]);
            var rating = int.Parse(form["Rating"]);
            string CurrentUserName = User.Identity.GetUserName();
            Comment commentsRating = new Comment()
            {
                ArticleId = articleId,
                Comments = comment,
                Rating = rating,
                ThisDateTime = DateTime.Now,


            };
            ApplicationUser member = db.Users.Where(s => s.UserName == CurrentUserName).FirstOrDefault();
            commentsRating.Id = member.Id;
            commentsRating.User = member;

            db.Comments.Add(commentsRating);
            db.SaveChanges();

            return RedirectToAction("Details", "Blogs", new { id = articleId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,Comments,ThisDateTime,ArticleId,Rating")] Comment commentsRating)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(commentsRating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(commentsRating);
        }

        // GET: CommentsRatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment commentsRating = db.Comments.Find(id);
            if (commentsRating == null)
            {
                return HttpNotFound();
            }
            return View(commentsRating);
        }

        // POST: CommentsRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,Comments,ThisDateTime,ArticleId,Rating")] Comment commentsRating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentsRating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commentsRating);
        }

        // GET: CommentsRatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment commentsRating = db.Comments.Find(id);
            if (commentsRating == null)
            {
                return HttpNotFound();
            }
            return View(commentsRating);
        }

        // POST: CommentsRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment commentsRating = db.Comments.Find(id);
            db.Comments.Remove(commentsRating);
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
