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

namespace DynamicModelServices
{
    public static class IDataReaderExtensions
    {
        /// <summary>
        /// Turns an IDataReader to a Dynamic list of things
        /// </summary>
        public static List<dynamic> ToExpandoList(this IDataReader rdr)
        {
            var result = new List<dynamic>();
            while (rdr.Read())
            {
                result.Add(rdr.RecordToExpando());
            }
            return result;
        }

        public static dynamic RecordToExpando(this IDataReader rdr)
        {
            dynamic e = new ExpandoObject();
            var d = e as IDictionary<string, object>;
            for (int i = 0; i < rdr.FieldCount; i++)
                d.Add(rdr.GetName(i), DBNull.Value.Equals(rdr[i]) ? null : rdr[i]);
            return e;
        }
    }
}