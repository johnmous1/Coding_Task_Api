using Coding_Task_Api.Domain.Interfaces;
using Coding_Task_Api.Domain.ValueObjects;
using MediatR;

namespace Coding_Task_Api.Application.Customer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            
            var customer = await _unitOfWork.Customers.GetByIdAsync(request.Id);

            if (customer is null)
            {
                
                throw new Exception($"Customer with ID {request.Id} not found.");
            }

            //bypass null value
            var updatedFirstName = !string.IsNullOrWhiteSpace(request.FirstName)
                ? request.FirstName
                : customer.FullName.FirstName;

            var updatedLastName = !string.IsNullOrWhiteSpace(request.LastName)
                ? request.LastName
                : customer.FullName.LastName;

            var updatedFullName = new FullName(updatedFirstName, updatedLastName);

            var updatedStreet = !string.IsNullOrWhiteSpace(request.Street)
                ? request.Street
                : customer.Address.Street;

            var updatedCity = !string.IsNullOrWhiteSpace(request.City)
                ? request.City
                : customer.Address.City;

            var updatedPostalCode = !string.IsNullOrWhiteSpace(request.PostalCode)
                ? request.PostalCode
                : customer.Address.PostalCode;

            var updatedAddress = new Address(updatedStreet, updatedCity, updatedPostalCode);

            customer.Update(updatedFullName, updatedAddress);

            await _unitOfWork.CompleteAsync();
        }
    }
}
