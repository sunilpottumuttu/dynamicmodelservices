using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using Dynamic.Data;

namespace DynamicModel.Tests
{
    class Program
    {
        static void Main(string[] args)
        {

            //test-1 get current database provider name
            Console.WriteLine(DynamicDBContext.Current.ProviderName);

            //test-2 get current database name
            

            //test-3 get schema for table
            

            //test -4 get default value for column
            IEnumerable<dynamic> data = DynamicDBContext.Current.Execute("SELECT * FROM Categories;select * from region");

            foreach (dynamic item in data)
            {
                if (item is ExpandoObject)
                {
                    var i = item as ExpandoObject;
                    if (i.HasProperty("CategoryID"))
                    { Console.WriteLine(item.CategoryID.ToString()); }
                }
            }

            


            //test-5 get primarykey for table



            
            //test-6 execute query and get dynamic models



            //test-7  get table as dynamic model by table


            //test-8 insert a new into table by using dynamic model


            //test-9 update record in a tble by using dynamic model



            //test-10 delete record from a table

            Console.ReadLine();

        }
    }
}
