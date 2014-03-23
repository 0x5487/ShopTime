using System;
using System.Web;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using ShopTimeMVC.Models;
using System.Linq;
using System.Net.Http;
using System.Web.Routing;
using System.Globalization;
using System.Threading;
using JasonSoft.ShopTimeMVC;
using JasonSoft;
using JasonSoft.ShopTime.Domain;
using JasonSoft.ShopTimeMVC.Controllers;

namespace JasonSoft.ShopTimeMVC.Filters
{
    public class DesignModeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {          

            Dictionary<string, string> routeTable = new Dictionary<string, string>();
            routeTable.Add("www.myshop.com", "jason");
            routeTable.Add("www.mystore.com", "www");
            routeTable.Add("jason.mystore.com", "jason");
            routeTable.Add("apple.mystore.com", "apple");

            string clientName;

            if (routeTable.TryGetValue(filterContext.HttpContext.Request.Headers["host"].ToString(), out clientName))
            {
                filterContext.RouteData.Values["subdomain"] = clientName;             

                Store yourStore = new Store();
                yourStore.StoreName = "jason";
                yourStore.Theme = "simple";

                HttpContext.Current.Items.Add("store", yourStore);

                string lang = "en-US";

                if (filterContext.RouteData.Values["culture"] != null)
                {
                    lang = filterContext.RouteData.Values["culture"].ToString();
                }

                CultureInfo culture = CultureInfo.GetCultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = culture;
                Thread.CurrentThread.CurrentCulture = culture;



                if (filterContext.HttpContext.Session["theme"] == null) 
                {
                    filterContext.HttpContext.Session["theme"] = yourStore.Theme;
                }



                if (filterContext.HttpContext.Request.QueryString["theme"] != null)
                {
                    filterContext.HttpContext.Session["theme"] = filterContext.HttpContext.Request.QueryString["theme"];
                }


            }
            else 
            {
                filterContext.Result = new HttpStatusCodeResult(404);   
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            //filterContext.Result = new HttpStatusCodeResult(404);
        }
    }
}