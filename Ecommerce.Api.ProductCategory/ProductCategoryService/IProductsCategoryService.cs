using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Api.ProductCategory.Models;

namespace Ecommerce.Api.ProductCategory.ProductCategoryService
{
    public interface IProductsCategoryService
    {
        Task<(bool IsSuccess, ProductsCategory ProductsCategory, string ShowErrorMessage)> GetProductCategoryAsync(int CategoryId);
    }
}
