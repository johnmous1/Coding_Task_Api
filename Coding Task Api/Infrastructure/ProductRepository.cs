using Coding_Task_Api.Domain.Aggregates;
using Coding_Task_Api.Domain.Interfaces;

namespace Coding_Task_Api.Infrastructure
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }
    }
}
