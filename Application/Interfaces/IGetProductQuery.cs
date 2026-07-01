using Application.Features.Products.Dto;
using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductById
    {
        Task<Domain.Models.Products.ProductDto> FindAsync(int id);
    }
}
