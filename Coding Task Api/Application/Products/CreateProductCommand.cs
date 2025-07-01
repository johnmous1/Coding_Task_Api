using MediatR;

namespace Coding_Task_Api.Application.Products
{
    public record CreateProductCommand(string Name, decimal Price) : IRequest<Guid>;

}
