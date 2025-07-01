namespace Coding_Task_Api.Domain.Aggregates
{
    
        public class Item
        {
            public Guid Id { get; private set; }
            public Guid ProductId { get; private set; }
            public int Quantity { get; private set; }
            public decimal Price { get; private set; } 

            private Item() { }

            public static Item Create(Guid productId, int quantity, decimal price)
            {
                // Add domain validation here (e.g., quantity must be > 0)
                return new Item { Id = Guid.NewGuid(), ProductId = productId, Quantity = quantity, Price = price };
            }
        }
    }
