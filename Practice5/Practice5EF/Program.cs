using Practice5EF.Models;
using System;
using System.Linq;

namespace Practice5EF
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductCategory productCategory1 = new ProductCategory()
            {
                Caption = "Watter"
            };

            Provider provider1 = new Provider()
            {
                Name = "Rozetka"
            };

            Product product1 = new Product()
            {
                Name = "Bonaqua",
                Cost = 2.4,
                ProductCategory = productCategory1,
            };

            using (var context = new ProductionDBContext())
            {
                context.Products.Add(product1);

                context.ProductsToProviders.Add(new ProductToProvider()
                {
                    Provider = provider1,
                    Product = product1
                });

                context.SaveChanges();
            }

            //1

            Guid productCategoryGID = new Guid("F0B52948-BFC5-4CD4-BE41-C0114211DA1A");
            using (var context = new ProductionDBContext())
            {
                var productsOfCategory = context.Products
                                          .Where(product => product.ProductCategory.ProductCategoryGID == productCategoryGID).ToList();
            }

            //2
            using (var context = new ProductionDBContext())
            {
                var providersOfCategory = context.Providers
                                          .Where(provider => provider.ProductsProviders
                                          .Any(productToProvider => productToProvider.Product.ProductCategory.ProductCategoryGID == productCategoryGID
                                          )).ToList();
            }

            //3
            Guid providerGID = new Guid("45BE6297-93AA-4582-8F88-E5D206150D61");
            using (var context = new ProductionDBContext())
            {
                var products = context.Products
                               .Where(product => product.ProductsProviders
                               .Any(productToProvider => productToProvider.Provider.ProviderGID == providerGID)).ToList();
            }

            //4
            using (var context = new ProductionDBContext())
            {
                var products = context.Products.Where(product => product.Cost < 10);
            }
        }
    }
}