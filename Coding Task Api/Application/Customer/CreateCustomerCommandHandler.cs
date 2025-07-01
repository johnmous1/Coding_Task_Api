using AutoMapper;
using Coding_Task_Api.Domain.Interfaces;
using MediatR;
using Coding_Task_Api.Application.Orders;
using System.Collections.Generic;
using Coding_Task_Api.Domain.ValueObjects;
using Coding_Task_Api.Domain.Aggregates;



namespace Coding_Task_Api.Application.Customer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            
            var fullName = new FullName(request.FirstName, request.LastName);
            var address = new Address(request.Street, request.City, request.PostalCode);

            
            var customer = Domain.Aggregates.Customer.Create(fullName, address);

            await _unitOfWork.Customers.AddAsync(customer);

            await _unitOfWork.CompleteAsync();

            return customer.Id;
        }
    }
}
