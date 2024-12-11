using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderConsumer _orderService;

        public OrdersController(OrderConsumer orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("order-details")]
        public IActionResult GetOrderDetails([FromQuery] string orderId)
        {
            var order = _orderService.GetOrderDetails(orderId);
            if (order == null)
            {
                return NotFound(new { message = "Order not found." });
            }

            return Ok(order);
        }
    }
}
