using MediatR;
using Domain.Models.Products;

namespace Application.Features.Products.Command
{
    internal sealed class ProductCommandHandler : IRequestHandler<AddProductCommand, bool>
    {
        private readonly IProductRepository _ProductRepository;
        public ProductCommandHandler(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }

        public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Price, request.Qty);
            product.SetProperty(new Mechanicalproppertis( request.Weight,request.material));
            await _ProductRepository.AddAsync(product);
            await   _ProductRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
