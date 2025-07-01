using MediatR;

namespace Coding_Task_Api.Application.Orders
{
    public record CreateOrderCommand(
    Guid CustomerId,
    List<OrderItemDto> Items) : IRequest<Guid>;
}
