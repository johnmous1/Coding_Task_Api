using Coding_Task_Api.Domain.Aggregates;
using Coding_Task_Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Coding_Task_Api.Infrastructure
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(Guid customerId)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }
    }
}
