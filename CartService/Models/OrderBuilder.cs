namespace CartService.Models
{
    public class OrderBuilder
    {
        private Order m_order;

        public OrderBuilder(string orderId, int itemNum)
        {
            Random random = new Random();
            decimal totalAmount = 0;
            m_order = new Order
            {
                OrderId = orderId,
                CustomerId = random.Next(100000000, 999999999).ToString(),
                OrderDate = DateTime.UtcNow,
                Items = GenerateOrderItems(itemNum, ref totalAmount),
                TotalAmount = totalAmount,
                Currency = "USD",
                Status = "new"
            };
        }

        private List<OrderItem> GenerateOrderItems(int itemNum, ref decimal totalAmount)
        {
            List<OrderItem> items = new List<OrderItem>();
            Random random = new Random();
            for (int i = 0; i < itemNum; i++)
            {
                var price = random.Next(10, 100);
                var quantity = random.Next(1, 5);
                items.Add(new OrderItem
                {
                    ItemId = random.Next(1, 100).ToString(),
                    Quantity = quantity,
                    Price = price
                });
                totalAmount += price * quantity;
            }
            return items;
        }

        public Order Build()
        {
            return m_order;
        }
    }
}
