using MediatR;

namespace Coding_Task_Api.Application.Products
{
    public record GetAllProductsQuery() : IRequest<IEnumerable<ProductDto>>;

}
