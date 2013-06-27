using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Dynamic;

namespace DynamicModelServices
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////IEnumerable<dynamic> data = DB.Current.Query("SELECT categoryid FROM Categories;select employeeid from  Employees");
            IEnumerable<dynamic> data = DB.Current.Query("select * from Person.Address");

            
            ////foreach (dynamic item in data)
            ////{
            ////    ExpandoObject s = item;
            ////    dynamic i = s.categoyid;
            ////}
            ////dynamic  c = new ExpandoObject();
            ////c.CategoryID = 9;
            ////c.CategoryName = "Dummy";
            ////c.Description = "Dummy Description";
            ////c.Picture = null;

            ////DB.Current.Insert(c);




            string json = JsonConvert.SerializeObject(data);
            Response.Write(json);
        }
    }
}