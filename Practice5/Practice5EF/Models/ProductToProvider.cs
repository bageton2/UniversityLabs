using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Practice5EF.Models
{
    public class ProductToProvider
    {
        [Key]
        public Guid ProductToProviderGID { get; set; }

        [ForeignKey("ProductGID")]
        public Product Product { get; set; }

        [ForeignKey("ProviderGID")]
        public Provider Provider { get; set; }
    }
}
