using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Site.Models;
using Todo.Site.ArticlesContext__Todo.Site;

namespace Todo.Site.Controllers
{
    public class ArticleController : Controller
    {
        private Models_ db = new Models_();

        //
        // GET: /Article/
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Articles.ToList());
        }

        //
        // GET: /Article/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // GET: /Article/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Article/Create

        [HttpPost, Authorize]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        //
        // GET: /Article/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // POST: /Article/Edit/5

        [HttpPost, Authorize]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        //
        // GET: /Article/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // POST: /Article/Delete/5

        [HttpPost, ActionName("Delete"), Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [AllowAnonymous]
        public ActionResult List()
        {
            var articles = db.Articles
                             .Where(a => a.status.Equals(true))
                             .ToList()
                             .Take(10);
                            

            return View(articles);
        }

        [AllowAnonymous]
        public ActionResult ListJson()
        {
            return Json(db.Articles.ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}