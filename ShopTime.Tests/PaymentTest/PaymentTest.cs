using System;
using JasonSoft.ShopTime.Service;
using JasonSoft.ShopTime.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonSoft.ShopTime.Tests
{
    [TestClass]
    public class PaymentTest
    {
        IProductService _productService;
        IShopTimeToken ShopTimeToken { get; set; }

        [TestMethod]
        public void List_active_payment_methods()
        {

        }
    }
}
