namespace Coding_Task_Api.Domain.Aggregates
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        // Private constructor for EF Core
        private Product() { }

        public static Product Create(string name, decimal price)
        {
           
            return new Product { Id = Guid.NewGuid(), Name = name, Price = price };
        }
    }
}
