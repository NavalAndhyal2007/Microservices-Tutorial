using Ecommerce.Api.Search.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.OrdersService
{
    public class OrdersReturnObj
    {
        public List<Order> Orders { get; set; }
    }
    public class OrderService : IOrdersService
    {
        private readonly IHttpClientFactory clientFactory;
        public OrderService(IHttpClientFactory httpClientFactory)
        {
            clientFactory = httpClientFactory;
        }
        public async Task<(bool IsSuccess, List<Order> Orders, string ShowErrorMessage)> GetOrdersAsync(int CustomerId)
        {

            try
            {
                var client = clientFactory.CreateClient("OrdersService");
                var Response = await client.GetAsync("/api/Orders/" + CustomerId);
                if (Response.IsSuccessStatusCode)
                {
                    var cont = await Response.Content.ReadAsStringAsync();

                    List <Order> Result = JsonConvert.DeserializeObject<List<Order>>(cont);

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

            throw new NotImplementedException();
        }
    }
}
