using Ecommerce.Api.ProductCategory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.ProductCategory.Context
{
    public class ProductsCategoryDBContext : DbContext
    {
        public ProductsCategoryDBContext(DbContextOptions<ProductsCategoryDBContext> options) : base(options){ }

        public DbSet<ProductsCategory> ProductsCategory { get; set; }
    }
}
