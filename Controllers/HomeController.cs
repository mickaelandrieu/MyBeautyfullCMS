using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Todo.Site.Filters;
using Todo.Site.Models;

namespace Todo.Site.Controllers
{
    public class HomeController : Controller
    {
        public static Dictionary<string, Email> Mails = new  Dictionary<string,Email>();
        
        public ActionResult Index()
        {
            ViewBag.Message = "Application ASP.NET MVC 4 couplé au framework CSS MetroUI";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Votre page de description d’application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Ceci est une page de contact.";

            return View();
        }


        public ActionResult Confirmation()
        {
            Email current = new Email();
            if (TempData.ContainsKey("confirm"))
            {
                current = (Email)TempData["confirm"];
                TempData.Remove("confirm");
            }
           
            return View();
        }


        // GET: /Clients/
        public ActionResult InsertClients()
        {
            return View();
        }

        // POST: /Clients/ 
        [HttpPost]
        public ActionResult InsertClients(Email contact)
        {
            if (ModelState.IsValid)
            {
                if (!Mails.ContainsKey(contact.Mail))
                {
                    Mails.Add(contact.Mail, contact);
                }
                return View("Confirmation", contact);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Modifiez ce modèle pour dynamiser votre applicaton";

            return View(Mails.Values);
        }

        /* implémentation d'une vue partielle */
        [ChildActionOnly]
        public ActionResult SayHello()
        {
            var items = new[] { "World", "toto", "tata" };
            return PartialView("_SayHello", items);
        }
    }
}
