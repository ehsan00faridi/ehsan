using Application.Interfaces;
using Domain.Models.Products;
using MediatR;

namespace Application.Features.Products.Command
{
    internal sealed class AddProductCommandHandler : IRequestHandler<AddProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileUploadservice _fileUploadservice;

        public AddProductCommandHandler(
            IProductRepository productRepository,
            IFileUploadservice fileUploadservice)
        {
            _productRepository = productRepository;
            _fileUploadservice = fileUploadservice;
        }

        public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            string? fileName = request.imgname;

            if (request.Img != null && request.Img.Length > 0)
            {
                fileName = await _fileUploadservice.UploadFileAsync(request.Img);
            }

            var product = new Product(request.Name, request.Price, request.Qty,fileName);
            product.SetProperty(new Mechanicalproppertis(request.Weight, request.material));

            // اگر داخل مدل Product فیلد/پراپرتی تصویر داری:
            // product.SetImage(fileName);
            // یا:
            // product.ImgName = fileName;

            await _productRepository.AddAsync(product);
            await _productRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return true;
        }
    }
}
