using Application.Command.Exceptions;
using Application.Interfaces;
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
    internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _repository;
        private readonly IFileUploadservice _fileUploadservice;

        public UpdateProductCommandHandler(IProductRepository repository,
            IFileUploadservice fileUploadservice)
        {
            _repository = repository;
            _fileUploadservice = fileUploadservice;
        }

     
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            




            string? fileName = request.Img;


            if (request.Img != null && request.Img.Length > 0)
            {
                await _fileUploadservice.DeleteFile(fileName);
                fileName = await _fileUploadservice.UploadFileAsync(request.Imgfile);
            }






            var data =await _repository.Get(i=> i.Id==request.Id).FirstOrDefaultAsync();
            //i.Enable &&
            if (data is null) {

               // throw new CustomException("محصول یافت نشد");
            }
            data.Update(request.Name, request.Price, request.Qty,fileName);
            data.SetProperty(new Mechanicalproppertis(request.Weight,request.material));

           await _repository.UpdateAsync(data);
           await  _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);



            return true;
        }
    }
}
