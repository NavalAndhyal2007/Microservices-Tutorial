using Ecommerce.Api.Search.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.ProductsService
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory clientFactory;
        public ProductService(IHttpClientFactory httpClientFactory)
        {
            clientFactory = httpClientFactory;
        }
        
        public async Task<(bool IsSuccess, Product Product, string ShowErrorMessage)> GetProductsAsync(int id)
        {

            try
            {
                var client = clientFactory.CreateClient("ProductsService");
                var Response = await client.GetAsync("/api/Products/" + id);
                if (Response.IsSuccessStatusCode)
                {
                    var cont = await Response.Content.ReadAsStringAsync();

                    Product Result = JsonConvert.DeserializeObject<Product>(cont);

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
        }
    }
}
