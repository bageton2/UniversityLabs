using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApi.Models
{
    public class ProductCategory
    {
        [Key]
        public int id { get; set; }

        public string Caption { get; set; }

        ICollection<Product> Products { get; set; }
    }
}
