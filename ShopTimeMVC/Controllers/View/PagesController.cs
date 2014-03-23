using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JasonSoft.ShopTimeMVC.Controllers
{
    public class PagesController : Controller
    {

        public ActionResult DisplayPage(string pageName)
        {
            
            ViewEngineResult viewResult = ViewEngines.Engines.FindView(ControllerContext, pageName, null);

            if (viewResult.View == null)
            {
                return HttpNotFound();
            }


            return View(pageName);
        }

        public ActionResult DisplayThankYouPage() 
        {
            return View("ThankYou");
        }

    }
}
