using MediatR;

namespace Coding_Task_Api.Application.Orders
{
    public record GetCustomerOrdersQuery(Guid CustomerId) : IRequest<IEnumerable<OrderWithDetailsDto>>;




}
