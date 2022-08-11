using Ecommerce.Api.Products.Context;
using Ecommerce.Api.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Products.ProductService
{
    public class ProductRepository : IProductsRepository
    {
        private readonly ProductsDBContext dBContext;
        private readonly ILogger<ProductRepository> logger;

        public ProductRepository(ProductsDBContext dBContext, ILogger<ProductRepository> logger)
        {
            this.dBContext = dBContext;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, Product Product, string ShowErrorMessage)> AddProductAsync(Product product)
        {
            var Result = await dBContext.Products.AddAsync(product);
            int response = await dBContext.SaveChangesAsync();
            try
            {
                if (Result != null && response == 1)
                {
                    return (true, Result.Entity, null);
                }
                else
                {
                    return (false, null, "No Results");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                return (false, null, ex.Message);
            }
            //throw new NotImplementedException();
        }

        public async Task<(bool IsSuccess, Product Product, string ShowErrorMessage)> DeleteProductAsync(int id)
        {
            var FindResult = await GetProductAsync(id);
            var Result = dBContext.Products.Remove(FindResult.Product);
            int response = await dBContext.SaveChangesAsync();
            try
            {
                if (Result != null && response == 1)
                {
                    return (true, Result.Entity, null);
                }
                else
                {
                    return (false, null, "No Results");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                return (false, null, ex.Message);
            }
            //throw new NotImplementedException();
        }

        public async Task<(bool IsSuccess, Product Product, string ShowErrorMessage)> GetProductAsync(int id)
        {
            var Result = await dBContext.Products.FirstOrDefaultAsync<Product>(prod => prod.Id == id);
            try
            {
                if (Result != null)
                {
                    return (true, Result, null);
                }
                else
                {
                    return (false, null, "No Results");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                return (false, null, ex.Message);
            }
            //throw new NotImplementedException();
        }

        //public (bool IsSuccess, List<Product> Products, string ShowwErrorMessage) ReturnResponse()

        public async Task<(bool IsSuccess, List<Product> Products, string ShowErrorMessage)> GetProductsAsync()
        {
            var result = await dBContext.Products.ToListAsync();
            try
            {
                if (result != null)
                {
                    return (true, result, null);
                }
                else
                {
                    return (false, null, "No Results");
                }
            }
            catch(Exception ex)
            {
                logger.LogError(ex.StackTrace);
                return (false, null, ex.Message);
            }
            //throw new NotImplementedException();
        }

        public async Task<(bool IsSuccess, Product Product, string ShowErrorMessage)> UpdateProductAsync(Product product)
        {
            var Result =  dBContext.Products.Update(product);
            int response = await dBContext.SaveChangesAsync();
            try
            {
                if (Result != null && response == 1)
                {
                    return (true, Result.Entity, null);
                }
                else
                {
                    return (false, null, "No Results");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                return (false, null, ex.Message);
            }
            //throw new NotImplementedException();
        }
    }
}
