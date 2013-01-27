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
using Todo.Site.Models;

namespace Todo.Site.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Message = "Application ASP.NET MVC 4 couplé au framework CSS MetroUI";

            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Votre page de description d’application.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Ceci est une page de contact.";

            return View();
        }
    }
}
