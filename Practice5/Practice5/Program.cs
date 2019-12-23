using Practice5.Catalogs;
using Practice5.DataSource;
using System;
using System.Collections.Generic;

namespace Practice5
{
    class Program 
    {
        static void Main(string[] args)
        {
            ProductDataSource productContext = new ProductDataSource();

            var allProducts = productContext.GetAll();
            var specificPoduct = productContext.GetDataByID(new Guid("BF2299D8-8363-41DC-B706-456163BAFCE4"));
        }
    }
}
