using Ecommerce.Api.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.ProductsService
{
    public interface IProductService
    {
        Task<(bool IsSuccess, Product Product, string ShowErrorMessage)> GetProductsAsync(int id);
    }
}
