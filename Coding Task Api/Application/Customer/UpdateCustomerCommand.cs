using MediatR;

namespace Coding_Task_Api.Application.Customer
{
    public record UpdateCustomerCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string Street,
    string City,
    string PostalCode) : IRequest;
}
