using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApi.Models
{
    public class ProductToProvider
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        [ForeignKey("ProviderID")]
        public Provider Provider { get; set; }
    }
}
