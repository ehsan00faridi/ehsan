using Domain.Models.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Command
{
    public record class DeleteProductCommand(int id):IRequest<bool>;

    internal class DeleteProductcommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {

        private readonly IProductRepository _productRepository;

        public DeleteProductcommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var Product = await _productRepository.Get(i => i.Id == request.id).FirstOrDefaultAsync();
            if (Product is null) {
                throw new ArgumentException();
            }
            Product.Enable = false;
            await _productRepository.UpdateAsync(Product);
            await _productRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;

        }
    }
}
