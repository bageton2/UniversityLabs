using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Practice5EF.Models
{
    public class ProductCategory
    {
        [Key]
        public Guid ProductCategoryGID { get; set; }

        public string Caption { get; set; }

        ICollection<Product> Products { get; set; }

        public ProductCategory()
        {
            this.ProductCategoryGID = Guid.NewGuid();
        }
    }
}
