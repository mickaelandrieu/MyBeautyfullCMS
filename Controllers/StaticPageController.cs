using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Site.Models;

namespace Todo.Site.Controllers
{
    public class StaticPageController : Controller
    {
        private BlogContext db = new BlogContext();

        //
        // GET: /StaticPage/
        [AllowAnonymous]
        public ActionResult Index(int id = 0)
        {
            StaticPage page = db.StaticPages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        //
        // GET: /StaticPage/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id = 0)
        {
            StaticPage page = db.StaticPages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        //
        // GET: /StaticPage/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /StaticPage/Create

        [HttpPost]
        public ActionResult Create(StaticPage page)
        {
            if (ModelState.IsValid)
            {
                db.StaticPages.Add(page);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(page);
        }

        //
        // GET: /StaticPage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StaticPage page = db.StaticPages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        //
        // POST: /Page/Edit/5

        [HttpPost]
        public ActionResult Edit(StaticPage page)
        {
            if (ModelState.IsValid)
            {
                db.Entry(page).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(page);
        }

        //
        // GET: /StaticPage/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StaticPage page = db.StaticPages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        //
        // POST: /StaticPage/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StaticPage page = db.StaticPages.Find(id);
            db.StaticPages.Remove(page);
            db.SaveChanges();
            return RedirectToAction("List","Article");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        /**
         *  Affichage d'une liste de liens avec le titre des pages
         **/
        [AllowAnonymous]
        public ActionResult DisplayHeaderMenu()
        {
            return PartialView(db.StaticPages.ToList());
        }

        public ActionResult List()
        {
            return View(db.StaticPages.ToList());
        }
    }
}
