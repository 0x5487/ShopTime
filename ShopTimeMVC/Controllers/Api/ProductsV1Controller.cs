using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JasonSoft.ShopTime.Domain;
using JasonSoft.ShopTime.Service;
using JasonSoft.ShopTimeMVC.Models;

namespace JasonSoft.ShopTimeMVC.Controllers.Api
{
    [RoutePrefix("api/v1/products")]
    public class ProductsV1Controller : ApiController
    {

        private IProductService _productService;


        #region Products

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetProducts(int? limit = null, int? page = null, CatalogSortBy? sortBy = null)
        {
            IHttpActionResult result = null;

            return result;
        }

        // Get api/v1/products/?collectionid=x&limit=X&page=x
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetProductsByCollectionId(int collectionId, int? limit = null, int? page = null, CatalogSortBy? sortBy = null)
        {
            IHttpActionResult result = null;

            return result;
        }


        [HttpGet]
        [Route("count")]
        public IHttpActionResult Count()
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpGet]
        [Route("count")]
        public IHttpActionResult Count(int? collectionId = null)
        {
            IHttpActionResult result = null;

            return result;
        }

        

        [HttpGet]
        [Route("{id}", Name = "GetProductById")]
        public IHttpActionResult GetProduct(int id)
        {
            IHttpActionResult result = null;

            return result;
        }



        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateProduct(Product source)
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateProduct(int id, Product source)
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteProduct(int id)
        {
            IHttpActionResult result = null;

            return result;
        }

        #endregion


        #region Variations
        [HttpGet]
        [Route("{id}/variations")]
        public IHttpActionResult GetVariations(int id)
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpGet]
        [Route("{id}/variations/count")]
        public IHttpActionResult GetVariationsCount(int id)
        {
            IHttpActionResult result = null;

            return result;
        }


        [HttpGet]
        [Route("{id}/variations/{variationId}", Name = "GetVariationById")]
        public IHttpActionResult GetVariation(int id, int variationId)
        {
            IHttpActionResult result = null;

            return result;
        }


        [HttpPost]
        [Route("{id}/variations")]
        public IHttpActionResult CreateVariation(VariationModel source)
        {
            IHttpActionResult result = null;

            return result;
        }


        [HttpPut]
        [Route("{id}/variations/{variationId}")]
        public IHttpActionResult UpdateVariation(int id, int variationId, VariationModel source)
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpDelete]
        [Route("{id}/variations/{variationId}")]
        public IHttpActionResult DeleteVariation(int id, int variationId)
        {
            IHttpActionResult result = null;

            return result;
        }



        #endregion


        #region Images

        [HttpGet]
        [Route("{id}/images")]
        public IHttpActionResult GetImages(int id)
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpGet]
        [Route("{id}/images/count")]
        public IHttpActionResult GetImagesCount(int id)
        {
            IHttpActionResult result = null;

            return result;
        }


        [HttpGet]
        [Route("{id}/images/{imageId}", Name = "GetImageById")]
        public IHttpActionResult GetImage(int id, int imageId)
        {
            IHttpActionResult result = null;

            return result;
        }


        [HttpPost]
        [Route("{id}/images")]
        public IHttpActionResult CreateImage(ImageModel source)
        {
            IHttpActionResult result = null;

            return result;
        }


        [HttpPut]
        [Route("{id}/images/{imageId}")]
        public IHttpActionResult UpdateImage(int id, int imageId, ImageModel source)
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpDelete]
        [Route("{id}/images/{imageId}")]
        public IHttpActionResult DeleteImage(int id, int imageId, ImageModel source)
        {
            IHttpActionResult result = null;

            return result;
        }

        #endregion


        #region CustomFields

        [HttpGet]
        [Route("{id}/customfields")]
        public IHttpActionResult GetCustomFields(int id)
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpGet]
        [Route("{id}/customfields/count")]
        public IHttpActionResult GetCustomFieldsCount(int id)
        {
            IHttpActionResult result = null;

            return result;
        }


        [HttpGet]
        [Route("{id}/customfields/{customfieldId}", Name = "GetCustomFieldById")]
        public IHttpActionResult GetCustomField(int id, int customfieldId)
        {
            IHttpActionResult result = null;

            return result;
        }


        [HttpPost]
        [Route("{id}/customfields")]
        public IHttpActionResult CreateCustomField(CustomFieldModel source)
        {
            IHttpActionResult result = null;

            return result;
        }


        [HttpPut]
        [Route("{id}/customfields/{customfieldId}")]
        public IHttpActionResult UpdateCustomField(int id, int customfieldId, CustomFieldModel source)
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpDelete]
        [Route("{id}/customfields/{customfieldId}")]
        public IHttpActionResult DeleteCustomField(int id, int customfieldId, CustomFieldModel source)
        {
            IHttpActionResult result = null;

            return result;
        }

        #endregion



        public ProductsV1Controller(IProductService productService)
        {
            _productService = productService;
        }
    }
}
