using Coding_Task_Api.Domain.Aggregates;
using Coding_Task_Api.Domain.Interfaces;
using MediatR;

namespace Coding_Task_Api.Application.Orders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            
            var customer = await _unitOfWork.Customers.GetByIdAsync(request.CustomerId);
            if (customer is null)
            {
                throw new Exception($"Customer with ID {request.CustomerId} not found.");
            }

            var orderItems = new List<Item>();

            foreach (var itemDto in request.Items)
            {
                var product = await _unitOfWork.Products.GetByIdAsync(itemDto.ProductId);
                if (product is null)
                {
                    throw new Exception($"Product with ID {itemDto.ProductId} not found.");
                }

                var orderItem = Item.Create(product.Id, itemDto.Quantity, product.Price);
                orderItems.Add(orderItem);
            }

            var newOrder = Order.Create(request.CustomerId, orderItems);

            await _unitOfWork.Orders.AddAsync(newOrder);
            await _unitOfWork.CompleteAsync();

            return newOrder.Id;
        }
    }
}
