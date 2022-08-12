using Ecommerce.Api.ProductCategory.Context;
using Ecommerce.Api.ProductCategory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.ProductCategory.ProductCategoryService
{
    public class ProductsCategoryService : IProductsCategoryService
    {
        private readonly ProductsCategoryDBContext productsCategoryDBContext;
        public ProductsCategoryService(ProductsCategoryDBContext productsCategoryDBContext)
        {
            this.productsCategoryDBContext = productsCategoryDBContext;
        }
        public async Task<(bool IsSuccess, ProductsCategory ProductsCategory, string ShowErrorMessage)> GetProductCategoryAsync(int CategoryId)
        {

            var ProductCategoryResult = await productsCategoryDBContext.ProductsCategory.FirstOrDefaultAsync(prodCat => prodCat.Id == CategoryId);

            if(ProductCategoryResult != null)
            {
                return (true, ProductCategoryResult, "");
            }
            return (false, null, "Not Found");
            //throw new NotImplementedException();
        }
    }
}
