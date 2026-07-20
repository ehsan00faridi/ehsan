using Application.Features.Products.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Command
{
    public class UpdateProductCommand : ProductDto,IRequest<bool>{



}
}
