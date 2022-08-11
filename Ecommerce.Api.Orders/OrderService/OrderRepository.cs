using Ecommerce.Api.Orders.Context;
using Ecommerce.Api.Orders.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Orders.OrderService
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDBContext dBContext;

        public OrderRepository(OrderDBContext orderDB)
        {
            this.dBContext = orderDB;
        }

        public async Task<(bool IsSuccess, List<Order> Orders, string ShowErrorMessage)> GetOrderAsync(int CustomerId)
        {
            var Result = await dBContext.Orders.Where(o => o.CustomerId == CustomerId).ToListAsync();
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
                //logger.LogError(ex.StackTrace);
                return (false, null, ex.Message);
            }
            //throw new NotImplementedException();
        }

        public async Task<(bool IsSuccess, List<Order> Orders, string ShowErrorMessage)> GetOrdersAsync()
        {
            var Result = await dBContext.Orders.ToListAsync();
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
                //logger.LogError(ex.StackTrace);
                return (false, null, ex.Message);
            }
            //throw new NotImplementedException();
        }
    }
}
