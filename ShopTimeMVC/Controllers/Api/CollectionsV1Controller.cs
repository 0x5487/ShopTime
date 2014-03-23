using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Http;
using System.Web.Routing;
using System.Threading.Tasks;
using AutoMapper;
using JasonSoft.ShopTime;
using JasonSoft.ShopTime.Domain;
using JasonSoft.ShopTime.Helper;
using JasonSoft.ShopTime.Service;
using JasonSoft.ShopTimeMVC.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.Owin.FileSystems;

namespace JasonSoft.ShopTimeMVC.Controllers.Api
{
    [RoutePrefix("api/v1/collections")]
    public class CollectionsV1Controller : ApiController
    {
        private ICollectionService _collectionService;
        private IStorageService _storageService;


        #region Collections
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetCollectionsAsync(int? limit = null, int? page = null, CatalogSortBy? sortBy = null)
        {
            IHttpActionResult result = null;

            await _collectionService.GetCollectionsAsync(null, limit, page, sortBy)
                    .Success(collections =>
                    {
                        if (collections == null)
                        {
                            result = StatusCode(HttpStatusCode.NoContent);
                            return;
                        }

                        var collectionMdoels = Mapper.Map<IList<CollectionModel>>(collections);
                        result = Ok(collectionMdoels);
                    })
                    .Error(err =>
                    {
                        switch (err.CodeNumber)
                        {
                            case 404:
                                result = NotFound();
                                break;
                            default:
                                result = BadRequest();
                                break;
                        }

                    });

            return result;
        }


        // Get api/v1/collections/?productID=x&limit=X&page=x
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetCollectionsByProductIdAsync(int productId, int? limit = null, int? page = null, CatalogSortBy? sortBy = null)
        {
            IHttpActionResult result = null;

            await _collectionService.GetCollectionsAsync(productId, limit, page, sortBy)
                .Success(collections =>
                {
                    if (collections == null)
                    {
                        result = StatusCode(HttpStatusCode.NoContent);
                    }

                    var collectionModels = Mapper.Map<IList<CollectionModel>>(collections);
                    result = Ok(collectionModels);
                })
                .Error(err =>
                {
                    switch (err.CodeNumber)
                    {
                        case 404:
                            result = NotFound();
                            break;
                        default:
                            result = BadRequest();
                            break;
                    }
                });

            return result;
        }


        [HttpGet]
        [Route("count")]
        public async Task<IHttpActionResult> GetCollectionCountAsync()
        {
            IHttpActionResult result = null;

            await _collectionService.GetCollectionsCountAsync()
                .Success(count =>
                {
                    result = Ok(count);
                })
                .Error(err =>
                {
                    switch (err.CodeNumber)
                    {
                        case 404:
                            result = NotFound();
                            break;
                        default:
                            result = BadRequest();
                            break;
                    }
                });

            return result;
        }


        [HttpGet]
        [Route("count")]
        public async Task<IHttpActionResult> GetCollectionCountAsync(int productId)
        {
            IHttpActionResult result = null;

            await _collectionService.GetCollectionsCountAsync(productId)
                .Success(count =>
                {
                    result = Ok(count);
                })
                .Error(err =>
                {
                    switch (err.CodeNumber)
                    {
                        case 404:
                            result = NotFound();
                            break;
                        default:
                            result = BadRequest();
                            break;
                    }
                });

            return result;
        }


        [HttpGet]
        [Route("{collectionId}", Name = "GetCollectionById")]
        public async Task<IHttpActionResult> GetCollectionAsync(int collectionId)
        {
            IHttpActionResult result = null;

            await _collectionService.GetCollectionAsync(collectionId)
                .Success(collection => 
                {
                    var collectionModel = Mapper.Map<CollectionModel>(collection);
                    result = Ok(collectionModel);
                })
                .Error( err => 
                {
                    switch (err.CodeNumber)
                    {
                        case 404:
                            result = NotFound();
                            break;
                        default:
                            result = BadRequest();
                            break;
                    }
                });

            return result;


            //var result = new CollectionModel();

            //var metaData = new List<MetaDataModel>();
            //metaData.Add(new MetaDataModel() { Id = 34 });
            //metaData.Add(new MetaDataModel() { Id = 35 });
            //result.MetaData = metaData;

            //return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateCollectionAsync(CollectionModel source)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IHttpActionResult result = null;

            var collection = Mapper.Map<Collection>(source);

            
            if (source.Image != null && source.Image.Attachment.IsNullOrWhiteSpace() == false && source.Image.Attachment.IsBase64String() == false) 
            {
                return BadRequest("image attachment is not valid.");
            }

            _collectionService.CreateCollectionAsync(collection)
                .Success(collectionId =>
                {
                    result = CreatedAtRoute("GetCollectionById", new { collectionId = collectionId }, collectionId);
                })
                .Error(err => result = BadRequest());


            //save image file
            if (source.Image != null && source.Image.Attachment.IsNullOrWhiteSpace() == false)
            {
                string fileName = Guid.NewGuid().ToString("N");
                IFileInfo imageFile = new VirutalFile(fileName, source.Image.Attachment);
                _storageService.SaveFile("/collection/{0}/", imageFile);
            }
            


            

            return result;
        }

        [Route("{collectionId}/")]
        public async Task<IHttpActionResult> UpdateCollectionAsync(int collectionId, CollectionModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            IHttpActionResult result = null;
            value.Id = collectionId;

            var collection = Mapper.Map<Collection>(value);

            await _collectionService.UpdateCollectionAsync(collection)
                .Success(() => result = Ok())
                .Error(err =>
                {
                    switch (err.CodeNumber)
                    {
                        case 404:
                            result = NotFound();
                            break;
                        default:
                            result = BadRequest();
                            break;
                    }
                });

            return result;
        }



        [HttpDelete]
        [Route("{collectionId}/")]
        public async Task<IHttpActionResult> DeleteCollectionAsync(int collectionId)
        {
            IHttpActionResult result = null;

            var getResult = await _collectionService.GetCollectionAsync(collectionId);

            if (getResult.Error != null)
            {
                switch (getResult.Error.CodeNumber)
                {
                    default:
                        return BadRequest();
                }
            }


            if (getResult.ResultValue == null)
            {
                return NotFound();
            }

            await _collectionService.DeleteCollectionAsync(getResult.ResultValue)
                .Success(() => result = Ok())
                .Error(err =>
                {
                    switch (err.CodeNumber)
                    {
                        default:
                            result = BadRequest();
                            break;
                    }
                });

            return result;
        }

        #endregion


        #region CustomFields
        [HttpGet]
        [Route("{collectionId}/customfields")]
        public async Task<IHttpActionResult> GetCustomFieldsAsync(int collectionId)
        {
            IHttpActionResult result = null;

            await _collectionService.GetCustomFieldsAsync(collectionId)
                .Success(metaData =>
                {
                    if (metaData == null)
                    {
                        result = StatusCode(HttpStatusCode.NoContent);
                        return;
                    }

                    var metaDataModels = Mapper.Map<IList<CustomFieldModel>>(metaData);
                    result = Ok(metaDataModels);
                })
                .Error(err =>
                {
                    switch (err.CodeNumber)
                    {
                        case 404:
                            result = NotFound();
                            break;
                        default:
                            result = BadRequest();
                            break;
                    }
                });

            return result;
        }


        [HttpGet]
        [Route("{collectionId}/customfields")]
        public async Task<IHttpActionResult> GetCustomFieldsAsync(int collectionId, string key)
        {
            IHttpActionResult result = null;

            return result;
        }




        [Route("{collectionId}/customfields/count")]
        public async Task<IHttpActionResult> GetCustomFieldsCountAsync(int collectionId)
        {
            IHttpActionResult result = null;

            await _collectionService.GetCustomFieldsCountAsync(collectionId)
                .Success(count => result = Ok(count))
                .Error(err =>
                {
                    switch (err.CodeNumber)
                    {
                        case 404:
                            result = NotFound();
                            break;
                        default:
                            result = BadRequest();
                            break;
                    }
                });

            return result;
        }

        [Route("{collectionId}/customfields/{customfieldId}", Name = "GetCustomFieldById")]
        public async Task<IHttpActionResult> GetCustomFieldAsync(int collectionId, int customfieldId)
        {
            IHttpActionResult result = null;

            await _collectionService.GetCustomFieldAsync(collectionId, customfieldId)
                .Success(metaData =>
                {
                    if (metaData == null)
                    {
                        result = StatusCode(HttpStatusCode.NoContent);
                        return;
                    }

                    var metaDataModel = Mapper.Map<CustomFieldModel>(metaData);
                    result = Ok(metaDataModel);
                })
                .Error(err =>
                {
                    switch (err.CodeNumber)
                    {
                        case 404:
                            result = NotFound();
                            break;
                        default:
                            result = BadRequest();
                            break;
                    }
                });

            return result;
        }



        [HttpPost]
        [Route("{collectionId}/customfields")]
        public async Task<IHttpActionResult> CreateCustomFieldAsync(int collectionId, CustomFieldModel source)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IHttpActionResult result = null;

            var metaData = Mapper.Map<CustomField>(source);
            await _collectionService.CreateCustomFieldAsync(collectionId, metaData)
                .Success(metaDataId => result = CreatedAtRoute("GetCustomFieldById", new { collectionId = collectionId, metaDataId = metaDataId }, metaDataId))
                .Error(err =>
                {
                    switch (err.CodeNumber)
                    {
                        case 404:
                            result = NotFound();
                            break;
                        default:
                            result = BadRequest();
                            break;
                    }
                });

            return result;
        }

        [HttpPut]
        [Route("{collectionId}/customfields/{customfieldId}")]
        public async Task<IHttpActionResult> UpdaetCustomFieldAsync(int collectionId, int customfieldId, CustomFieldModel source)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IHttpActionResult result = null;

            source.Id = customfieldId;

            var getCollectionResult = await _collectionService.GetCollectionAsync(collectionId);

            if (getCollectionResult.Error != null)
            {
                switch (getCollectionResult.Error.CodeNumber)
                {
                    default:
                        result = BadRequest();
                        break;
                }

                return result;
            }

            if (getCollectionResult.ResultValue == null)
            {
                result = NotFound();
                return result;
            }

            var metaData = Mapper.Map<CustomField>(source);
            await _collectionService.UpdateCustomFieldAsync(metaData)
                .Success( ()=> result = Ok())
                .Error(err =>
                {
                    switch (err.CodeNumber)
                    {
                        case 404:
                            result = NotFound();
                            break;
                        default:
                            result = BadRequest();
                            break;
                    }
                });

            return result;
        }

        [HttpDelete]
        [Route("{collectionId}/customfields/{customfieldId}")]
        public async Task<IHttpActionResult> DeleteCustomFieldAsync(int collectionId, int customfieldId)
        {
            IHttpActionResult result = null;

            await _collectionService.DeleteCustomFieldAsync(collectionId, customfieldId)
                .Success(() => result = Ok())
                .Error(err =>
                {
                    switch (err.CodeNumber)
                    {
                        case 404:
                            result = NotFound();
                            break;
                        default:
                            result = BadRequest();
                            break;
                    }
                });

            return result;
        }
        #endregion


        public CollectionsV1Controller(ICollectionService collectionService)
        {
            _collectionService = collectionService;
            //_storageService = storageService;
        }



    }
}
