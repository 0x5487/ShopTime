using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JasonSoft;
using JasonSoft.ShopTimeMVC.Models;
using JasonSoft.ShopTime.Domain;
using JasonSoft.ShopTime.Service;

namespace JasonSoft.ShopTimeMVC.Controllers
{
    public class HomeController : ShopTimeController
    {
        //IProductService _productService;

        //public HomeController(IProductService productService) 
        //{
        //    this._productService = productService;
        //}


        public ActionResult Index()
        {
            var resultModel = new HomeViewModel();


            //for (Int32 i = 1; i < 11; i++)
            //{
            //    var car = new IndividualProduct();
            //    car.DisplayName = "BMW" + i.ToString();
            //    car.Description = "BMW 335i";
            //    car.Price = 100;
            //}



            var viewResult = View("Home", resultModel);
            return viewResult;
        }



        
    }
}
