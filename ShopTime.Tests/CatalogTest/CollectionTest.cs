using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JasonSoft.Components.Castle.MicroKernel.Registration.Lifestyle;
using JasonSoft.Components.EnterpriseLibrary.Unity;
using JasonSoft.Components.Quartz;
using JasonSoft.ShopTime.Service;
using JasonSoft.ShopTime.Domain;
using JasonSoft.ShopTime.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using JasonSoft;

namespace JasonSoft.ShopTime.Tests
{
    [TestClass]
    public class CollectionTest
    {
        private ICollectionService _collectionService;
        private IProductService _productService;
        private UnityContainer _container;


        [TestMethod]
        public async Task Get_collection_by_resouceId()
        {
            var task1 = _collectionService.GetCollectionAsync("mEn/");
            var task2 = _collectionService.GetCollectionAsync("/men/");
            var task3 = _collectionService.GetCollectionAsync("Men/shirt_tee/");
            var task4 = _collectionService.GetCollectionAsync("Men/notexist");
            var task5 = _collectionService.GetCollectionAsync("wrong_name");

            Task.WaitAll(task1, task2, task3, task4, task5);

            var menCollection1 = task1.Result.ResultValue;
            menCollection1.Should().NotBeNull();

            var menCollection2 = task2.Result.ResultValue;
            menCollection2.Should().NotBeNull();

            var menCollection3 = task3.Result.ResultValue;
            menCollection3.Should().NotBeNull();
            menCollection3.Tags.Count.Should().Be(6);
            menCollection3.Tags.Contains("shirt_tee").Should().BeTrue();

            var menCollection4 = task4.Result.ResultValue;
            menCollection4.Should().BeNull();

            var menCollection5 = task5.Result.ResultValue;
            menCollection5.Should().BeNull();

            menCollection1.Id.Should().Be(menCollection2.Id);
            menCollection2.Id.Should().Be(menCollection3.Id);
        }

        [TestMethod]
        public async Task Get_collections_by_productId()
        {
            //var product = _productService.GetProduct("shirt_tee");
            //var collections = _collectionService.GetCollections(product.ProductId);

            //collections.Length.Should().Be(2);
            //collections[0].ResourceId.Should().Be("Men");
            //collections[1].ResourceId.Should().Be("women");
        }


        [TestMethod]
        public async Task Get_All_Collections()
        {
            var task1 = _collectionService.GetCollectionsCountAsync();
            var task2 = _collectionService.GetCollectionsAsync(null, null, null, false);

            Task.WaitAll(task1, task2);

            var count = task1.Result.ResultValue;
            count.Should().Be(3);
            var collections = task2.Result.ResultValue;
            collections.Count.Should().Be(count); //men, women, kids
            collections[2].Id.Should().BeGreaterThan(collections[0].Id); //sort test
        }


        [TestMethod]
        public async Task Create_and_get_collection_test()
        {
            //create
            var nikeCollection = new Collection
            {
                DisplayName = "DisplayName_Nike",
                ResourceId = "Nike",                
            };

            var newCollectionId = 0;
            await _collectionService.CreateCollectionAsync(nikeCollection).Complete((result, err) =>
            {
                err.Should().BeNull();
                newCollectionId = result;
            });

            newCollectionId.Should().BeGreaterThan(0);



            //get
            await _collectionService.GetCollectionAsync(newCollectionId).Complete((result, err) =>
            {
                err.Should().BeNull();
                result.DisplayName.Should().Be(nikeCollection.DisplayName);
                result.ResourceId.Should().Be(nikeCollection.ResourceId);
                result.StoreId.Should().Be(1);
                //result.ImageId.Should().BeGreaterThan(0);
                //image.Should().NotBeNull();
                //image.Url.Should().Be(string.Format("www.mystore.com/public/collection/{0}/{1}", newCollectionId, image.FileName));

            });
        }

        [TestMethod]
        public async Task Create_the_same_resouceId()
        {
            //the same resourceId
            var menCollection = new Collection
            {
                ResourceId = "men",
                DisplayName = "men",
            };

            await _collectionService.CreateCollectionAsync(menCollection).Complete((result, err) =>
            {
                err.Should().NotBeNull();
            });
        }


        [TestMethod]
        public async Task Update_collection()
        {
            Collection oldCollection = null;
            await _collectionService.GetCollectionAsync("men").Complete((result, err) =>
            {
                err.Should().BeNull();
                oldCollection = result;
                result.DisplayName.Should().Be("DisplayName_Men");
            });

            oldCollection.DisplayName = "new_name";
            oldCollection.Description = "<h1>hello</h1>";
            oldCollection.Tags.Clear();
            oldCollection.Tags.Add("watch");
            oldCollection.Tags.Add("apple");
            oldCollection.ResourceId = "girls";

            await _collectionService.UpdateCollectionAsync(oldCollection);

            await _collectionService.GetCollectionAsync("girls").Complete((collection, err) =>
            {
                err.Should().BeNull();
                collection.DisplayName.Should().Be(oldCollection.DisplayName);
                collection.Description.Should().Be(oldCollection.Description);
                collection.Tags.Should().Contain(oldCollection.Tags);
                collection.ResourceId.Should().Be(oldCollection.ResourceId);
            });

        }

        [TestMethod]
        public async Task Delete_collections()
        {
            var menCollection = (await _collectionService.GetCollectionAsync("men")).ResultValue;
            menCollection.Should().NotBeNull();

            var customFields = (await _collectionService.GetCustomFieldsCountAsync(menCollection.Id)).ResultValue;
            customFields.Should().Be(1);

            var result = await _collectionService.DeleteCollectionAsync(menCollection);
            result.Error.Should().BeNull();

            var newCollection = (await _collectionService.GetCollectionAsync("men")).ResultValue;
            newCollection.Should().BeNull();

            customFields = (await _collectionService.GetCustomFieldsCountAsync(menCollection.Id)).ResultValue;
            customFields.Should().Be(0);

            //var product = _productService.GetProduct("shirt_tee");
            //var collections = _collectionService.GetCollections(product.ProductId);
            //collections.Length.Should().Be(1);

            //product = _productService.GetProduct("shirt_tee");
            //collections = _collectionService.GetCollections(product.ProductId);
            //collections.Should().BeNull();
        }


        [TestMethod]
        public async Task Get_CustomFields_By_Key()
        {

            await _collectionService.GetCustomFieldAsync(1, "jason.ab").Success(customField =>
            {
                customField.Should().BeNull();
            });

            await _collectionService.GetCustomFieldAsync(1, "jason.abc").Success(customField =>
            {
                customField.Should().NotBeNull();
                customField.Id.Should().Be(1);
                customField.Type.Should().Be(CustomFieldType.Collection);
                customField.ParentId.Should().Be(1);
                customField.Key.Should().Be("Jason.ABC");
                customField.Value.Should().Be("Hell World");
            });

        }


        [TestMethod]
        public async Task Creaet_CustomFields()
        {
            var myCustomField = new CustomField()
            {
                Key = "Jason.abc",
                Value = "true",
            };

            int newCustomFieldId = 0;
            await _collectionService.CreateCustomFieldAsync(1, myCustomField).Success(newId =>
            {
                newCustomFieldId = newId;
            });

            await _collectionService.GetCustomFieldAsync(1, newCustomFieldId).Success(customField =>
            {
                customField.Should().NotBeNull();
                customField.Id.Should().BeGreaterThan(1);
                customField.Type.Should().Be(CustomFieldType.Collection);
                customField.ParentId.Should().Be(1);
                customField.Key.Should().Be(myCustomField.Key);
                customField.Value.Should().Be(myCustomField.Value);
            });

        }


        [TestMethod]
        public async Task Creaet_CustomFields_with_duplicate_key()
        {
            var myCustomField = new CustomField()
            {
                Key = "Jason.abc",
                Value = "true",
            };

            await _collectionService.CreateCustomFieldAsync(1, myCustomField).Error(err =>
            {
                err.Should().NotBeNull();
            });
        }


        [TestMethod]
        public async Task Update_CustomFields()
        {
            var getCustomFieldResult = (await _collectionService.GetCustomFieldAsync(1, "jason.abc"));
            getCustomFieldResult.Error.Should().BeNull();
            
            var customField = getCustomFieldResult.ResultValue;
            customField.Should().NotBeNull();

            customField.Key = "jaSon";
            customField.Value = "false";

            var updateResult = (await _collectionService.UpdateCustomFieldAsync(customField));
            updateResult.Error.Should().BeNull();

            getCustomFieldResult = (await _collectionService.GetCustomFieldAsync(1, "jason"));
            getCustomFieldResult.Error.Should().BeNull();

            var newCustomField = getCustomFieldResult.ResultValue;
            newCustomField.Should().NotBeNull();

            newCustomField.Key.Should().Be(customField.Key);
            newCustomField.Value.Should().Be(customField.Value);

            //get new service instance
            //error test
            _collectionService = _container.Resolve<CollectionService>();

            getCustomFieldResult = (await _collectionService.GetCustomFieldAsync(1, "jason"));
            getCustomFieldResult.Error.Should().BeNull();

            customField = getCustomFieldResult.ResultValue;
            customField.Should().NotBeNull();
            customField.Key = "";
            customField.Value = string.Empty; //error

            updateResult = await _collectionService.UpdateCustomFieldAsync(customField);
            updateResult.Error.Should().NotBeNull();
            Console.WriteLine(updateResult.Error.Message);

        }


        [TestMethod]
        public async Task Delete_customFields()
        {
            var customFields = (await _collectionService.GetCustomFieldsAsync(1)).ResultValue;
            customFields.Should().NotBeNull();

            var customFieldsCount = (await _collectionService.GetCustomFieldsCountAsync(1)).ResultValue;
            customFieldsCount.Should().Be(1);

            var deleteCustomFieldResult = await _collectionService.DeleteCustomFieldsAsync(customFields);
            deleteCustomFieldResult.Error.Should().BeNull();

            customFields = (await _collectionService.GetCustomFieldsAsync(1, false)).ResultValue;
            customFields.IsNullOrEmpty().Should().BeTrue();

            customFieldsCount = (await _collectionService.GetCustomFieldsCountAsync(1)).ResultValue;
            customFieldsCount.Should().Be(0);
        }



        [TestCleanup]
        private void RemoveDatabase()
        {
            var _shopTimeDb = _container.Resolve<ShopTimeDbContext>();
            _shopTimeDb.Database.Delete();
        }

        public CollectionTest()
        {
            var unityConfig = new UnityConfig();
            unityConfig.RegisterComponents();
            _container = unityConfig.Container;

            Database.SetInitializer(new TestDbInitializer());

            _collectionService = _container.Resolve<CollectionService>();
            //_productService = _container.Resolve<ProductService>();
        }

    }
}
