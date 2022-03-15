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
        IProductRepository prodrepo;

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProductController));

        public ProductController(IProductRepository _prodrepo)
        {
            prodrepo = _prodrepo;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            _log4net.Info("ProductController - GetAllProducts");

            try
            {
                var result = prodrepo.GetAllProducts();

                if (result != null)
                {
                    _log4net.Info("ProductController - GetAllProducts - All Products Fetched");

                    return Ok(result);
                }
                _log4net.Info("ProductController - GetAllProducts - Products Not Found");
                return NotFound("Not Products");
            }

            catch (Exception)
            {
                _log4net.Info("ProductController - GetAllProducts - Bad Request");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("SearchProductById")]
        public IActionResult SearchProductById(int productId)
        {
            _log4net.Info("ProductController - SearchProductById");

            try
            {
                var result = prodrepo.SearchProductById(productId);

                if (result != null)
                {
                    _log4net.Info("ProductController - SearchProductById - Successfuly Searched Product Id: " + productId);

                    return Ok(result);
                }
                _log4net.Info("ProductController - SearchProductById - Search Failed for Product Id: " + productId);
                return NotFound("No Product Found with the Id : " + productId);
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
                var result = prodrepo.SearchProductByName(productName);

                if (result != null)
                {
                    _log4net.Info("ProductController - SearchProductByName - Successfuly Searched Product Name: " + productName);

                    return Ok(result);
                }
                _log4net.Info("ProductController - SearchProductByName - Search Failed for Product Name: " + productName);
                return NotFound("No Product Found with the Name: " + productName);
            }

            catch (Exception)
            {
                _log4net.Info("ProductController - SearchProductByName - Bad Request");
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("AddProductRating/{productId}/{rating}")]
        public IActionResult AddProductRating(int productId, double rating)
        {
            _log4net.Info("ProductController - AddProductRating");

            double[] validRating = new double[5] { 1, 2, 3, 4, 5 };

            if (!validRating.Contains(rating))
            {
                return BadRequest("Enter a valid rating");
            }

            try
            {
                var p4 = prodrepo.SearchProductById(productId);
                if (p4 == null)
                {
                    _log4net.Error("Product Rating Not Added");
                    return NotFound("Product Rating Not Added because Product not found");
                }
                else
                {
                    _log4net.Info("Add Product Rating");
                    prodrepo.AddProductRating(productId,rating);
                    return Ok("Success");
                }
            }

            catch (Exception)
            {
                _log4net.Info("ProductController - AddProductRating - Bad Request");
                return BadRequest();
            }
        }
    }
}
