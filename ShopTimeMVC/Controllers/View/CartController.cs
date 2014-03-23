using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JasonSoft.ShopTimeMVC.Models;
using JasonSoft;

namespace JasonSoft.ShopTimeMVC.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /ShoppingCart/

        public ActionResult Index()
        {
            var cartVM = new CartViewModel();
            cartVM.LineItems = new List<LineItem>();

            if (Session["cart"] != null)
            {
                cartVM.LineItems = Session["cart"] as List<LineItem>;
            }


            cartVM.TotalPrice = 999;

            return View("cart", cartVM);
        }

        public ActionResult Add(int productId) 
        {
            var lineItems = new List<LineItem>();

            if (Session["cart"] != null)
            {
                lineItems = Session["cart"] as List<LineItem>;
            }

            var lineItem = new LineItem();
            lineItem.LineItemId = productId;
            lineItem.DisplayName = string.Format("BMW {0}", productId);
            lineItem.Quantity = 1;
            lineItem.TotalPrice = 45;

            lineItems.Add(lineItem);
            Session["cart"] = lineItems;

            return RedirectToAction("Index", "cart");
        }

        public ActionResult Delete(int lineItemId) 
        {



            return RedirectToAction("Index", "cart");
        }

        public ActionResult Update(int[] qty) 
        {


            return RedirectToAction("Index", "cart");
        
        }
    }
}
