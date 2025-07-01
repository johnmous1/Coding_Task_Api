namespace Coding_Task_Api.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        void Delete(T entity);
    }
}
