using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Dynamic.Data;
using System.Text;

namespace DynamicModel.Services
{
    public class CurrentController:ApiController
    {

        /// <summary>
        /// Ex: http://localhost:3333/DB/Current/ProviderName
        /// </summary>
        /// <param name="HttpRequestMessage"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ProviderName()
        {
            var response = new HttpResponseMessage();
            try
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new StringContent(DynamicDBContext.Current.ProviderName.ToString());
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Content = new StringContent(ex.Message.ToString(), Encoding.Default);
                throw new HttpResponseException(response);
            }
            return response;

        }

         /// <summary>
         /// Ex: http://localhost:3333/DB/Current/Query
         /// </summary>
         /// <param name="HttpRequestMessage"></param>
         /// <returns></returns>
         [HttpGet]
         public HttpResponseMessage Query(HttpRequestMessage hrm)
         {

             try
             {
                 string sql = hrm.Content.ReadAsStringAsync().Result;
                 IEnumerable<dynamic> data = DynamicDBContext.Current.Query(sql);

                 string jsonResults = JsonConvert.SerializeObject(data);

                 //var response = this.Request.CreateResponse(HttpStatusCode.OK);
                 var response = new HttpResponseMessage(HttpStatusCode.OK);
                 response.Content = new StringContent(jsonResults);

                 return response;
             }
             catch (Exception ex)
             {
                 var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                 response.Content = new StringContent(ex.Message.ToString(), Encoding.Default);
                 throw new HttpResponseException(response);
             }
         }


         [HttpGet]
         public HttpResponseMessage Scalar(HttpRequestMessage hrm)
         {
             
             try
             {
                 string sql = hrm.Content.ReadAsStringAsync().Result;
                 object data = DynamicDBContext.Current.Scalar(sql);

                 string jsonResults = JsonConvert.SerializeObject(data);

                 var response = new HttpResponseMessage(HttpStatusCode.OK);
                 response.Content = new StringContent(jsonResults);

                 return response;
             }
             catch (Exception ex)
             {
                 var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                 response.Content = new StringContent(ex.Message.ToString(), Encoding.Default);
                 throw new HttpResponseException(response);
             }
         }


         /// <summary>
         /// Ex: http://localhost:3333/DB/Current/Query
         /// </summary>
         /// <param name="HttpRequestMessage"></param>
         /// <returns></returns>
         [HttpGet]
         public HttpResponseMessage All(HttpRequestMessage hrm)
         {

             try
             {
                 string sql = hrm.Content.ReadAsStringAsync().Result;
                 DynamicDBContext.Current.TableName = "Categories";
                 IEnumerable<dynamic> data = DynamicDBContext.Current.All(where: "", orderBy: "", limit: 0, columns: "*");

                 string jsonResults = JsonConvert.SerializeObject(data);

                 //var response = this.Request.CreateResponse(HttpStatusCode.OK);
                 var response = new HttpResponseMessage(HttpStatusCode.OK);
                 response.Content = new StringContent(jsonResults);

                 return response;
             }
             catch (Exception ex)
             {
                 var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                 response.Content = new StringContent(ex.Message.ToString(), Encoding.Default);
                 throw new HttpResponseException(response);
             }
         }





    }
}