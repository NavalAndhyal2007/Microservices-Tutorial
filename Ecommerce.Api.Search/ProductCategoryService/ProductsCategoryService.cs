using Ecommerce.Api.Search.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.ProductCategoryService
{
    public class ProductsCategoryService : IProductsCategoryService
    {
        private readonly IHttpClientFactory clientFactory;
        public ProductsCategoryService(IHttpClientFactory httpClientFactory)
        {
            clientFactory = httpClientFactory;
        }
        void IProductsCategoryService.Show()
        {
            Console.WriteLine("Override the meaning");
        }
        public async Task<(bool IsSuccess, ProductCategory ProductCategory, string ShowErrorMessage)> GetProductCategoryAsync(int CategoryId)
        {
            try
            {
                var client = clientFactory.CreateClient("ProductsCategoryService");
                var Response = await client.GetAsync("/api/ProductsCategory/" + CategoryId);
                if (Response.IsSuccessStatusCode)
                {
                    var cont = await Response.Content.ReadAsStringAsync();
                    
                    ProductCategory Result = JsonConvert.DeserializeObject<ProductCategory>(cont);

                    if (Result != null)
                    {
                        return (true, Result, null);
                        
                    }
                    return (false, null, null);
                }
                else
                {
                    return (false, null, null);
                }
            }
            catch (Exception ex)
            {
                return (false, null, ex.StackTrace);
                throw;
            }
            //throw new NotImplementedException();
        }
    }
}
