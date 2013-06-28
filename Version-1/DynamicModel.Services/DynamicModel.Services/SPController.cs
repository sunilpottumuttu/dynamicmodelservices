using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using DynamicModel.Lib;
using System.Text;


namespace DynamicModel.Services
{
    public class SPController
    {

        [HttpPut]
        public HttpResponseMessage Create(HttpRequestMessage hrm)
        {
            return new HttpResponseMessage();
        }


        [HttpPost]
        public HttpResponseMessage Modify(HttpRequestMessage hrm)
        {

            return new HttpResponseMessage();
        }

        [HttpDelete]
        public HttpStatusCode Delete(HttpRequestMessage hrm)
        {
            return new HttpStatusCode();

        }

        [HttpGet]
        public HttpResponseMessage Execute(HttpRequestMessage hrm)
        {
            return new HttpResponseMessage();
        }


    }
}