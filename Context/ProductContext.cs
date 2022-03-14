using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Price = 2000, Name = "Redmi", Description = "Cost Efficient", Image_Name = "1.jpg", Rating = 5 },
                new Product() { Id = 2, Price = 3000, Name = "Iphone", Description = "Camera Clarity", Image_Name = "2.jpg", Rating = 5 }
                );
        }
    }
}
