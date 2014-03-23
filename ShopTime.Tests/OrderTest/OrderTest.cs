using System;
using System.Collections;
using System.Collections.Generic;
using JasonSoft;
using JasonSoft.ShopTime.Service;
using JasonSoft.ShopTime.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace JasonSoft.ShopTime.Test
{
    [TestClass]
    public class OrderTest
    {
        //IShoppingCartService _shoppingCartService;
        //IOrderService _orderService;
        //IProductService _productService;
        //IShopTimeToken _workContext;
        //FakeDatabase _database;

        //[TestMethod]
        //public void Place_order()
        //{         
        //    _shoppingCartService.AddProductToCart(101); //digital
        //    _shoppingCartService.AddProductToCart(201); //physical

        //    ContactInfo billingInfo = new ContactInfo();
        //    billingInfo.FirstName = "Jason";

        //    ContactInfo shippingInfo = new ContactInfo();
        //    shippingInfo.FirstName = "Angela";
        //    shippingInfo.CountryId = 12;
        //    shippingInfo.City = "taipei";

        //    _shopTimeToken.CurrentOrder.IsTestOrder = true;
        //    _shopTimeToken.CurrentOrder.BillingAddressInfo = billingInfo;
        //    _shopTimeToken.CurrentOrder.ShippingAddressInfo = shippingInfo;
        //    _shopTimeToken.CurrentOrder.PaymentMethod = new PaymentMethod();
            
        //    var successResult = _orderService.PlaceOrder();
        //    var order = _orderService.GetOrder(successResult.OrderId);

        //    Assert.AreEqual(OrderStatus.Processing, order.OrderStatus);
        //    Assert.AreEqual(2, order.LineItems.Count);       
        //}

        //[TestMethod]
        //public void Place_order_with_error()
        //{
        //    _shoppingCartService.EmptyShopperShoppingCart();
                        
        //    var emptyCartResult = _orderService.PlaceOrder();
        //    Assert.IsFalse(emptyCartResult.IsSuccess);
        //    Assert.AreEqual("no_item_in_the_cart_msg", emptyCartResult.ExceptionInfo[0].Message); 

        //    _shoppingCartService.AddProductToCart(201, 8); //physical

        //    ContactInfo billingInfo = new ContactInfo();
        //    billingInfo.FirstName = "Jason";

        //    ContactInfo shippingInfo = new ContactInfo();
        //    shippingInfo.FirstName = "Angela";
        //    shippingInfo.CountryId = 12;
        //    shippingInfo.City = "taipei";

        //    _shopTimeToken.CurrentOrder.IsTestOrder = true;
        //    _shopTimeToken.CurrentOrder.BillingAddressInfo = billingInfo;
        //    _shopTimeToken.CurrentOrder.ShippingAddressInfo = shippingInfo;
        //    _shopTimeToken.CurrentOrder.PaymentMethod = new PaymentMethod();

        //    //invertory is not enough
        //    _productService.UpdateProductInvertory(201, 5);
        //    var result = _orderService.PlaceOrder();
        //    result.IsSuccess.Should().BeFalse();
        //    Assert.AreEqual("stock_is_not_enough_msg", result.ExceptionInfo[0].Message); 
            
        //    //change to out of stock
        //    _productService.UpdateProductInvertory(201, 0);
        //    var noStockResult = _orderService.PlaceOrder();
        //    Assert.AreEqual(false, noStockResult.IsSuccess);
        //    Assert.AreEqual("out_of_stock_msg", noStockResult.ExceptionInfo[0].Message);      
      
        //    //change to no purchasable
        //    var product = _productService.GetProduct(201) as IndividualProduct;
        //    product.IsPurchasable = false;
        //    _productService.UpdateAndDeployProduct(product);
        //    result = _orderService.PlaceOrder();
        //    result.IsSuccess.Should().BeFalse();
        //}

        //[TestMethod]
        //public void Order_lookup() 
        //{
        //    var order = _orderService.GetOrder(1001);
        //    Assert.AreEqual<int>(2, order.LineItems.Count);

        //    var product1 = _productService.GetProduct(order.LineItems[0].Product.ProductGuid);

            
        //}

    }
}
