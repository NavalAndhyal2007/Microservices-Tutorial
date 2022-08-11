using Ecommerce.Api.Search.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.CustomersService
{
    public class CustomerService : ICustomerService
    {
        private readonly IHttpClientFactory clientFactory;
        public CustomerService(IHttpClientFactory httpClientFactory)
        {
            clientFactory = httpClientFactory;
        }
        public async Task<(bool IsSuccess, Customer Customer, string ShowErrorMessage)> GetCustomerAsync(int CustomerId)
        {
            try
            {
                var client = clientFactory.CreateClient("CustomersService");
                var Response = await client.GetAsync("/api/Customers/" + CustomerId);
                if (Response.IsSuccessStatusCode)
                {
                    var cont = await Response.Content.ReadAsStringAsync();

                    Customer Result = JsonConvert.DeserializeObject<Customer>(cont);

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
