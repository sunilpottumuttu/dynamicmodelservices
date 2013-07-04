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
    public static class DbCommandExtensions
    {
        /// <summary>
        /// Extension method for adding in a bunch of parameters
        /// </summary>
        public static void AddParams(this DbCommand cmd, params object[] args)
        {
            foreach (var item in args)
            {
                AddParam(cmd, item);
            }
        }
        /// <summary>
        /// Extension for adding single parameter
        /// </summary>
        public static void AddParam(this DbCommand cmd, object item)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = string.Format("@{0}", cmd.Parameters.Count);
            if (item == null)
            {
                p.Value = DBNull.Value;
            }
            else
            {
                if (item.GetType() == typeof(Guid))
                {
                    p.Value = item.ToString();
                    p.DbType = DbType.String;
                    p.Size = 4000;
                }
                else if (item.GetType() == typeof(ExpandoObject))
                {
                    var d = (IDictionary<string, object>)item;
                    p.Value = d.Values.FirstOrDefault();
                }
                else
                {
                    p.Value = item;
                }
                if (item.GetType() == typeof(string))
                    p.Size = ((string)item).Length > 4000 ? -1 : 4000;
            }
            cmd.Parameters.Add(p);
        }
    }
}