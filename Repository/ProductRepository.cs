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

        /*public List<Product> GetAllProducts()
        {
            return _db.products.ToList();
        }*/

        public List<Product> SearchProductById(int Id)
        {
            List<Product> p = _db.products.Where(p => p.Id == Id).ToList();
            return p;
        }

        public List<Product> SearchProductByName(string name)
        {
            List<Product> p1 = _db.products.Where(p1 => p1.Name.Contains(name)).ToList();
            return p1;
        }

        public void AddProductRating(int Id, int rating)
        {
            
             //List<Product> p2 = _db.products.Where(x => x.Id == Id).ToList();
                Product p = new Product();
                 p = _db.products.FirstOrDefault(x => x.Id == Id);
                 p.Rating = rating;
                _db.products.Update(p);
                _db.SaveChanges();
            
            
        }
    }
}
