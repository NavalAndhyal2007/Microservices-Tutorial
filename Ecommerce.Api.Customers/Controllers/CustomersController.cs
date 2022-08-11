using Ecommerce.Api.Customers.CustomerService;
using Ecommerce.Api.Customers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerRepository _customerRepository;
        public CustomersController(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var Result = await _customerRepository.GetCustomersAsync();
            if (Result.IsSuccess == true)
                return Ok(Result.Customers);
            else
                return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            var Result = await _customerRepository.GetCustomerAsync(id);
            if (Result.IsSuccess == true)
                return Ok(Result.customer);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync(Customer product)
        {
            var Result = await _customerRepository.AddCustomerAsync(product);
            if (Result.IsSuccess == true)
                return Ok(Result.customer);
            else
                return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAsync(Customer product)
        {
            var Result = await _customerRepository.UpdateCustomerAsync(product);
            if (Result.IsSuccess == true)
                return Ok(Result.customer);
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            var Result = await _customerRepository.DeleteCustomerAsync(id);
            if (Result.IsSuccess == true)
                return Ok(Result.customer);
            else
                return NotFound();
        }
    }
}
