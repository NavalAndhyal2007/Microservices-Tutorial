using Ecommerce.Api.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.ProductCategoryService
{
    public interface IProductsCategoryService
    {
        Task<(bool IsSuccess, ProductCategory ProductCategory, string ShowErrorMessage)> GetProductCategoryAsync(int CategoryId);

        void Show()
        {
            Console.WriteLine("Hello");
        }
    }
}
