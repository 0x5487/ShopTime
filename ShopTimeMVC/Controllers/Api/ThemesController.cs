using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JasonSoft.ShopTimeMVC.Controllers.Api
{
    public class ThemesController : ApiController
    {
        // GET api/theme
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/theme/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/theme
        public void Post([FromBody]string value)
        {
        }

        // PUT api/theme/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/theme/5
        public void Delete(int id)
        {
        }
    }
}
