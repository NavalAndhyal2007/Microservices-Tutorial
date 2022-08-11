using Ecommerce.Api.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Products.ProductService
{
    public interface IProductsRepository
    {
        Task<(bool IsSuccess, List<Product> Products, string ShowErrorMessage)> GetProductsAsync();
        Task<(bool IsSuccess, Product Product, string ShowErrorMessage)> GetProductAsync(int id);
        Task<(bool IsSuccess, Product Product, string ShowErrorMessage)> AddProductAsync(Product product);
        Task<(bool IsSuccess, Product Product, string ShowErrorMessage)> DeleteProductAsync(int id);
        Task<(bool IsSuccess, Product Product, string ShowErrorMessage)> UpdateProductAsync(Product product);


    }
}
