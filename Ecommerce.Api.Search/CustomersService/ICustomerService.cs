using Ecommerce.Api.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.CustomersService
{
    public interface ICustomerService
    {
        Task<(bool IsSuccess, Customer Customer, string ShowErrorMessage)> GetCustomerAsync(int CustomerId);
    }
}
