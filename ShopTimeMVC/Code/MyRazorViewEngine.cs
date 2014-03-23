using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTimeMVC
{
    public class MyRazorViewEngine : RazorViewEngine
    {
        public MyRazorViewEngine()
            : base()
        {
            AreaViewLocationFormats = new[] {
            "~/Areas/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/{1}/{0}.vbhtml",
            "~/Areas/{2}/Views/Shared/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{0}.vbhtml"
        };

            AreaMasterLocationFormats = new[] {
            "~/Areas/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/{1}/{0}.vbhtml",
            "~/Areas/{2}/Views/Shared/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{0}.vbhtml"
        };

            AreaPartialViewLocationFormats = new[] {
            "~/Areas/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/{1}/{0}.vbhtml",
            "~/Areas/{2}/Views/Shared/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{0}.vbhtml"
        };

            ViewLocationFormats = new[] {
            "~/Storage/%1/Templates/{0}.cshtml",
            "~/Storage/%1/Shared/{0}.cshtml",

        };

            MasterLocationFormats = new[] {
            "~/Storage/%1/Templates/{0}.cshtml",
            "~/Storage/%1/Shared/{0}.cshtml",

        };

            PartialViewLocationFormats = new[] {
            "~/Storage/%1/Templates/{0}.cshtml",
            "~/Storage/%1/Shared/{0}.cshtml",

        };
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            var myControllerContext = controllerContext;

            while (myControllerContext.ParentActionViewContext != null)
            {
                myControllerContext = myControllerContext.ParentActionViewContext;
            }

            var yourStore = HttpContext.Current.Items["store"] as Store;

            string viewPath = partialPath.Replace("%1", yourStore.StoreName + "/Themes/" + myControllerContext.HttpContext.Session["Theme"].ToString());
            

            return base.CreatePartialView(controllerContext, viewPath);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var myControllerContext = controllerContext;

            while (myControllerContext.ParentActionViewContext != null)
            {
                myControllerContext = myControllerContext.ParentActionViewContext;
            }




            var yourStore = HttpContext.Current.Items["store"] as Store;
            var pathValue = viewPath.Replace("%1", yourStore.StoreName + "/Themes/" + myControllerContext.HttpContext.Session["Theme"].ToString());
            var masterPathValue = masterPath.Replace("%1", yourStore.StoreName + "/Themes/" + myControllerContext.HttpContext.Session["Theme"].ToString());

            return base.CreateView(controllerContext, pathValue, masterPathValue);
        }

        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            var myControllerContext = controllerContext;



            while (myControllerContext.ParentActionViewContext != null)
            {
                myControllerContext = myControllerContext.ParentActionViewContext;
            }



            var yourStore = HttpContext.Current.Items["store"] as Store;

            string pathValue = virtualPath.Replace("%1", yourStore.StoreName + "/Themes/" + myControllerContext.HttpContext.Session["Theme"].ToString());

            var result = base.FileExists(controllerContext, pathValue);

            return result;
        }


    }
}