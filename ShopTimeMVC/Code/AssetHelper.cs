using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JasonSoft.ShopTimeMVC.Code
{
    public static class Asset
    {
        public static string GetLink(string fileName) 
        {
            string subdomain = HttpContext.Current.Request.RequestContext.RouteData.Values["subdomain"].ToString();
            string filePath = string.Format("/content/{1}/{0}", fileName, subdomain);
            return filePath;            
        }


    }
}