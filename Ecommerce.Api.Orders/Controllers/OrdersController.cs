using Ecommerce.Api.Orders.OrderService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var Result = await _orderRepository.GetOrdersAsync();
            if (Result.IsSuccess == true)
                return Ok(Result.Orders);
            else
                return NotFound();
        }

        [HttpGet("{CustomerId}")]
        public async Task<IActionResult> GetOrderAsync(int CustomerId)
        {
            var Result = await _orderRepository.GetOrderAsync(CustomerId);
            if (Result.IsSuccess == true)
                return Ok(Result.Orders);
            else
                return NotFound();
        }
    }
}
