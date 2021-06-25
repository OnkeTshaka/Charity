using Charity.Models;
using Charity.Repository;
using Charity.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Charity.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        IRepositoryBase<Blog> Dune;
        public HomeController()
        {
            //Create Repositories for DataAccess
            Dune = new BlogRepository(db);
        }
        public ActionResult Index(string searching, int? page)
        {
            var blogs = Dune.GetAll().OrderByDescending(x => x.BlogId).Where(m => m.Title.Contains(searching) || m.Category.Name.Contains(searching) || searching == null).ToList().ToPagedList(page ?? 1, 4);
            CampaignViewModel campaign = new CampaignViewModel
            {
                Blog = (PagedList<Blog>)blogs,
                Trainers = db.Organisations.Count(),
                Donors = db.Payments.Count()
            };
            return View(campaign);
        }
        public PartialViewResult List()
        {

            return PartialView(Dune.GetAll().OrderByDescending(x => x.BlogId).ToList());
        }
        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = Dune.GetByID(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleId = id.Value;
            var comments = db.Comments.Where(d => d.ArticleId.Equals(id.Value)).ToList();
            ViewBag.Comments = comments;
            var comm = db.Comments.Count();
            ViewBag.CommentCount = comm;
            var ratings = db.Comments.Where(d => d.ArticleId.Equals(id.Value)).ToList();
            if (ratings.Count() > 0)
            {
                var ratingSum = ratings.Sum(d => d.Rating.Value);
                ViewBag.RatingSum = ratingSum;
                var ratingCount = ratings.Count();
                ViewBag.RatingCount = ratingCount;
            }
            else
            {
                ViewBag.RatingSum = 0;
                ViewBag.RatingCount = 0;
            }
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost/*,ValidateInput(false)*/]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogId,Title,Intro,Body,Picture,AllowComments,OnCreated,CategoryId")] Blog blog, HttpPostedFileBase image)
        {
            if (image != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), (image.FileName));
                image.SaveAs(path);
                blog.Picture = (image.FileName);
            }
            if (ModelState.IsValid)
            {
                blog.OnCreated = DateTime.Now.ToLongDateString();
                //db.Blogs.Add(blog);
                //db.SaveChanges();
                //Now Add this ad object in our Ads Repository
                Dune.Insert(blog);
                Dune.Commit();
                return RedirectToAction("Index","Home");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", blog.CategoryId);
            return View(blog);
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = Dune.GetByID(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Blog blog, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {

                if (blog.BlogId != 0)
                {
                    Blog tripInDB = Dune.GetAll().Single(c => c.BlogId == blog.BlogId);
                    if (image != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Images"), (image.FileName));
                        image.SaveAs(path);
                        blog.Picture = (image.FileName);
                        tripInDB.Picture = blog.Picture;
                    }

                    tripInDB.Title = blog.Title;
                    tripInDB.Intro = blog.Intro;
                    tripInDB.Body = blog.Body;
                    tripInDB.AllowComments = blog.AllowComments;
                    tripInDB.OnCreated = blog.OnCreated;
                    tripInDB.CategoryId = blog.CategoryId;

                    //db.SaveChanges();
                    //Now Add this ad object in our Ads Repository
                    Dune.Commit();
                    return RedirectToAction("Index");

                }
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", blog.CategoryId);
            return View(blog);
        }
        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = Dune.GetByID(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = Dune.GetByID(id);
            //db.Blogs.Remove(blog);
            //db.SaveChanges();
            Dune.Delete(blog);
            Dune.Commit();
            return RedirectToAction("Index");
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,Name,EmailAddress,PhoneNumber,Message,TimeStamp,IsReaded")] ContactUs contactUs)
        {
            db.ContactUs.Add(contactUs);
            db.SaveChanges();
            TempData["message"] = "Message sent";
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
