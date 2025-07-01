namespace Coding_Task_Api.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }

        Task<int> CompleteAsync();
    }
}
