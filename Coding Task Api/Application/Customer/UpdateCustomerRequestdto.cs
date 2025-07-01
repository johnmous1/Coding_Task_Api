namespace Coding_Task_Api.Application.Customer
{
    public record UpdateCustomerRequest(
     string FirstName,
     string LastName,
     string Street,
     string City,
     string PostalCode);
}
