using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using Todo.Site.Models;
using System.Data;
using System.Data.Entity;

namespace Todo.Site.Controllers
{
    public class AdminController : Controller
    {
        private BlogContext db = new BlogContext();

        //
        // GET: /Admin/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.UserProfiles.ToList());
        }

        //
        // GET: /Admin/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            UserProfile user = db.UserProfiles.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var niveau in Roles.GetAllRoles())
            {
                var trouve = false;
                foreach (var level in Roles.GetRolesForUser(user.UserName))
                {
                    if (level == niveau)
                    {
                        trouve = true;
                    }
                }
                if(trouve) {
                    items.Add(new SelectListItem { Text = niveau, Value = niveau, Selected = true });
                } else {
                    items.Add(new SelectListItem { Text = niveau, Value = niveau });
                }
                
            }
           
            ViewBag.UserId = user.UserId;
            ViewBag.UserName = user.UserName;
            ViewBag.Level = items;

            return View();
        }

        //
        // POST: /Admin/Edit/5
        [HttpPost, Authorize]
        public ActionResult Edit(UserProfile user)
        {
            if (ModelState.IsValid)
            {
                if (user.UserLevel == "Administrator")
                {
                    if (Roles.GetUsersInRole("Administrator").Length > 1)
                    {
                        db.Entry(user).State = EntityState.Modified;
                    }
                }
                else
                {
                    db.Entry(user).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = user.UserId });
            }
            return View(user);
        }

        //
        // GET: /Admin/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            UserProfile user = db.UserProfiles.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete"), Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile user = db.UserProfiles.Find(id);
            Boolean plusieur = false;
            if (user.UserLevel == "Administrator")
            {
                if (Roles.GetUsersInRole("Administrator").Length > 1)
                {
                    plusieur = true;
                }
            }
            if (!plusieur)
            {
                foreach (var level in Roles.GetRolesForUser(user.UserName))
                {
                    Roles.RemoveUserFromRole(user.UserName, level);
                }
                db.UserProfiles.Remove(user);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
