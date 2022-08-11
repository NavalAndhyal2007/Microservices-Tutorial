using Ecommerce.Api.Products.Models;
using Ecommerce.Api.Products.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            this._productsRepository = productsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var Result = await _productsRepository.GetProductsAsync();
            if (Result.IsSuccess == true)
                return Ok(Result.Products);
            else
                return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var Result = await _productsRepository.GetProductAsync(id);
            if (Result.IsSuccess == true)
                return Ok(Result.Product);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(Product product)
        {
            var Result = await _productsRepository.AddProductAsync(product);
            if (Result.IsSuccess == true)
                return Ok(Result.Product);
            else
                return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(Product product)
        {
            var Result = await _productsRepository.UpdateProductAsync(product);
            if (Result.IsSuccess == true)
                return Ok(Result.Product);
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var Result = await _productsRepository.DeleteProductAsync(id);
            if (Result.IsSuccess == true)
                return Ok(Result.Product);
            else
                return NotFound();
        }
    }
}
