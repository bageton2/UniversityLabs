using Microsoft.EntityFrameworkCore;
using Practice5EF.Models;

namespace Practice5EF
{
    public class ProductionDBContext : DbContext
    { 
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductToProvider> ProductsToProviders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = EPAMCodeFirst; Integrated Security = True;");
        }
    }
}
