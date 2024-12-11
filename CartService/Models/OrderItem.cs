namespace CartService.Models
{
    public class OrderItem
    {
        public string? ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
