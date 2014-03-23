using System;
using System.Net;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Caching;
using System.Web.Http.Results;
using JasonSoft.ShopTime.Domain;
using JasonSoft.ShopTime.Service;
using JasonSoft.ShopTimeMVC.Controllers.Api;
using JasonSoft.ShopTimeMVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Moq;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace JasonSoft.ShopTimeMVC.Tests.Controllers.Api
{
     [TestClass]
    public class ProductApiTest
    {
        private Mock<IProductService> _productServiceMock;

        public ProductApiTest()
        {
            AutoMapperConfig.Configure();
            Mapper.AssertConfigurationIsValid();

            _productServiceMock = new Mock<IProductService>();
        }

        [TestMethod]
        public void GetCollectionTest()
        {
            
        }
    }
}
