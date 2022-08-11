using Ecommerce.Api.Search.CustomersService;
using Ecommerce.Api.Search.Models;
using Ecommerce.Api.Search.ProductsService;
using Ecommerce.Api.Search.SearchService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchRepository searchService;
        private readonly IProductService productService;
        private readonly ICustomerService customerService;


        public SearchController(ISearchRepository searchService, IProductService productService, ICustomerService customerService)
        {
            this.searchService = searchService;
            this.productService = productService;
            this.customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> SearchAsync(SearchParam searchParams)
        {
            var OrderResults = await searchService.SearchAsync(searchParams.CustomerId);
            
            if(OrderResults.IsSuccess)
            {
                //foreach (var Order in OrderResults.Result)
                //{
                //    foreach (var item in Order.OrderItems)
                //    {
                //        var ProductResult = await productService.GetProductsAsync(item.ProductId);
                //        item.ProductName = ProductResult.IsSuccess ? ProductResult.Product.Name : "Product Information Not Available";
                //    }
                //}

                return Ok(OrderResults.Result);
            }
            return NotFound();
        }
    }
}
