using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace DynamicModelLib
{
    public static class DB
    {
        public static DynamicModel Current
        {
            get
            {
                if (ConfigurationManager.ConnectionStrings.Count > 1)
                {
                    //return new DynamicModel(ConfigurationManager.ConnectionStrings[1].Name);
                    return new DynamicModel(ConfigurationManager.ConnectionStrings["DynamicModel"].Name);
                }
                throw new InvalidOperationException("Need a connection string name - can't determine what it is");
            }
        }
    }
}