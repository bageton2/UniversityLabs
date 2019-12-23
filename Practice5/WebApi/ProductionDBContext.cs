using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi
{
    public class ProductionDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductToProvider> ProductsToProviders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = EPAMCodeFirst1; Integrated Security = True;");
        }
    }
}
