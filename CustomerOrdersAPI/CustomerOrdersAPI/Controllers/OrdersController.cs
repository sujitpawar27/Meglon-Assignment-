using CustomerOrdersAPI.DAL;
using CustomerOrdersAPI.Model;
using CustomerOrdersAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrdersAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("{customerId}")]
        public ActionResult<IEnumerable<Order>> GetOrders(Guid customerId)
        {
            try
            {
                var orders = _orderRepository.GetOrdersByCustomerId(customerId);
                if (orders == null || !orders.Any())
                {
                    return NotFound("No orders found for the specified customer");
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
