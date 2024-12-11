namespace CartService.Models
{
    public class CreateOrderRequest
    {
        public string? OrderId { get; set; }
        public int ItemsNum { get; set; }
    }
}
