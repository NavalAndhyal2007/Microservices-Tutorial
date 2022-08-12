using Ecommerce.Api.ProductCategory.ProductCategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.ProductCategory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsCategoryController : ControllerBase
    {
        private readonly IProductsCategoryService productsCategoryService;
        public ProductsCategoryController(IProductsCategoryService productsCategoryService)
        {
            this.productsCategoryService = productsCategoryService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsCategoryAsync(int id)
        {
            var ProductsCategoryResult = await productsCategoryService.GetProductCategoryAsync(id);

            if(ProductsCategoryResult.IsSuccess)
            {
                return Ok(ProductsCategoryResult.ProductsCategory);
            }
            return NotFound();
        }
    }
}
