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
using System.ComponentModel;
using System.Collections;

namespace Dynamic.Data
{

  
    public class DynamicModel : DynamicObject
    {

        private DbProviderFactory __dbProviderFactory;
        
        private string __connectionString;

        private IEnumerable<dynamic> __schema;

        [DefaultValue("System.Data.SqlClient")]
        public string ProviderName 
        { 
            get; 
            private set; 
        }

        public string DatabaseName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public dynamic Prototype()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dynamic> Schema()
        {
            throw new NotImplementedException();
        }

        public DynamicModel(string connectionStringName)
        {
            if (!string.IsNullOrWhiteSpace(ConfigurationManager.ConnectionStrings[connectionStringName].ProviderName))
                this.ProviderName = ConfigurationManager.ConnectionStrings[connectionStringName].ProviderName;

            __dbProviderFactory = DbProviderFactories.GetFactory(this.ProviderName);
            __connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }

  
        
        public virtual IEnumerable<dynamic> Execute(string sql, params object[] args)
        {
            //using (var conn = OpenConnection())
            //{
            //    var rdr = CreateCommand(sql, conn, args).ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        yield return rdr.RecordToExpando(); ;
            //    }
            //}
            
            using (var conn = this.OpenConnection())
            {
                var reader = this.CreateCommand(sql, conn, args).ExecuteReader();
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return reader.DataRowToExpando();
                    }
                    reader.NextResult();
                }
            }
           
        }
        //http://stackoverflow.com/questions/10252531/returning-a-sqldatareader

        public virtual IEnumerable<IDataRecord> ExecuteReader(string sql, params object[] args)
        {
            using (var conn = this.OpenConnection())
            {
                var reader = this.CreateCommand(sql, conn, args).ExecuteReader();
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return reader;
                    }
                    reader.NextResult();
                }
            }
        }

        


        //public virtual IList<dynamic> ExectueMultipleResults(string sql, params object[] args)
        //{
        //    List<dynamic> 
        //    using (var conn = this.OpenConnection())
        //    {
        //        using (IDataReader reader = this.CreateCommand(sql, conn, args).ExecuteReader())
        //        {
        //            // Process all result sets
        //            do
        //            {
        //                // Process all elements in the current result set
        //                while (reader.Read())
        //                {
        //                    ArrayList row = new ArrayList();
        //                    for (int j = 0; j < reader.FieldCount; ++j)
        //                    {
        //                        object rowValue = reader.GetValue(j);
        //                        row.Add(rowValue);
        //                    }
        //                    // TODO: Do something with 'row'
        //                }
        //            } while (reader.NextResult());
        //        }
        //    }
        //}


     
        public virtual object Scalar(string sql, params object[] args)
        {
            object result = null;
            using (var conn = this.OpenConnection())
            {
                result = this.CreateCommand(sql, conn, args).ExecuteScalar();
            }
            return result;
        }

        #region Helper Methods
        private DbConnection OpenConnection()
        {
            var result = __dbProviderFactory.CreateConnection();
            result.ConnectionString = __connectionString;
            result.Open();
            return result;
        }

        private DbCommand CreateCommand(string sql, DbConnection conn, params object[] args)
        {
            var dbCommand = this.__dbProviderFactory.CreateCommand();
            dbCommand.Connection = conn;
            dbCommand.CommandText = sql;
            if (args.Length > 0)
            { dbCommand.AddParameters(args); }
            return dbCommand;
        } 
        #endregion
        
    }
}