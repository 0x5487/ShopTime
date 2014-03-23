using System;
using System.Collections.Generic;
using JasonSoft.ShopTime.Service;
using JasonSoft.ShopTime.Domain;
using JasonSoft.ShopTime.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace JasonSoft.ShopTime.Test
{
    [TestClass]
    public class ProductTest
    {
        private IProductService _productService;
        private ICollectionService _collectionService;
        private IShopTimeToken _shopTimeToken;


        [TestMethod]
        public void Get_product_by_resouceId()
        {
            var product1 = _productService.GetProduct("shirt_tee");
            var product2 = _productService.GetProduct("/shirt_Tee/");
            var product3 = _productService.GetProduct("/shirt_tee/noexist");
            var product4 = _productService.GetProduct("wrong name");

            product1.Id.Should().Be(product2.Id);
            product1.IsPurchasable.Should().BeFalse();
            product1.Id.Should().Be(product2.Id);
            product3.Should().BeNull();
            product4.Should().BeNull();
        }

        [TestMethod]
        public void Get_products_by_collection()
        {
            //var collection = _collectionService.GetCollection("Kids/autotest/");

            //var products = _productService.GetProductsByCollection(collection.CollectionId);
            //products.Count.Should().Be(ShopTimeSetting.PageSize);

            //var count = _productService.GetCountOfProducts(collection.CollectionId);
            //products = _productService.GetProductsByCollection(collection.CollectionId, collection.CurrentTags[0], count);
            //products.Count.Should().Be(108);
        }

        [TestMethod]
        public void Get_collections()
        {
            var product = _productService.GetProduct("Men_shirt_tee2");
            product.ProductType.Should().Be(ProductType.Product);
        }

        [TestMethod]
        public void Create_the_same_resouceId()
        {
            //var product = new Product();
            //product.DisplayName = "desk";
            //product.ResourceId = "Men_shirt_tee1";
            //var result = _productService.CreateProduct(product);
            //result.Status.Should().Be(ResultStatus.Success);

            //product.ResourceId = "desk";
            //result = _productService.CreateProduct(product);
            //result.Status.Should().Be(ResultStatus.Success);
        }

        [TestMethod]
        public void Remove_products()
        {
            //var product = _productService.GetProduct("shirt_tee");
            //product.Should().NotBeNull();

            //var result = _productService.RemoveProducts(new int[] {product.ProductId});
            //result.Status.Should().Be(ResultStatus.Success);

            //product = _productService.GetProduct("shirt_tee");
            //product.Should().BeNull();

            //var kidsCollection = _collectionService.GetCollection("Kids/autotest");
            //var products = _productService.GetProductsByCollection(kidsCollection.CollectionId, kidsCollection.CurrentTags[0], 999);
            //products.Count.Should().BeGreaterThan(0);

            //var productIds = new List<int>();

            //foreach (var product1 in products)
            //{
            //    productIds.Add(product1.ProductId);
            //}

            //result = _productService.RemoveProducts(productIds);
            //products = _productService.GetProductsByCollection(kidsCollection.CollectionId, kidsCollection.CurrentTags[0], 999);
            //products.Should().BeNull();

        }


        [TestMethod]
        public void Update_a_product()
        {
            //var product = _productService.GetProduct("shirt_tee");
            //product.DisplayName = "DisplayName_New";
            //product.Description = "Description_New";
            //product.IsPurchasable = true;
            //product.Tags = "newTag1, newTag2, newTag3";
            //product.Price = 959;

            //var result = _productService.UpdateProduct(product);
            //result.Status.Should().Be(ResultStatus.Success);

            //product = _productService.GetProduct("shirt_tee");
            //product.DisplayName.Should().Be("DisplayName_New");
            //product.Description.Should().Be("Description_New");
            //product.IsPurchasable.Should().BeTrue();
            //product.Tags.Should().Contain("newTag1");
            //product.Tags.Should().Contain("newTag2");
            //product.Tags.Should().Contain("newTag3");
            //product.Price.Should().Be(959);


        }



    }
}
