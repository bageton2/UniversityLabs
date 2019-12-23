using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice5EF.Models
{
    public class Product
    {
        [Key]
        public Guid ProductGID { get; set; }

        public string Name { get; set; }

        public double Cost { get; set; }
        
        public ICollection<ProductToProvider> ProductsProviders { get; set; }

        [ForeignKey("ProductCategoryGID")]
        public ProductCategory ProductCategory { get; set; }

        public Product()
        {
            ProductGID = Guid.NewGuid();
        }
    }
}
