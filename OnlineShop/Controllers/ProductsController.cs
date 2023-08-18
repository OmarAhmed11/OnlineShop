using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Entities;
using OnlineShop.Infrastructure.Data;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {

            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> getProducts()
        {
            var Products = await _productRepository.GetProductsAsync();
            return Ok(Products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            var Product = await _productRepository.GetProductByIdAsync(id);
            return Ok(Product);
        }
    }
}
