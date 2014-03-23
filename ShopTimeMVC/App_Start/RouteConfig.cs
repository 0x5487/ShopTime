using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcDomainRouting.Code;

namespace JasonSoft.ShopTimeMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "http404",
                url: "page-not-found/{action}/{id}",
                defaults: new { controller = "Error", action = "PageNotFound", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DisplayPage",
                url: "pages/{pageName}",
                defaults: new { controller = "Pages", action = "DisplayPage" },
                namespaces: new string[] { "JasonSoft.ShopTimeMVC.Controllers" }
            );


            routes.MapRoute(
                name: "Contents",
                url: "contents/{*filePath}",
                defaults: new { controller = "Content", action = "GetFile" }
            );

            //routes.Add("Default", new DomainRoute(
            //    "{subdomain}.mystore.com",
            //    "{controller}/{action}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //));

            //routes.MapRoute(
            //    name: "SubDomain",
            //    url: "jason.localhost",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Collection",
                url: "collections/{*resourceId}",
                defaults: new { controller = "collection", action = "DisplayCollection" },
                namespaces: new string[] { "JasonSoft.ShopTimeMVC.Controllers" }
            );

            routes.MapRoute(
                name: "Product",
                url: "products/{productName}",
                defaults: new { controller = "Product", action = "DisplayProductDetail" },
                namespaces: new string[] { "JasonSoft.ShopTimeMVC.Controllers" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "JasonSoft.ShopTimeMVC.Controllers" }
            );
        }
    }
}