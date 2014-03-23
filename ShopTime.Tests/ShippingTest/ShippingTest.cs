using System;
using System.Collections;
using System.Collections.Generic;
using JasonSoft;
using JasonSoft.ShopTime.Service;
using JasonSoft.ShopTime.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonSoft.ShopTime.Test
{
    [TestClass]
    public class ShippingTest
    {
        IShoppingCartService _shoppingCartService;
        IShippingService _shippingService;
        IShopTimeToken _shopTimeToken;

        
        [TestMethod]
        public void Calculate_shipping_fee()
        {
            var address = new ContactInfo();
            address.CountryId = 5;
            address.City = "taipei";

            var request = new ShippingOptionRequest();
            request.Arrival = address;
            
            
            var shippingOptions = _shippingService.GetShippingOptions(request);
            
            var cashOnDelivery = shippingOptions[0];
            Assert.AreEqual(120, cashOnDelivery.Rate);

            var taiwanPost = shippingOptions[1];
            Assert.AreEqual(50, taiwanPost.Rate);

        } 


    }
}
