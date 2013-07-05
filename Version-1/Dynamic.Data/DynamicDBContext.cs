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

namespace Dynamic.Data
{
    public static class DynamicDBContext
    {

        private static string __connectionString = ConfigurationManager.ConnectionStrings["DynamicModel"].Name;
        public static string  ConnectionString 
        {
            get { return __connectionString; }
            set { __connectionString = value; }
        }

        public static DynamicModel Current
        {
            get
            {
                try
                {
                    return new DynamicModel(ConnectionString);
                }
                catch
                {
                    throw new InvalidOperationException("Please provide a connection string with name - DynamicModel");
                }
            }
            
        }
    }
}