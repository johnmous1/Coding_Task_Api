using Coding_Task_Api.Domain.Aggregates;
using Coding_Task_Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Coding_Task_Api.Infrastructure
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context) { }

        public async Task<bool> HasOrdersAsync(Guid customerId)
        {
            return await _context.Orders.AnyAsync(o => o.CustomerId == customerId);
        }
    }
}
