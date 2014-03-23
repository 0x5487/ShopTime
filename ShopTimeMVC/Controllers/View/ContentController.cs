using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JasonSoft.IO;
using System.IO;

namespace JasonSoft.ShopTimeMVC.Controllers
{
    public class ContentController : Controller
    {
        //
        // GET: /Content/

        public ActionResult Index()
        {
            return View();
        }

        public FileResult GetFile(string filePath) 
        {
            string urlPath = string.Format("~/Storage/{2}/Themes/{1}/Contents/{0}", filePath, HttpContext.Session["theme"].ToString(), "jason");
            string filelocation = Server.MapPath(Url.Content(urlPath));

            FileInfo file = new FileInfo(filelocation);

            string contentType = "application/octet-stream";

            switch (file.Extension.ToLower()) 
            {
                case ".js":
                    contentType = "text/javascript";
                    break;
                case ".css":
                    contentType = "text/css";
                    break;
                case ".jpg":
                    contentType = "image/jpeg";
                    break;
            }


            return File(filelocation, contentType);
        }

    }
}
