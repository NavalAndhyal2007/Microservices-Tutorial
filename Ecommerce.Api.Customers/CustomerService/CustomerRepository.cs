using Ecommerce.Api.Customers.Context;
using Ecommerce.Api.Customers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Customers.CustomerService
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDBContext dBContext;

        public CustomerRepository(CustomerDBContext customerDB)
        {
            this.dBContext = customerDB;
        }
        public async Task<(bool IsSuccess, Customer customer, string ShowErrorMessage)> AddCustomerAsync(Customer customer)
        {
            var Result = await dBContext.Customers.AddAsync(customer);
            int response = await dBContext.SaveChangesAsync();
            try
            {
                if (Result != null && response == 1)
                {
                    return (true, Result.Entity, null);
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
        }

        public async Task<(bool IsSuccess, Customer customer, string ShowErrorMessage)> DeleteCustomerAsync(int id)
        {
            var FindResult = await GetCustomerAsync(id);
            var Result = dBContext.Customers.Remove(FindResult.customer);
            int response = await dBContext.SaveChangesAsync();
            try
            {
                if (Result != null && response == 1)
                {
                    return (true, Result.Entity, null);
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
        }

        public async Task<(bool IsSuccess, Customer customer, string ShowErrorMessage)> GetCustomerAsync(int id)
        {
            var Result = await dBContext.Customers.FirstOrDefaultAsync(cus => cus.Id == id);
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

        public async Task<(bool IsSuccess, List<Customer> Customers, string ShowErrorMessage)> GetCustomersAsync()
        {
            var Result = await dBContext.Customers.ToListAsync<Customer>();
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
        }

        public async Task<(bool IsSuccess, Customer customer, string ShowErrorMessage)> UpdateCustomerAsync(Customer customer)
        {
            var Result = dBContext.Customers.Update(customer);
            int response = await dBContext.SaveChangesAsync();
            try
            {
                if (Result != null && response == 1)
                {
                    return (true, Result.Entity, null);
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
        }
    }
}
