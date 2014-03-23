using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JasonSoft.ShopTimeMVC.Models;

namespace JasonSoft.ShopTimeMVC.Controllers
{
    public class CheckoutController : ShopTimeController
    {


        public ActionResult Index()
        {
            ModelState.Clear();

            var resultModel = GetCheckoutModel();

            if (Session["login"] != null) 
            {                
                resultModel.BillingFirstName = "Jason";
                resultModel.BillingLastName = "Lee";
                resultModel.BillingAddress1 = "tt";
                resultModel.BillingAddress2 = "bb";
                resultModel.ShippingFirstName = "Angela";
                resultModel.ShippingLastName = "Wang";
                resultModel.ShippingAddress1 = "aab";
                resultModel.ShippingAddress2 = "abc";
            }          


            return View("OnePageCheckout", "DefaultLayout", resultModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel) 
        {
            if (ModelState.IsValid)
            {
                if (loginViewModel.UserName == "jason" && loginViewModel.Password == "123123")
                {
                    Session["login"] = "true";
                    return RedirectToAction("Index");
                }
                else 
                {
                    ModelState.AddModelError("UserName", "username or password is wrong.");
                }
            }

            var resultModel = GetCheckoutModel();
            return View("OnePageCheckout", "DefaultLayout", resultModel);

            //return RedirectToAction("Index");
                       
        }


        [HttpPost]
        public ActionResult Index(OnePageCheckoutViewModel onePageCheckoutViewModel) 
        {
            onePageCheckoutViewModel.PaymentMethods.Add(new CreditCardPaymentMethod());
            onePageCheckoutViewModel.PaymentMethods.Add(new PaymentMethod() { Name = "PayPal" });

            if (ModelState.IsValid)
            {
                if (onePageCheckoutViewModel.Action == "login")
                {
                    if (onePageCheckoutViewModel.UserName == "jason" && onePageCheckoutViewModel.Password == "123123")
                    {
                        Session["login"] = "true";
                        return RedirectToAction("Index");
                    }
                }
                else if (onePageCheckoutViewModel.Action == "continue")
                {
                    return RedirectToAction("confirmorder");
                }
            }
            
            return View("OnePageCheckout", "DefaultLayout", onePageCheckoutViewModel);
        }



        public ActionResult ConfirmOrder() 
        {            

            var confirmOrderModel = new ConfirmOrderViewModel();
            confirmOrderModel.IsShippingRequired = true;
            confirmOrderModel.SelectedShippingOptionId = 0;
            confirmOrderModel.ShippingOptions.Add(new ShippingOption() { ShippingOptionId = 0, DisplayName = "Please select" });
            confirmOrderModel.ShippingOptions.Add(new ShippingOption() { ShippingOptionId = 1, DisplayName = "Ground - $10" });
            confirmOrderModel.ShippingOptions.Add(new ShippingOption() { ShippingOptionId = 2, DisplayName = "Express - $20" });
            confirmOrderModel.LineItems.Add(new LineItem() { DisplayName = "Lenovo", Quantity = 3, TotalPrice = 1299 });
            confirmOrderModel.LineItems.Add(new LineItem() { DisplayName = "HTC", Quantity = 1, TotalPrice = 599 });


            return View("confirmorder", "defaultlayout", confirmOrderModel);
        }

        public ActionResult PlaceOrder(PlaceOrderModel placeOrderModel) 
        {
            if (placeOrderModel.SelectedShippingOptionId == 0) 
            {
                ModelState.AddModelError("SelectedShippingOptionId", "please select one !!!.");

            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("DisplayThankYouPage");
            }
            else 
            {
                var confirmOrderModel = GetOrder();
                return View("confirmorder", "defaultlayout", confirmOrderModel);
            }
         
        }

        public ActionResult DisplayThankYouPage() 
        {
            ThankYouModel thankyouModel = new ThankYouModel();

            return View("ThankYou", thankyouModel);
        }

        public ActionResult ChangeShippingOption() 
        {
            return RedirectToAction("confirmorder");
        }


        private ConfirmOrderViewModel GetOrder() 
        {
            var confirmOrderModel = new ConfirmOrderViewModel();
            confirmOrderModel.IsShippingRequired = true;
            confirmOrderModel.SelectedShippingOptionId = 0;
            confirmOrderModel.ShippingOptions.Add(new ShippingOption() { ShippingOptionId = 0, DisplayName = "Please select" });
            confirmOrderModel.ShippingOptions.Add(new ShippingOption() { ShippingOptionId = 1, DisplayName = "Ground - $10" });
            confirmOrderModel.ShippingOptions.Add(new ShippingOption() { ShippingOptionId = 2, DisplayName = "Express - $20" });
            confirmOrderModel.LineItems.Add(new LineItem() { DisplayName = "Lenovo", Quantity = 3, TotalPrice = 1299 });
            confirmOrderModel.LineItems.Add(new LineItem() { DisplayName = "HTC", Quantity = 1, TotalPrice = 599 });

            return confirmOrderModel;
        }

        private OnePageCheckoutViewModel GetCheckoutModel() 
        {
            var resultModel = new OnePageCheckoutViewModel();

            resultModel.PaymentMethods.Add(new CreditCardPaymentMethod());
            resultModel.PaymentMethods.Add(new PaymentMethod() { Name = "PayPal" });

            return resultModel;
        }
    }
}
