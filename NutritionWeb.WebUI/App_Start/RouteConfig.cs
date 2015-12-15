using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NutritionWeb.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{file}.html");
            routes.IgnoreRoute("{file}.xml");

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Home",
                    action = "Index",
                    category = (string)null,
                    page = 1
                });

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
