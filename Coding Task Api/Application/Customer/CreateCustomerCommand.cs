using MediatR;

namespace Coding_Task_Api.Application.Customer
{
    public record CreateCustomerCommand(
    string FirstName,
    string LastName,
    string Street,
    string City,
    string PostalCode) : IRequest<Guid>;
}
