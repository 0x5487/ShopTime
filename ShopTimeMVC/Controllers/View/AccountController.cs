using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using ShopTimeMVC.Filters;
using ShopTimeMVC.Models;
using JasonSoft.ShopTimeMVC.Models;
using JasonSoft;

namespace ShopTimeMVC.Controllers
{

    public class AccountController : Controller
    {
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel) 
        {
            if (ModelState.IsValid)
            {
                if (loginViewModel.UserName == "jason" && loginViewModel.Password == "123123")
                {
                    Session["login"] = "true";
                    return Redirect(loginViewModel.ReturnUrl);
                }
            }

            return RedirectToAction("Index", "OnePageCheckout");
        }

        public ActionResult Login()
        {
            LoginViewModel viewModel = new LoginViewModel();


            return View("Login", viewModel);
        }


        public ActionResult ForgotPassword()
        {
            return View("ForgotPassword");
        }



    }
}
