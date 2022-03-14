using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Models;
using ProductMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _Iproduct;

        private readonly log4net.ILog _log4net;

        public ProductController(IProductRepository Iproduct)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(ProductController));
            _Iproduct = Iproduct;
          _log4net.Info("Logger initiated");
        }
        

        [HttpGet]
        [Route("SearchProductById")]
        public IActionResult SearchProductById(int productId)
        {
            _log4net.Info("ProductController - SearchProductById");

            try
            {
                var result = _Iproduct.SearchProductById(productId);

                if (result.Count != 0)
                {
                    _log4net.Info("ProductController - SearchProductById - Successfuly Searched Product Id: " + productId);

                    return Ok(result);
                }
                _log4net.Info("ProductController - SearchProductById - Search Failed for Product Id: " + productId);
                return NotFound("Product not found with the given Id : " + productId);
            }

            catch (Exception)
            {
                _log4net.Info("ProductController - SearchProductById - Bad Request");
                return BadRequest();
            }
        }

        
        [HttpGet]
        [Route("SearchProductByName")]
        public IActionResult SearchProductByName(string productName)
        {
            _log4net.Info("ProductController - SearchProductByName");

            try
            {
                var result = _Iproduct.SearchProductByName(productName);

                if (result.Count != 0)
                {
                    _log4net.Info("ProductController - SearchProductByName - Successfuly Searched Product Name: " + productName);

                    return Ok(result);
                }
                _log4net.Info("ProductController - SearchProductByName - Search Failed for Product Name: " + productName);
                return NotFound("Product Not Found By Given Name : " +productName);
            }

            catch (Exception)
            {
                _log4net.Info("ProductController - SearchProductByName - Bad Request");
                return BadRequest();
            }
        }

        [HttpPost("Rating")]
        public IActionResult AddRating(ProductRating data)
        {
            _log4net.Info("Searching for product for adding rating");
            double[] validRating = new double[5] { 1, 2, 3, 4, 5 };
            if (!validRating.Contains(data.rating))
            {
                return BadRequest("Enter a valid rating");
            }
            try
            {
                var p4 = _Iproduct.SearchProductById(data.Id);
                if (p4.Count == 0)
                {
                    _log4net.Error("Product Rating Not Added");
                    return NotFound("Product Rating Not Added because Product not found");
                }
                else
                {
                    _log4net.Info("Add Product Rating");
                    _Iproduct.AddProductRating(data.Id, data.rating);
                    return Ok("Success");
                }
                

            }
            catch (Exception)
            {
                _log4net.Info("ProductController - SearchProductByName - Bad Request");
                return BadRequest();
            }
            

        }
    }
}
