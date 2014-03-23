using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JasonSoft.ShopTimeMVC.Models;

namespace JasonSoft.ShopTimeMVC.Controllers
{
    [RoutePrefix("api/v1/optionlists")]
    public class OptionListV1Controller : ApiController
    {
        #region OptionList
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetOptionLists(int? limit = null, int? page = null)
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
        [Route("{id}", Name = "GetOptionListById")]
        public IHttpActionResult GetOptionList(int id)
        {
            IHttpActionResult result = null;
            return result;

        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateOptionList(OptionListModel source)
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateOptionList(int id, OptionListModel source)
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteOptionList(int id)
        {
            IHttpActionResult result = null;

            return result;
        }
        #endregion


        #region ListItem

        [HttpGet]
        [Route("{id}/items")]
        public IHttpActionResult GetListItems(int id)
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpGet]
        [Route("{id}/items/{itemId}")]
        public IHttpActionResult GetValue(int id, int itemId)
        {
            IHttpActionResult result = null;

            return result;
        }


        [HttpPost]
        [Route("{id}/items")]
        public IHttpActionResult CreateValue(int id, OptionValueModel source)
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpPut]
        [Route("{id}/items/{itemId}")]
        public IHttpActionResult UpdateValue(int id, int itemId, OptionValueModel source)
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpDelete]
        [Route("{id}/items/{itemId}")]
        public IHttpActionResult DeleteValue(int id, int itemId)
        {
            IHttpActionResult result = null;

            return result;
        }



        #endregion
    }
}
