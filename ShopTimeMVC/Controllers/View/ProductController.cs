using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JasonSoft.ShopTimeMVC.Models;

namespace JasonSoft.ShopTimeMVC.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            ViewBag.Title = "All Products";

            var result = new ProductsViewModel();


            for (Int32 i = 0; i < 50; i++)
            {
                var car = new ProductViewModel();
                car.DisplayName = "BMW" + i.ToString();
                car.Description = "BMW 335i";
                car.Price = 100m;

                result.Products.Add(car);
            }        

           
            


            return View(result);
        }

        public ActionResult DisplayProductDetail(string productName)
        {
            var resultModel = new ProductDetailViewModel();
            resultModel.ProductId = 66;
            resultModel.DisplayName = productName;
            resultModel.Description = "中颱蘇力來襲，根據氣象局最新資料顯示，颱風中心在宜蘭東南東方海面，暴風圈正逐漸進入臺灣北部及東半部陸地，各地風雨將逐漸增強。預計颱風中心強度有減弱的趨勢。";
            resultModel.Price = 3567890m;

            return View("Product", resultModel);
        }

        public ActionResult DisplayProducts() 
        {
            return View();
        }



    }
}
