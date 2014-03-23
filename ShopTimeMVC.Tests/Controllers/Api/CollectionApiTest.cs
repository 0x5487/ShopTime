using System;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using System.Web.Caching;
using System.Web.Http.Results;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;
using JasonSoft.ShopTime.Service;
using JasonSoft.ShopTimeMVC.Controllers.Api;
using JasonSoft.ShopTimeMVC.Models;
using JasonSoft.ShopTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Moq;
using System.ComponentModel.DataAnnotations;
using AutoMapper;


namespace JasonSoft.ShopTimeMVC.Tests.Api
{
    [TestClass]
    public class CollectionApiTest
    {
        private Mock<ICollectionService> _collectionServiceMock;

        public CollectionApiTest()
        {
            AutoMapperConfig.Configure();
            Mapper.AssertConfigurationIsValid();

            _collectionServiceMock = new Mock<ICollectionService>();
        }


        [TestMethod]
        public async Task GetCollectionTest()
        {
            var menCollection = new Collection
            {
                Id = 7,
                ResourceId = "men",
                DisplayName = "DisplayName_men",
                Description = "Desc",
                Tags = new List<string>() {"jean, polo"},
                IsVisible = true,
                //Image = new Image() {Url = "http://www.example.com/public/collection/1/DisplayName_men.jpg"}
            };


            var collectionResult = new ShopTimeResult<Collection>(menCollection);
            var notFoundResult = new ShopTimeResult<Collection> {Error = new Error() {CodeNumber = 404}};
            var badResult = new ShopTimeResult<Collection> {Error = new Error()};

            var collectionTask = Task.FromResult<IResult<Collection>>(collectionResult);
            var notFoundTask = Task.FromResult<IResult<Collection>>(notFoundResult);
            var badTask = Task.FromResult<IResult<Collection>>(badResult);

            //arrange
            _collectionServiceMock.Setup(x => x.GetCollectionAsync(99)).Returns(notFoundTask);
            _collectionServiceMock.Setup(x => x.GetCollectionAsync(7)).Returns(collectionTask);
            _collectionServiceMock.Setup(x => x.GetCollectionAsync(0)).Returns(badTask);

            var collectionsController = new CollectionsV1Controller(_collectionServiceMock.Object);
                
            //return notFound
            var task1 = collectionsController.GetCollectionAsync(99).ContinueWith(task =>
            {
                task.Result.Should().BeOfType<NotFoundResult>();
                Console.WriteLine("task1:{0}", Thread.CurrentThread.ManagedThreadId);
                
            });
            Console.WriteLine("main:{0}", Thread.CurrentThread.ManagedThreadId);

            //return single collectionModel
            var task2 = collectionsController.GetCollectionAsync(7).ContinueWith(task =>
            {
                var response = task.Result as OkNegotiatedContentResult<CollectionModel>;
                var model = response.Content;
                model.Id.Should().Be(menCollection.Id);
                model.ResourceId.Should().Be(menCollection.ResourceId);
                model.DisplayName.Should().Be(menCollection.DisplayName);
                model.Description.Should().Be(menCollection.Description);
                model.IsVisible.Should().BeTrue();
                //model.Image.Url.Should().Be(menCollection.Image.Url);
                model.Products.Should().BeNull();
                model.CustomFields.Should().BeNull();
                Console.WriteLine("task2:{0}", Thread.CurrentThread.ManagedThreadId);
            });

            //return bad reqesut
            var task3 = collectionsController.GetCollectionAsync(0).ContinueWith(task =>
            {
                task.Result.Should().BeOfType<BadRequestResult>();
                Console.WriteLine("task3:{0}", Thread.CurrentThread.ManagedThreadId);
            });

            Task.WaitAll(task1, task2, task3);
            Console.WriteLine("done:{0}", Thread.CurrentThread.ManagedThreadId);
            _collectionServiceMock.VerifyAll();
        }



        [TestMethod]
        public void GetCollectionsTest()
        {
            var collections = new List<Collection>();
            for (var i = 0; i < 42; i++)
            {
                var collection = new Collection();
                collection.Id = i;
                collection.ResourceId = string.Format("resouce_men{0}", i.ToString());
                collection.DisplayName = string.Format("DisplayName_men{0}", i.ToString());
                collection.Description = "Desc";
                collection.Tags = new List<string>(){ "jean, polo"};
                collection.IsVisible = true;
                //collection.Image = new Image() { Url = string.Format("http://cdn.example.com/collection/{0}/DisplayName_men.jpg", i.ToString()) };
                collections.Add(collection);
            }

            var collectionsResult = new ShopTimeResult<IList<Collection>>(collections);
            var emptyResult = new ShopTimeResult<IList<Collection>>();
            var notFoundResult = new ShopTimeResult<IList<Collection>> {Error = new Error() {CodeNumber = 404}};

            var emptyTaskResult = Task.FromResult<IResult<IList<Collection>>>(emptyResult);
            var collectionsTaskResult = Task.FromResult<IResult<IList<Collection>>>(collectionsResult);
            var notFoundTaskResult = Task.FromResult<IResult<IList<Collection>>>(notFoundResult);
            
            //arrange
            _collectionServiceMock.Setup(x => x.GetCollectionsAsync(null, null, null, null, true)).Returns(emptyTaskResult);
            _collectionServiceMock.Setup(x => x.GetCollectionsAsync(43, null, null, null, true)).Returns(notFoundTaskResult);
            _collectionServiceMock.Setup(x => x.GetCollectionsAsync(1, null, null, null, true)).Returns(collectionsTaskResult);
            var collectionsController = new CollectionsV1Controller(_collectionServiceMock.Object);
            
            // return empty
            var actionResult = collectionsController.GetCollectionsAsync(); 
            var statusCoderesult = actionResult.Result as StatusCodeResult;
            statusCoderesult.StatusCode.Should().Be(HttpStatusCode.NoContent);

            //return notFound
            var actionResult1 = collectionsController.GetCollectionsByProductIdAsync(43).Result;
            actionResult1.Should().BeOfType<NotFoundResult>();

            //return collections
            var response = collectionsController.GetCollectionsByProductIdAsync(1).Result as OkNegotiatedContentResult<IList<CollectionModel>>;
            var model = response.Content;
            model.Count.Should().Be(collections.Count);


            _collectionServiceMock.VerifyAll();
        }

        [TestMethod]
        public void GetCountTest()
        {
            var countResult = new ShopTimeResult<int>(8);
            var notFoundResult = new ShopTimeResult<int> {Error = new Error() {CodeNumber = 404}};


            var countTask = Task.FromResult<IResult<int>>(countResult);
            var notFoundTask = Task.FromResult<IResult<int>>(notFoundResult);

            _collectionServiceMock.Setup(x => x.GetCollectionsCountAsync()).Returns(countTask);
            _collectionServiceMock.Setup(x => x.GetCollectionsCountAsync(3)).Returns(countTask);
            _collectionServiceMock.Setup(x => x.GetCollectionsCountAsync(99)).Returns(notFoundTask);
            var collectionsController = new CollectionsV1Controller(_collectionServiceMock.Object);

            //return  count test
            var actionResult = collectionsController.GetCollectionCountAsync().Result;
            var response = actionResult as OkNegotiatedContentResult<int>;
            response.Content.Should().Be(8);

            actionResult = collectionsController.GetCollectionCountAsync(3).Result;
            response = actionResult as OkNegotiatedContentResult<int>;
            response.Content.Should().Be(8);

            //return not found
            actionResult = collectionsController.GetCollectionCountAsync(99).Result;
            actionResult.Should().BeOfType<NotFoundResult>();

            _collectionServiceMock.VerifyAll();
        }

        [TestMethod]
        public void GetSingleMetaDataTest()
        {
            var singleM = new CustomField();
            singleM.Id = 108;
            singleM.Key = "hometext";
            singleM.Value = "true";

            var metaResult = new ShopTimeResult<CustomField>(singleM);
            var badResult = new ShopTimeResult<CustomField> {Error = new Error()};
            var notFoundResult = new ShopTimeResult<CustomField> {Error = new Error() {CodeNumber = 404}};


            var metaTask = Task.FromResult<IResult<CustomField>>(metaResult);
            var badTask = Task.FromResult<IResult<CustomField>>(badResult);
            var notFoundTask = Task.FromResult<IResult<CustomField>>(notFoundResult);
            

            _collectionServiceMock.Setup(x => x.GetCustomFieldAsync(3, 108)).Returns(metaTask);
            _collectionServiceMock.Setup(x => x.GetCustomFieldAsync(99, 99)).Returns(notFoundTask);
            _collectionServiceMock.Setup(x => x.GetCustomFieldAsync(0, 0)).Returns(badTask);
            var collectionsController = new CollectionsV1Controller(_collectionServiceMock.Object);
            
            //single test
            var actionResult = collectionsController.GetCustomFieldAsync(3, 108).Result;
            var response = actionResult as OkNegotiatedContentResult<CustomFieldModel>;
            var metaModel = response.Content;
            metaModel.Id.Should().Be(singleM.Id);
            metaModel.Key.Should().Be(singleM.Key);
            metaModel.Value.Should().Be(singleM.Value);

            //notFound test
            actionResult = collectionsController.GetCustomFieldAsync(99, 99).Result;
            actionResult.Should().BeOfType<NotFoundResult>();

            //badresult request
            actionResult = collectionsController.GetCustomFieldAsync(0, 0).Result;
            actionResult.Should().BeOfType<BadRequestResult>();

            _collectionServiceMock.VerifyAll();
        }

        [TestMethod]
        public void GetCustomFieldTest()
        {
            var data = new List<CustomField>();

            for (int i = 1; i < 3; i++)
            {
                var singleM = new CustomField();
                singleM.Id = i;
                singleM.Key = "hometext";
                singleM.Value = "true";
                data.Add(singleM);
            }

            var metaResult = new ShopTimeResult<IList<CustomField>>(data);
            var notFoundResult = new ShopTimeResult<IList<CustomField>> {Error = new Error() {CodeNumber = 404}};
            var emptyResult = new ShopTimeResult<IList<CustomField>>();

            var metaTask = Task.FromResult<IResult<IList<CustomField>>>(metaResult);
            var notFoundTask = Task.FromResult<IResult<IList<CustomField>>>(notFoundResult);
            var emptyTask = Task.FromResult<IResult<IList<CustomField>>>(emptyResult);

            _collectionServiceMock.Setup(x => x.GetCustomFieldsAsync(3, true)).Returns(metaTask);
            _collectionServiceMock.Setup(x => x.GetCustomFieldsAsync(99, true)).Returns(notFoundTask);
            _collectionServiceMock.Setup(x => x.GetCustomFieldsAsync(58, true)).Returns(emptyTask);
            var collectionsController = new CollectionsV1Controller(_collectionServiceMock.Object);
            
            //get meta data
            var actionResult = collectionsController.GetCustomFieldsAsync(3).Result;
            var response = actionResult as OkNegotiatedContentResult<IList<CustomFieldModel>>;
            response.Content.Count.Should().Be(2);
            var metaModel = response.Content[1];
            metaModel.Id.Should().Be(2);
            metaModel.Key.Should().Be("hometext");

            //not found test
            actionResult = collectionsController.GetCustomFieldsAsync(99).Result;
            actionResult.Should().BeOfType<NotFoundResult>();

            //empty test
            actionResult = collectionsController.GetCustomFieldsAsync(58).Result;
            var statusCoderesult = actionResult as StatusCodeResult;
            statusCoderesult.StatusCode.Should().Be(HttpStatusCode.NoContent);

            _collectionServiceMock.VerifyAll();
        }



        [TestMethod]
        public void GetCustomFieldsCountTest()
        {

            var metaResult = new ShopTimeResult<int>(0);
            var notFoundResult = new ShopTimeResult<int> {Error = new Error() {CodeNumber = 404}};

            var metaTask = Task.FromResult<IResult<int>>(metaResult);
            var notFoundTask = Task.FromResult<IResult<int>>(notFoundResult);

            _collectionServiceMock.Setup(x => x.GetCustomFieldsCountAsync(118)).Returns(metaTask);
            _collectionServiceMock.Setup(x => x.GetCustomFieldsCountAsync(99)).Returns(notFoundTask);
            var collectionsController = new CollectionsV1Controller(_collectionServiceMock.Object);
            
            //get single meta data
            var actionResult = collectionsController.GetCustomFieldsCountAsync(118).Result;
            var response = actionResult as OkNegotiatedContentResult<int>;
            response.Content.Should().Be(0);

            //not found
            actionResult = collectionsController.GetCustomFieldsCountAsync(99).Result;
            actionResult.Should().BeOfType<NotFoundResult>();

            _collectionServiceMock.VerifyAll();
        }


        [TestMethod]
        public void CreateCustomFieldTest()
        {
            var metaData = new CustomField();
            metaData.Id = 5;
            metaData.Key = "App_Code";
            metaData.Value = "ABC123";

            var metaResult = new ShopTimeResult<int>(5) {ResultValue = metaData.Id};
            var notFoundResult = new ShopTimeResult<int> {Error = new Error() {CodeNumber = 404}};
            var badResult = new ShopTimeResult<int> {Error = new Error()};

            var metaTask = Task.FromResult<IResult<int>>(metaResult);
            var noutFoundTask = Task.FromResult<IResult<int>>(notFoundResult);
            var badTask = Task.FromResult<IResult<int>>(badResult);

            _collectionServiceMock.Setup(x => x.CreateCustomFieldAsync(6, It.IsAny<CustomField>())).Returns(metaTask);
            _collectionServiceMock.Setup(x => x.CreateCustomFieldAsync(99, It.IsAny<CustomField>())).Returns(noutFoundTask);
            _collectionServiceMock.Setup(x => x.CreateCustomFieldAsync(4, It.IsAny<CustomField>())).Returns(badTask);
            var collectionsController = new CollectionsV1Controller(_collectionServiceMock.Object);
            
            //return result
            var actionResult = collectionsController.CreateCustomFieldAsync(6, new CustomFieldModel()).Result;
            var response = actionResult as CreatedAtRouteNegotiatedContentResult<int>;
            response.Content.Should().Be(metaData.Id);
            response.RouteName.Should().Be("GetCustomFieldById");
            response.RouteValues["collectionId"].Should().Be(6);
            response.RouteValues["metaDataId"].Should().Be(metaData.Id);

            //result not found test
            actionResult = collectionsController.CreateCustomFieldAsync(99, new CustomFieldModel()).Result;
            actionResult.Should().BeOfType<NotFoundResult>();

            //bad request
            actionResult = collectionsController.CreateCustomFieldAsync(4, new CustomFieldModel()).Result;
            actionResult.Should().BeOfType<BadRequestResult>();

            _collectionServiceMock.VerifyAll();
        }


        [TestMethod]
        public void UpdateCustomFieldsTest()
        {
            //arrange
            var getCollection8Result = new ShopTimeResult<Collection>();
            var getCollection8ResultTask = Task.FromResult<IResult<Collection>>(getCollection8Result);
            _collectionServiceMock.Setup(x => x.GetCollectionAsync(8)).Returns(getCollection8ResultTask);

            var getCField8Result = new ShopTimeResult<CustomField>();
            var getCField8ResultTask = Task.FromResult<IResult<CustomField>>(getCField8Result);
            _collectionServiceMock.Setup(x => x.GetCustomFieldAsync(8,8)).Returns(getCField8ResultTask);

            
            var metaResult = new ShopTimeResult();
            var metaTask = Task.FromResult<IResult>(metaResult);
            _collectionServiceMock.Setup(x => x.UpdateCustomFieldAsync(It.IsAny<CustomField>())).Returns(metaTask);

            var notFoundResult = new ShopTimeResult() { Error = new Error() { CodeNumber = 404 } };
            var notFoundTask = Task.FromResult<IResult>(notFoundResult);
            _collectionServiceMock.Setup(x => x.UpdateCustomFieldAsync(It.Is<CustomField>(y => y.Id == 8))).Returns(notFoundTask);

            var badResult = new ShopTimeResult<int> { Error = new Error() };
            var badTask = Task.FromResult<IResult>(badResult);
            _collectionServiceMock.Setup(x => x.UpdateCustomFieldAsync(It.IsAny<CustomField>())).Returns(badTask);

            var collectionsController = new CollectionsV1Controller(_collectionServiceMock.Object);


            //OK result
            var actionResult = collectionsController.UpdaetCustomFieldAsync(8, 8, new CustomFieldModel()).Result;
            actionResult.Should().BeOfType<OkResult>();

            //result not found test
            actionResult = collectionsController.UpdaetCustomFieldAsync(99, 8, new CustomFieldModel()).Result;
            actionResult.Should().BeOfType<NotFoundResult>();

            //bad request
            actionResult = collectionsController.UpdaetCustomFieldAsync(4, 8, new CustomFieldModel()).Result;
            actionResult.Should().BeOfType<BadRequestResult>();

            _collectionServiceMock.VerifyAll();
        }


        [TestMethod]
        public void DeleteCustomFieldTest()
        {
            //arrange
            var metaResult = new ShopTimeResult();
            var metaTask = Task.FromResult<IResult>(metaResult);
            _collectionServiceMock.Setup(x => x.DeleteCustomFieldAsync(8, 3)).Returns(metaTask);

            var notFoundResult = new ShopTimeResult() { Error = new Error() { CodeNumber = 404 } };
            var notFoundTask = Task.FromResult<IResult>(notFoundResult);
            _collectionServiceMock.Setup(x => x.DeleteCustomFieldAsync(99, 5)).Returns(notFoundTask);

            var badResult = new ShopTimeResult<int> { Error = new Error() };
            var badTask = Task.FromResult<IResult>(badResult);
            _collectionServiceMock.Setup(x => x.DeleteCustomFieldAsync(4, 7)).Returns(badTask);

            var collectionsController = new CollectionsV1Controller(_collectionServiceMock.Object);


            //OK result
            var actionResult = collectionsController.DeleteCustomFieldAsync(8, 3).Result;
            actionResult.Should().BeOfType<OkResult>();

            //result not found test
            actionResult = collectionsController.DeleteCustomFieldAsync(99, 5).Result;
            actionResult.Should().BeOfType<NotFoundResult>();

            //bad request
            actionResult = collectionsController.DeleteCustomFieldAsync(4, 7).Result;
            actionResult.Should().BeOfType<BadRequestResult>();

            _collectionServiceMock.VerifyAll();
        }





        [TestMethod]
        public void CreateCollection()
        {
            var createCollectionResult = new ShopTimeResult<int>(13);
            var createTask = Task.FromResult<IResult<int>>(createCollectionResult);
            _collectionServiceMock.Setup(x => x.CreateCollectionAsync(It.IsAny<Collection>())).Returns(createTask);


            var collectionModel = new CollectionModel("DisplayName_Men", "men")
            {
                Image = new ImageModel() { Attachment = "base64", FileName = "abc.jpg"}
            };
           
            var newCollection = Mapper.Map<Collection>(collectionModel);
            newCollection.Id = 13;
            
            var collectionsController = new CollectionsV1Controller(_collectionServiceMock.Object);
            var badResult = collectionsController.CreateCollectionAsync(collectionModel).Result;
            badResult.Should().BeOfType<BadRequestErrorMessageResult>("attachment is invalid.");

            collectionModel.Image.Attachment = new ImageHelper().GetBase64();
            var actionResult = collectionsController.CreateCollectionAsync(collectionModel);
            var response = actionResult.Result as CreatedAtRouteNegotiatedContentResult<int>;
            response.Content.Should().Be(13);
            response.RouteName.Should().Be("GetCollectionById");
            response.RouteValues["collectionId"].Should().Be(13);

            _collectionServiceMock.VerifyAll();
        }

        [TestMethod]
        public void UpdateCollectionTest()
        {
            //arrange
            var collectionResult = new ShopTimeResult();
            var collectionTask = Task.FromResult<IResult>(collectionResult);
            _collectionServiceMock.Setup(x => x.UpdateCollectionAsync(It.Is<Collection>(obj => obj.Id == 8))).Returns(collectionTask);

            var notFoundResult = new ShopTimeResult() { Error = new Error() { CodeNumber = 404 } };
            var notFoundTask = Task.FromResult<IResult>(notFoundResult);
            _collectionServiceMock.Setup(x => x.UpdateCollectionAsync(It.Is<Collection>(obj => obj.Id == 99))).Returns(notFoundTask);

            var badResult = new ShopTimeResult<int> { Error = new Error() };
            var badTask = Task.FromResult<IResult>(badResult);
            _collectionServiceMock.Setup(x => x.UpdateCollectionAsync(It.Is<Collection>(obj => obj.Id == 4))).Returns(badTask);

            var collectionsController = new CollectionsV1Controller(_collectionServiceMock.Object);

            //act
            var collectionModel = new CollectionModel("DisplayName_Men", "men");
            collectionModel.Id = 323;
            var newCollection = Mapper.Map<Collection>(collectionModel);

            //ok result
            var actionResult = collectionsController.UpdateCollectionAsync(8, collectionModel).Result;
            actionResult.Should().BeOfType<OkResult>();

            //result not found test
            actionResult = collectionsController.UpdateCollectionAsync(99, collectionModel).Result;
            actionResult.Should().BeOfType<NotFoundResult>();

            //bad request
            actionResult = collectionsController.UpdateCollectionAsync(4, collectionModel).Result;
            actionResult.Should().BeOfType<BadRequestResult>();
        }


        [TestMethod]
        public void DeleteCollectionTest()
        {
            //arrange
            var get18Result = new ShopTimeResult<Collection>() { ResultValue = new Collection() {Id = 18}};
            var get18Task = Task.FromResult<IResult<Collection>>(get18Result);
            _collectionServiceMock.Setup(x => x.GetCollectionAsync(18)).Returns(get18Task);

            var deleteResult = new ShopTimeResult();
            var deleteTask = Task.FromResult<IResult>(deleteResult);
            _collectionServiceMock.Setup(x => x.DeleteCollectionAsync(It.Is<Collection>(obj => obj.Id == 18))).Returns(deleteTask);


            var getNotFoundResult = new ShopTimeResult<Collection>();
            var getNotFoundTask = Task.FromResult<IResult<Collection>>(getNotFoundResult);
            _collectionServiceMock.Setup(x => x.GetCollectionAsync(99)).Returns(getNotFoundTask);


            var getBadResult = new ShopTimeResult<Collection>() { ResultValue = new Collection() { Id = 4 } };
            var getBadTask = Task.FromResult<IResult<Collection>>(getBadResult);
            _collectionServiceMock.Setup(x => x.GetCollectionAsync(4)).Returns(getBadTask);

            var badResult = new ShopTimeResult<int> { Error = new Error() };
            var badTask = Task.FromResult<IResult>(badResult);
            _collectionServiceMock.Setup(x => x.DeleteCollectionAsync(It.Is<Collection>(obj => obj.Id == 4))).Returns(badTask);

            var collectionsController = new CollectionsV1Controller(_collectionServiceMock.Object);


            //OK result
            var actionResult = collectionsController.DeleteCollectionAsync(18).Result;
            actionResult.Should().BeOfType<OkResult>();

            //result not found test
            actionResult = collectionsController.DeleteCollectionAsync(99).Result;
            actionResult.Should().BeOfType<NotFoundResult>();

            //bad request
            actionResult = collectionsController.DeleteCollectionAsync(4).Result;
            actionResult.Should().BeOfType<BadRequestResult>();

            _collectionServiceMock.VerifyAll();
        }



         private IList<ValidationResult> ValidateModel(object model)
         {
             var validationResults = new List<ValidationResult>();
             var ctx = new ValidationContext(model, null, null);
             Validator.TryValidateObject(model, ctx, validationResults, true);
             return validationResults;
         }
    }
}
