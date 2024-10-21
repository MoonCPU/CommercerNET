using Ecommerce.Models;
using Ecommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            // Add the order to the Orders table
            await _orderRepository.AddOrder(order);

            //loop through each order item and add them to the OrderItems table
            //every order has a list of OrderItems, and we have to loop through this list
            //to get all order items
            foreach (var item in order.OrderItems)
            {
                //we have to ensure that the item's id is the same as the current object order's id
                item.OrderId = order.Id; 
                await _orderRepository.AddOrderItem(item);
            }

            return Ok();
        }
    }
}
