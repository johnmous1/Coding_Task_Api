using Coding_Task_Api.Domain.Aggregates;
using Coding_Task_Api.Domain.Interfaces;
using MediatR;

namespace Coding_Task_Api.Application.Products
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = Product.Create(request.Name, request.Price);

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CompleteAsync();

            return product.Id;
        }
    }
}
