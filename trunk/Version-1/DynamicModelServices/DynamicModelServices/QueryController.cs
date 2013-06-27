using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;

namespace DynamicModelServices
{
    public class QueryController:ApiController
    {

        [HttpGet]
        public HttpResponseMessage Execute(HttpRequestMessage hrm)
        {
            ////http://localhost:51995/api/Query
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage Execute(string id)
        {
            //http://localhost:51995/api/Query
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}