using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Api.Orders.Models;

namespace Ecommerce.Api.Orders.OrderService
{
    public interface IOrderRepository
    {
        Task<(bool IsSuccess, List<Order> Orders, string ShowErrorMessage)> GetOrdersAsync();
        Task<(bool IsSuccess, List<Order> Orders, string ShowErrorMessage)> GetOrderAsync(int CustomerId);

    }
}
