using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JasonSoft.ShopTimeMVC.Models;

namespace JasonSoft.ShopTimeMVC.Controllers
{
    [RoutePrefix("api/v1/options")]
    public class OptionsV1Controller : ApiController
    {

        #region Option

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetOptions()
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpGet]
        [Route("count")]
        public IHttpActionResult GetOptionsCount()
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetOptions(int id)
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateOption()
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateOption(int id)
        {
            IHttpActionResult result = null;

            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteOption(int id)
        {
            IHttpActionResult result = null;

            return result;
        }


        #endregion

        #region OptionValues

        [HttpGet]
        [Route("{optionId}/values")]
        public IHttpActionResult GetValues(int optionId)
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpGet]
        [Route("{optionId}/values/{valueId}")]
        public IHttpActionResult GetValue(int optionId, int valueId)
        {
            IHttpActionResult result = null;

            return result;
        }


        [HttpPost]
        [Route("{optionId}/values")]
        public IHttpActionResult CreateValue(int optionId, OptionValueModel source)
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpPut]
        [Route("{optionId}/values/{valueId}")]
        public IHttpActionResult UpdateValue(int optionId, int valueId, OptionValueModel source)
        {
            IHttpActionResult result = null;

            return result;
        }

        [HttpDelete]
        [Route("{optionId}/values/{valueId}")]
        public IHttpActionResult DeleteValue(int optionId, int valueId)
        {
            IHttpActionResult result = null;

            return result;
        }


        #endregion

    }
}
