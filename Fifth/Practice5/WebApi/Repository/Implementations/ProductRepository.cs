using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;
using WebApi.Repository.Interfaces;

namespace WebApi.Repository.Implementations
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> Get()
        {
            using (var context = new ProductionDBContext())
            { 
                var a = context.Products
                    .Include(p => p.ProductCategory)
                    .Include(p => p.ProductsProviders)
                    .ToList();
                return context.Products
                    .Include(p=> p.ProductCategory)
                    .Include(p=> p.ProductsProviders)
                    .ToList();
            }
        }
    }
}
