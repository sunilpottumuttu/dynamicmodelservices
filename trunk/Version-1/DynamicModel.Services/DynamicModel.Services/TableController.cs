using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using DynamicModelLib;
using System.Text;


namespace DynamicModel.Services
{
    public class TableController:ApiController
    {

        [HttpPut]
        public HttpResponseMessage Insert(HttpRequestMessage hrm)
        {
            return new HttpResponseMessage();   
        }

        [HttpPost]  
        public HttpResponseMessage Update(HttpRequestMessage hrm)
        {

            return new HttpResponseMessage();
        }

        [HttpDelete]
        public HttpStatusCode Delete(HttpRequestMessage hrm)
        {
            return new HttpStatusCode();

        }

        [HttpGet]
        public HttpResponseMessage Select(HttpRequestMessage hrm)
        {
            return new HttpResponseMessage();
        }

        [HttpGet]
        public HttpResponseMessage Columns()
        {
            return new HttpResponseMessage();
        }


        [HttpGet]
        public HttpResponseMessage Column(string columnName)
        {
            return new HttpResponseMessage();
        }

    }
}