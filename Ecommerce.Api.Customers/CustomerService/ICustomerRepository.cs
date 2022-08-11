using Ecommerce.Api.Customers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Customers.CustomerService
{
    public interface ICustomerRepository
    {
        Task<(bool IsSuccess, List<Customer> Customers, string ShowErrorMessage)> GetCustomersAsync();
        Task<(bool IsSuccess, Customer customer, string ShowErrorMessage)> GetCustomerAsync(int id);
        Task<(bool IsSuccess, Customer customer, string ShowErrorMessage)> AddCustomerAsync(Customer customer);
        Task<(bool IsSuccess, Customer customer, string ShowErrorMessage)> DeleteCustomerAsync(int id);
        Task<(bool IsSuccess, Customer customer, string ShowErrorMessage)> UpdateCustomerAsync(Customer customer);
    }
}
