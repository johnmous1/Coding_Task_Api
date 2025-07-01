namespace Coding_Task_Api.Domain.Aggregates
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public decimal TotalPrice { get; private set; }

        private readonly List<Item> _items = new();
        public IReadOnlyCollection<Item> Items => _items.AsReadOnly();

        private Order() { }

        public static Order Create(Guid customerId, IEnumerable<Item> items)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                OrderDate = DateTime.UtcNow
            };

            order._items.AddRange(items);
            order.CalculateTotalPrice();
            return order;
        }

        private void CalculateTotalPrice()
        {
            TotalPrice = _items.Sum(item => item.Price * item.Quantity);
        }
    }
}
