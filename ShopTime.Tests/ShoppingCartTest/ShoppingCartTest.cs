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
    public class ShoppingCartTest
    {
        //IShoppingCartService _shoppingCartService;
        //IShippingService _shippingService;
        //IProductService _productService;
        //IShopTimeToken _shopTimeToken;
        //ShoppingCartResult _result;
        //FakeDatabase _database;

        //public ShoppingCartTest() 
        //{
        //    _database = new FakeDatabase();

        //    //out of stock products
        //    Product outOfStockProduct = new Product();
        //    outOfStockProduct.ProductId = 100001;
        //    outOfStockProduct.InventoryQuantity = 0;
        //    outOfStockProduct.IsBackOrderEnabled = false;
        //    _database.Products.AddObject(outOfStockProduct);

        //    Product inStockProduct = new Product();
        //    inStockProduct.ProductId = 100002;
        //    inStockProduct.InventoryQuantity = 10;
        //    inStockProduct.IsBackOrderEnabled = true;
        //    _database.Products.AddObject(inStockProduct);

        //    //normal products
        //    Product product1 = new Product();
        //    product1.ProductId = 100011;
        //    product1.IsShippingAddressRequired = true;
        //    product1.Weight = 3;
        //    product1.WeightUnit = WeightUnit.Kilogram;
        //    //product1.Price = 20;
        //    product1.InventoryQuantity = 5;

        //    Product product2 = new Product();
        //    product2.ProductId = 100015;
        //    product1.IsShippingAddressRequired = false;
        //    //product1.Price = 60;
        //    product1.InventoryQuantity = 99;

        //    //max cart quantity product
        //    Product maxCartQtyProduct = new Product();
        //    maxCartQtyProduct.ProductId = 100012;

            
        //    //min cart quantity test
        //    Product minCartQtyProduct = new Product();
        //    minCartQtyProduct.ProductId = 100013;

        //}

        //[TestMethod]
        //public void Add_product_into_shoppingcart_test()
        //{
        //    //out of stock test
        //    var product001 = new IndividualProduct();
        //    product001.DisplayName = "HTC One";
        //    product001.Sku = "002";
        //    product001.ManageInventoryMethod = ManageInventoryMethod.Track;
        //    product001.InventoryQuantity = 0;
        //    _productService.CreateAndDeployProduct(product001);

        //    var result = _shoppingCartService.AddProductToCart(product001.ProductId);
        //    result.IsSuccess.Should().BeFalse();

        //    var product002 = new IndividualProduct();
        //    product002.DisplayName = "Acer NoteBook";
        //    product002.Sku = "002";
        //    product002.ManageInventoryMethod = ManageInventoryMethod.NoTrack;
        //    _productService.CreateAndDeployProduct(product002);
            
        //    result = _shoppingCartService.AddProductToCart(product002.ProductId);
        //    result.IsSuccess.Should().BeTrue();

        //    var items = _shoppingCartService.GetShoppingCartItems();
        //    items.Count.Should().Be(1);

        //    //normal product test
        //    result = _shoppingCartService.AddProductToCart(product002.ProductId);
        //    result.IsSuccess.Should().BeTrue();
        //    var newCartItem1 = _shoppingCartService.GetShoppingCartItem(result.LineItemGuid);
        //    newCartItem1.Quantity.Should().Be(1);

        //    result = _shoppingCartService.AddProductToCart(product002.ProductId, 10);
        //    var newCartItem2 = _shoppingCartService.GetShoppingCartItem(result.LineItemGuid);
        //    newCartItem2.Quantity.Should().Be(11);
        //    newCartItem2.LineItemGuid.Should().Be(newCartItem1.LineItemGuid);

        //    items = _shoppingCartService.GetShoppingCartItems();
        //    items.Count.Should().Be(2);

        //    //max cart quantity test
        //    var product003 = new IndividualProduct();
        //    product003.DisplayName = "HTC 8X";
        //    product003.Sku = "003";

        //    _productService.CreateAndDeployProduct(product003);

        //    result = _shoppingCartService.AddProductToCart(product003.ProductId, 10);
        //    result.IsSuccess.Should().BeTrue();
        //    _shoppingCartService.RemoveShoppingCartItem(result.LineItemGuid);
        //    result = _shoppingCartService.AddProductToCart(product003.ProductId, 12);
        //    result.IsSuccess.Should().BeFalse();

        //    //min cart quantity test
        //    var product004 = new IndividualProduct();
        //    product004.DisplayName = "HTC 8X";
        //    product004.Sku = "004";

        //    _productService.CreateAndDeployProduct(product004);

        //    result = _shoppingCartService.AddProductToCart(product004.ProductId, 3);
        //    result.IsSuccess.Should().BeTrue();
        //    _shoppingCartService.RemoveShoppingCartItem(result.LineItemGuid);
        //    result = _shoppingCartService.AddProductToCart(product004.ProductId, 1);
        //    result.IsSuccess.Should().BeFalse();

        //    //not purchasable
        //    var product005 = new IndividualProduct();
        //    product005.DisplayName = "HTC One";
        //    product005.Sku = "005";
        //    product005.IsPreOrderEnabled = false;
        //    _productService.CreateAndDeployProduct(product005);
        //    result = _shoppingCartService.AddProductToCart(product005.ProductId);
        //    result.IsSuccess.Should().BeFalse();
        //}


        //[TestMethod]
        //public void Manage_shoppingcart()
        //{
        //    _shoppingCartService.AddProductToCart(100011);
        //    IList<LineItem> items = _shoppingCartService.GetShoppingCartItems();
        //    var cartItem = items[0];
        //    Assert.AreEqual(1, cartItem.Quantity);

        //    //change quantity
        //    _shoppingCartService.UpdateShoppingCartItem(cartItem.LineItemGuid, 5);
        //    var newCartItem = _shoppingCartService.GetShoppingCartItem(cartItem.LineItemGuid);
        //    Assert.AreEqual(5, newCartItem.Quantity);

        //    _result = _shoppingCartService.UpdateShoppingCartItem(cartItem.LineItemGuid, 0);
        //    Assert.IsTrue(_result.IsSuccess);
        //    newCartItem = _shoppingCartService.GetShoppingCartItem(cartItem.LineItemGuid);
        //    Assert.IsNull(newCartItem);

        //    //delete cart item
        //    _result = _shoppingCartService.AddProductToCart(100011);
        //    _shoppingCartService.RemoveShoppingCartItem(_result.LineItemGuid);
        //    newCartItem = _shoppingCartService.GetShoppingCartItem(cartItem.LineItemGuid);
        //    Assert.IsNull(newCartItem);
        //    items = _shoppingCartService.GetShoppingCartItems();
        //    Assert.AreEqual(0, items.Count);            
        //}

        
        //[TestMethod]
        //public void Calculate_OrderTotalPrice() 
        //{
        //    _shoppingCartService.EmptyShopperShoppingCart();

        //    _shoppingCartService.AddProductToCart(100011);
        //    _shoppingCartService.AddProductToCart(100015);

        //    var orderTotal = _shoppingCartService.GetOrderTotalPriceInfo();

        //    Assert.AreEqual(80, orderTotal.SubTotal);

        //} 



    }
}
