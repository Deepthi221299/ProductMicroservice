using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repository
{
    public interface IProductRepository
    {
        //public List<Product> GetAllProducts();
        public List<Product> SearchProductById(int Id);
        public List<Product> SearchProductByName(string name);

        public void AddProductRating(int Id, int rating);
    }
}
