using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Site.Models;
using Todo.Site.Mailers;


namespace Todo.Site.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous, HttpPost]
        public ActionResult Contact(ContactForm ContactForm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Alert = "Problème dans votre formulaire";
                return View("Index");
            }

            UserMailer mailer = new UserMailer();

            
            mailer.ContactForm(ContactForm).Send();
            ViewBag.Success = "Merci, nous vous recontacterons au plus tôt !";
            this.ModelState.Clear();
            return View("Index");
        }
 

    }
}
