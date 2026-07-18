using Application.Command.Pagination;
using Application.Features.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Query
{
    public interface IProductQueries
    {

        Task<PaginatedList<Domain.Models.Products.ProductDto>> GetProductsAsync(
            string? search,
            int pageNumber,
            int pageSize,
            bool disablePaging);
    }
}
