using System;
using System.Collections.Generic;
using System.Text;

namespace Practice5.Catalogs
{
    class Product
    {
        public Guid Id { get; set;}
        public string Name { get; set; }
        public Guid ProductCategoryID { get; set; }
    }
}
