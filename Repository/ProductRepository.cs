using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly ProductContext _db;
        public ProductRepository(ProductContext db)
        {
            _db = db;
        }

        public void AddProductRating(int productId, double rating)
        {
            Product product = _db.products.Where(p => p.ProductId == productId).FirstOrDefault();

            if (product != null)
            {
                double oldRating = product.Rating;
                double newRating = (oldRating + rating) / 2;
                product.Rating = newRating;
                _db.products.Update(product);
                _db.SaveChanges();

            }

        }
        public List<Product> GetAllProducts()
        {
            if (_db.products != null)
            {
                return _db.products.ToList();
            }
            return null;
        }

        public Product SearchProductById(int productId)
        {
            Product product = _db.products.Where(p => p.ProductId == productId).FirstOrDefault();

            if (product != null)
            {
                return product;
            }
            return null;
        }

        public Product SearchProductByName(string productName)
        {
            Product product = _db.products.Where(p => p.ProductName == productName).FirstOrDefault();

            if (product != null)
            {
                return product;
            }
            return null;
        }
    }
}
