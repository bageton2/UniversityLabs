using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }

        public double Cost { get; set; }

        public ICollection<ProductToProvider> ProductsProviders { get; set; }

        [ForeignKey("ProductCategoryID")]
        public ProductCategory ProductCategory { get; set; }
    }
    public class ProductDTO
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string ProductCategory { get; set; }
        public ICollection<ProductToProvider> ProductToProvider { get; set; }
    }
}
