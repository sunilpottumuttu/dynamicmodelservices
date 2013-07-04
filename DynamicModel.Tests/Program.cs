using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            


            Console.ReadLine();

        }
    }
}
