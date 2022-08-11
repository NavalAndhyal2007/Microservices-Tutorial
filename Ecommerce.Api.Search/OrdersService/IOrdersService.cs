using Ecommerce.Api.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.OrdersService
{
    public interface IOrdersService
    {
        // GetOrders
        Task<(bool IsSuccess, List<Order> Orders, string ShowErrorMessage)> GetOrdersAsync(int CustomerId);
    }
}
