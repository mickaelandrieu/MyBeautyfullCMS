using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyBeautyfullCMS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "posts",
                url: "posts/{action}/{id}",
                defaults: new { controller = "Article", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "pages",
                url: "pages/{action}/{id}",
                defaults: new { controller = "StaticPage", action = "List", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "tags",
                url: "tags/{action}/{id}",
                defaults: new { controller = "Tag", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "users",
                url: "users/{action}/{id}",
                defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Article", action = "List", id = UrlParameter.Optional }
            );
           
        }
    }
}