using Application.Command.Pagination;

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
