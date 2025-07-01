using Coding_Task_Api.Domain.Aggregates;

namespace Coding_Task_Api.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(Guid customerId);
    }
}
