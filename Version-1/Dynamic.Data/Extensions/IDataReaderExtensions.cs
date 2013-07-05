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
    public static class IDataReaderExtensions
    {
      
        public static List<dynamic> ToExpandoList(this IDataReader reader)
        {
            var result = new List<dynamic>();
            while (reader.Read())
            {
                result.Add(reader.DataRowToExpando());
            }
            return result;
        }

        public static dynamic DataRowToExpando(this IDataReader reader)
        {
            
            dynamic eo = new ExpandoObject();
            var dict = eo as IDictionary<string, object>;
            for (int i = 0; i < reader.FieldCount; i++)
            { 
                dict.Add(reader.GetName(i), DBNull.Value.Equals(reader[i]) ? null : reader[i]); 
            }
            return eo;
        }
    }
}