using System;
using System.Collections.Generic;
using JasonSoft.ShopTime.Service;
using JasonSoft.ShopTime.Domain;
using JasonSoft.ShopTime.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace JasonSoft.ShopTime.Tests
{
    public class BuildData
    {
        ICollectionService _collectionService;
        IProductService _productService;

        public BuildData(ICollectionService collectionService, IProductService productService)
        {
            _collectionService = collectionService;
            _productService = productService;
        }

        public void Start() 
        {
            //create collections
            var menCollection = new Collection();
            menCollection.DisplayName = "DisplayName_Men";
            menCollection.ResourceId = "Men";
            //menCollection.Tags = "shirt_tee, long_tee, polo, jeans, underwear, 領帶";
            _collectionService.CreateCollectionAsync(menCollection);

            var womenCollection = new Collection();
            womenCollection.DisplayName = "DisplayName_Women";
            womenCollection.ResourceId = "women";
            //womenCollection.Tags = "shirt_tee, long_tee, polo, jeans, underwear, T-Bra";
            _collectionService.CreateCollectionAsync(womenCollection);

            var kidsCollection = new Collection();
            kidsCollection.DisplayName = "DisplayName_Kids";
            //kidsCollection.Tags = "shirt_tee, long_tee, polo, jeans, heatup,";
            kidsCollection.ResourceId = "kids";
            _collectionService.CreateCollectionAsync(kidsCollection);           
            

            //create product
            var men01 = new Product();
            men01.DisplayName = "DisplayName_My shirt tee";
            men01.ResourceId = "shirt_Tee";
            men01.Tags = "shirt_tee";
            men01.Price = 99;

            var men01_image1 = new Image();
            men01_image1.Position = 0;
            men01.Images.Add(men01_image1);
            var result = _productService.CreateProduct(men01, new int[] {menCollection.Id, womenCollection.Id});
            

            var men02 = new Product();
            men02.DisplayName = "My shirt tee";
            men02.ResourceId = "Men_short_tee2";
            men02.Tags = ("shirt_tee");

            //var men02_ws = new Variation();
            //men02_ws.Options.Add("color", "white");
            //men02_ws.Options.Add("size", "s");
            //men02_ws.Price = 199;
            //men02.Variations.Add(men02_ws);

            //var men02_bs = new Variation();
            //men02_bs.Options.Add("color", "black");
            //men02_bs.Options.Add("size", "s");
            //men02_bs.Price = 199;
            //men02.Variations.Add(men02_bs);

            //var men02_rs = new Variation();
            //men02_rs.Options.Add("color", "red");
            //men02_rs.Options.Add("size", "s");
            //men02_rs.Price = 199;
            //men02.Variations.Add(men02_rs);

            //var men02_wm = new Variation();
            //men02_wm.Options.Add("color", "white");
            //men02_wm.Options.Add("size", "m");
            //men02_wm.Price = 299;
            //men02.Variations.Add(men02_wm);

            //var men02_bm = new Variation();
            //men02_bm.Options.Add("color", "black");
            //men02_bm.Options.Add("size", "m");
            //men02_bm.Price = 299;
            //men02.Variations.Add(men02_bm);

            //var men02_rm = new Variation();
            //men02_rm.Options.Add("color", "red");
            //men02_rm.Options.Add("size", "m");
            //men02_rm.Price = 299;
            //men02.Variations.Add(men02_rm);

            _productService.CreateProduct(men02, new int[] {menCollection.Id});

            //create 108 products
            for (var i = 0; i < 108; i++)
            {
                var product = new Product();
                product.DisplayName = "DisplayName_AutoTest" + i.ToString();
                product.ResourceId = "autotest" + i.ToString();
                product.Tags = ("autotest");
                product.Price = 108;
                _productService.CreateProduct(product, new int[] {kidsCollection.Id});

            }



          
        
        }


    }
}
