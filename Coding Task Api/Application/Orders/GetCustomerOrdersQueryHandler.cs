using AutoMapper;
using Coding_Task_Api.Domain.Interfaces;
using MediatR;

namespace Coding_Task_Api.Application.Orders
{
    public class GetCustomerOrdersQueryHandler : IRequestHandler<GetCustomerOrdersQuery, IEnumerable<OrderWithDetailsDto>>
    {
        // No IMapper needed for this handler anymore, we will build the DTO manually
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomerOrdersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OrderWithDetailsDto>> Handle(GetCustomerOrdersQuery request, CancellationToken cancellationToken)
        {
            var customerOrders = await _unitOfWork.Orders.GetOrdersByCustomerIdAsync(request.CustomerId);
            var detailedOrders = new List<OrderWithDetailsDto>();

            foreach (var order in customerOrders.OrderBy(o => o.OrderDate))//or // .OrderByDescending(o => o.OrderDate) for latest first
            {
                var itemDetails = new List<OrderItemDetailDto>();
                foreach (var item in order.Items)
                {
                    // Fetch the product to get its name
                    var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);

                    itemDetails.Add(new OrderItemDetailDto(
                        item.ProductId,
                        product?.Name ?? "Unknown Product", // Handle case where product might be deleted
                        item.Quantity,
                        item.Price
                    ));
                }

                detailedOrders.Add(new OrderWithDetailsDto(
                    order.Id,
                    order.OrderDate,
                    order.TotalPrice,
                    itemDetails
                ));
            }

            return detailedOrders;
        }
    }
}
