﻿using E_Commerce_Admin_Dashboard_MVC;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Back_End.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices productServices;
        public ProductController(IProductServices productServices)
        {
            this.productServices = productServices;
        }
        [HttpGet]
        public string Index()
        {
            return "Hello";
        }
        [HttpGet]
        [Route("~/api/GetProducts")]
        public IActionResult GetProducts()
        {
            if (productServices.GetAllProducts() != null)
            {
                var products = productServices.GetAllProducts();
                return Ok(products);
            }
            //ProductsVM p = new ProductsVM();
            return NotFound();
        }

        [HttpGet]
        [Route("~/api/GetProductById/{id}")]
        public IActionResult GetProductById(int id)
        {
            if (productServices.GetProductById(id) != null)
            {
                var product = productServices.GetProductById(id);
                return Ok(product);
            }
            //ProductsVM p = new ProductsVM();
            return NotFound();
        }
        [HttpPut]
        [Route("~/api/UpdateProduct")]
        public IActionResult UpdateProduct(ProductsVM product)
        {
            if (ModelState.IsValid)
            {
                productServices.Edit(product);
                return Ok("Product Is Updated");
            }
            else
            {
                return BadRequest(" Validation Error");
            }

        }


        [HttpDelete]
        [Route("~/api/DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            if (productServices.GetProductById(id) != null)
            {
                 productServices.DeleteProduct(id);
                return Ok("product is Deleted");
            }
            //ProductsVM p = new ProductsVM();
            return NotFound("No Product By this Id");
        }
    }
}
