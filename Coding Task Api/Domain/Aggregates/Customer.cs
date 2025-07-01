using Coding_Task_Api.Domain.ValueObjects;
namespace Coding_Task_Api.Domain.Aggregates;

public class Customer
{
    public Guid Id { get; private set; }
    public FullName FullName { get; private set; }
    public Address Address { get; private set; }

    private Customer() { } // For EF Core

    public static Customer Create(FullName fullName, Address address)
    {
        return new Customer { Id = Guid.NewGuid(), FullName = fullName, Address = address };
    }
    public void Update(FullName fullName, Address address)
    {
        FullName = fullName;
        Address = address;
    }
}


