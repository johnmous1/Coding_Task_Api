using MediatR;

namespace Coding_Task_Api.Application.Customer
{
    public record DeleteCustomerCommand(Guid Id) : IRequest;

}
