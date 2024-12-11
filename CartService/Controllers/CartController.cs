using Microsoft.AspNetCore.Mvc;
using CartService.Models;

namespace CartService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly Publisher _publisher;

        public CartController(Publisher publisher)
        {
            _publisher = publisher;
        }

        [HttpPost("create-order")]
        public IActionResult CreateOrder([FromBody] CreateOrderRequest request)
        {
            if (request.ItemsNum < 0)
            {
                return BadRequest(new { message = "Invalid number of items. Must be positive number of items !" });
            }

            var orderBuilder = new OrderBuilder(request.OrderId, request.ItemsNum);
            var order = orderBuilder.Build();
            _publisher.PublishMessage(order); 

            return Ok(new { message = "Order created successfully!", orderId = order.OrderId });
        }
    }
}
