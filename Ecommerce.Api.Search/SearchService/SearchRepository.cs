using Ecommerce.Api.Search.CustomersService;
using Ecommerce.Api.Search.Models;
using Ecommerce.Api.Search.OrdersService;
using Ecommerce.Api.Search.ProductCategoryService;
using Ecommerce.Api.Search.ProductsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.SearchService
{
    public class SearchRepository : ISearchRepository
    {
        private readonly IOrdersService ordersService;
        private readonly IProductService productService;
        private readonly ICustomerService customerService;
        private readonly IProductsCategoryService productsCategoryService;

        public SearchRepository(IOrdersService ordersService,IProductService productService,ICustomerService customerService, IProductsCategoryService productsCategoryService)
        {
            this.ordersService = ordersService;
            this.productService = productService;
            this.customerService = customerService;
            this.productsCategoryService = productsCategoryService;
        }
        public async Task<(bool IsSuccess, dynamic Result, string ShowErrorMessage)> SearchAsync(int CustomerId)
        {
            var OrderResults = await ordersService.GetOrdersAsync(CustomerId);
            var CustomerResult = await customerService.GetCustomerAsync(CustomerId);
            if (OrderResults.IsSuccess)
            {
                foreach (var Order in OrderResults.Orders)
                {
                    foreach (var item in Order.OrderItems)
                    {
                        var ProductResult = await productService.GetProductsAsync(item.ProductId);
                        item.ProductName = ProductResult.IsSuccess ? ProductResult.Product.Name : "Product Information Not Available";

                        //productsCategoryService.Show();
                        var ProductsCategoryResult = await productsCategoryService.GetProductCategoryAsync(ProductResult.Product.CategoryId);
                        item.CategoryName = ProductsCategoryResult.IsSuccess ? ProductsCategoryResult.ProductCategory.Name : "Product Category Information Not Available";
                    }
                }
                var retVal = new
                {
                    Customer = CustomerResult.IsSuccess ? CustomerResult.Customer : new Customer { Name = "Customer Information Not Available" },
                    Orders = OrderResults.Orders
                };
                return (true, retVal, "");
            }
            return (false, null, null);
        }
    }
}
