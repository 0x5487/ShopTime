using System;
using System.Collections.Generic;
using System.Linq;
using JasonSoft.ShopTime.Service;
using JasonSoft.ShopTime.Domain;
using JasonSoft.ShopTime.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace JasonSoft.ShopTime.Tests
{
    [TestClass]
    public class PriceTest
    {
        //IPriceService _priceService;
        //IProductService _productService;
        //IShopTimeToken _shopTimeToken;

        //public PriceTest() 
        //{
        
        //}


        //[TestMethod]
        //public void Set_product_price_test() 
        //{
        //    var priceListDemo = new PriceList();
        //    priceListDemo.StartDateUtc = DateTime.UtcNow;

        //    var result = _priceService.CreatePriceList(priceListDemo);
        //    result.IsSuccess.Should().BeTrue();
            
        //    var returnedPriceListId = result.ResultValue.ChangeTypeTo<Int32>();

        //    priceListDemo = _priceService.GetPriceList(priceListDemo.PriceListId);
        //    priceListDemo.PriceListStatus = PriceListStatus.Active;

        //    var productPrices = _priceService.GetProductPrices(returnedPriceListId, "USD");


        //    var myPrice1 = productPrices.Where(obj => obj.Locale == "en-US" && obj.ProductId == 1256).Single();
        //    myPrice1.Value = 10.99m;
        //    myPrice1.ObjectStatus = ObjectStatus.Modified;

        //    var myPrice2 = productPrices.Where(obj => obj.Locale == "en-CA" && obj.ProductId == 1256).Single();
        //    myPrice2.Value = 20;
        //    myPrice2.ObjectStatus = ObjectStatus.Modified;

        //    var prices = new List<ProductPrice>();
        //    prices.Add(myPrice1);
        //    prices.Add(myPrice2);


        //    _priceService.UpdateProductPrices(prices);

        //    _shopTimeToken.CurrentOrder.Locale = "en-US";
        //    _shopTimeToken.CurrentOrder.CurrencyCode = "USD";

        //    var product = _productService.GetPushlishedProduct(1256);


        //    _shopTimeToken.CurrentOrder.Locale = "en-CA";

        //    product = _productService.GetPushlishedProduct(1256);


        //    productPrices = _priceService.GetProductPrices(product.ProductId);
        //    productPrices.Where(obj => obj.Locale == "en-US" && obj.Currency == "USD").Single().Value.Should().Be(10.99m);
        //    productPrices.Where(obj => obj.Locale == "en-CA" && obj.Currency == "USD").Single().Value.Should().Be(20);

                        
        //}

        
    }
}
