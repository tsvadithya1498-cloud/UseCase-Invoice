using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;                  
using System.Web.Routing;

namespace InvoiceAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Company",
                url: "{controller}/{action}",
                defaults: new { controller = "Company", action = "Index"}
                );

            routes.MapRoute(
                name: "Invoice",
                url: "{controller}/{action}",
                defaults: new { controller = "Invoice", action = "Index"}
                );
        }
    }
}
