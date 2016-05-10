using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectClothers
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "AddCart",
                url: "addcart-{id}",
                defaults: new { controller = "Cart", action = "AddCart", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Cart",
                url: "cart",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Detail",
                url: "detail-{id}-{name}",
                defaults: new { controller = "Men", action = "Detail", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Product",
                url: "men-{id}-{name}",
                defaults: new { controller = "Men", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}