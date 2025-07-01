using Coding_Task_Api.Domain.Interfaces;

namespace Coding_Task_Api.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ICustomerRepository Customers { get; }
        public IOrderRepository Orders { get; }
        public IProductRepository Products { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Orders = new OrderRepository(_context);
            Products = new ProductRepository(_context);
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
