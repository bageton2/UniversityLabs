using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Practice5EF.Models
{
    public class Provider
    {
        [Key]
        public Guid ProviderGID { get; set; }

        public string Name { get; set; }

        public ICollection<ProductToProvider> ProductsProviders { get; set; }

        public Provider()
        {
            this.ProviderGID = Guid.NewGuid();
        }
    }
}
