using Coding_Task_Api.Domain.Aggregates;

namespace Coding_Task_Api.Domain.Interfaces
{

    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<bool> HasOrdersAsync(Guid customerId);

    }
}
