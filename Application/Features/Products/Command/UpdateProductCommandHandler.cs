using Application.Command.Exceptions;
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

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

     
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var data =await _repository.Get(i=> i.Id==request.id).FirstOrDefaultAsync();
            //i.Enable &&
            if (data is null) {

               // throw new CustomException("محصول یافت نشد");
            }
            data.Update(request.name, request.price, request.qty);
            data.SetProperty(new Mechanicalproppertis(request.weight,request.material));

           await _repository.UpdateAsync(data);
           await  _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);



            return true;
        }
    }
}
