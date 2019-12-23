using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebApi.Models
{
    public class Provider
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductToProvider> ProductsProviders { get; set; }

    }
}
