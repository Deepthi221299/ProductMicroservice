using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Models
{
    [ExcludeFromCodeCoverage]
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                 new Product { ProductId = 1, ProductName = "Redmi", Description = "Budjet Friendly", ImageName = "product1.jpg", Price = 5999, Rating = 5 },
            new Product { ProductId = 2, ProductName = "Iphone", Description = "Camera Clarity", ImageName = "product2.jpg", Price = 3500, Rating = 3 },
            new Product { ProductId = 3, ProductName = "Iqoo7", Description = "Good Proccessor", ImageName = "product3.jpg", Price = 6999, Rating = 4 },
            new Product { ProductId = 4, ProductName = "samsung", Description = "Nice Product", ImageName = "product4.jpg", Price = 4599, Rating = 2 },
            new Product { ProductId = 5, ProductName = "Nokia", Description = "Long Life Time", ImageName = "product5.jpg", Price = 2900, Rating = 5 }
                );
        }
    }
}
