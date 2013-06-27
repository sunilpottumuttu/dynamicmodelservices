using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;

namespace HttpDataServices
{
    public class SalesOrderController:ApiController
    {

        [HttpGet]
        public HttpResponseMessage RetrieveSalesOrder(HttpRequestMessage hrm)
        {
            //http://localhost:51995/api/SalesOrder
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage RetrieveSalesOrder(string id)
        {
            //http://localhost:51995/api/SalesOrder
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}