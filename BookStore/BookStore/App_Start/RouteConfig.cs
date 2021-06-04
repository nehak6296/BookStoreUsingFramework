using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default1",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Books", action = "GetAllBooks", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Default2",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Cart", action = "GetCart", id = UrlParameter.Optional }
           );
        }
    }
}
