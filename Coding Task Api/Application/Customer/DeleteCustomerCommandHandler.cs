using Coding_Task_Api.Domain.Interfaces;
using MediatR;

namespace Coding_Task_Api.Application.Customer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            // Check if the customer has existing orders
            bool hasOrders = await _unitOfWork.Customers.HasOrdersAsync(request.Id);
            if (hasOrders)
            {
                
                throw new InvalidOperationException("Cannot delete a customer with existing orders.");
            }

            var customer = await _unitOfWork.Customers.GetByIdAsync(request.Id);
            if (customer is null)
            {
                
                return;
            }

            _unitOfWork.Customers.Delete(customer);
            await _unitOfWork.CompleteAsync();
        }
    }
}
