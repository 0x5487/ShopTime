using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JasonSoft.ShopTimeMVC.Models;

namespace JasonSoft.ShopTimeMVC.Controllers
{
    public class CollectionController : Controller
    {
        //
        // GET: /Collection/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayCollection(string resourceId)
        {
            CollectionViewModel viewModel = new CollectionViewModel();
            viewModel.Collection.DisplayName = resourceId;
            return View("collection", viewModel);
        }

    }
}
