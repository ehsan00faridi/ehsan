using Domain.Models.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Query
{
    public class ProductList:IRequest<IEnumerable<ProductDto>>
    {

    }
}
