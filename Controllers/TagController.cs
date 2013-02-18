using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBeautyfullCMS.Models;

namespace MyBeautyfullCMS.Controllers
{
    public class TagController : Controller
    {
        private BlogContext db = new BlogContext();

        //
        // GET: /Tag/

        public ActionResult Index()
        {
            return View(db.Tags.ToList());
        }

        //
        // GET: /Tag/Details/5

        public ActionResult Details(int id = 0)
        {
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        //
        // GET: /Tag/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tag/Create

        [HttpPost]
        public ActionResult Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Tags.Add(tag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tag);
        }

        //
        // GET: /Tag/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        //
        // POST: /Tag/Edit/5

        [HttpPost]
        public ActionResult Edit(Tag tag)
        {
            if (ModelState.IsValid && tag.title != "Non Catégorisé")
            {
                db.Entry(tag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        //
        // GET: /Tag/Delete/5

        public ActionResult Delete(int id = 0)
        {

            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();

            }
            if(tag.title == "Non Catégorisé")
            {
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        //
        // POST: /Tag/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Tag tag = db.Tags.Find(id);
            db.Tags.Remove(tag);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}