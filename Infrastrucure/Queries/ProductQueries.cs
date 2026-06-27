using Application.Command.Pagination;
using Application.Features.Products.Dto;
using Application.Features.Products.Query;
using Dapper;
using System.Data;

namespace Infrastructure.Queries
{
    // PaginatedList

    public class ProductQueries : IProductQueries
    {
        private readonly IDbConnection _connection;

        public ProductQueries(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<PaginatedList<ProductDto>> GetProductsAsync(
            string? search,
            int pageNumber,
            int pageSize,
            bool disablePaging)
        {
            var whereClause = "WHERE Enable = 1";

            if (!string.IsNullOrEmpty(search))
            {
                whereClause += " AND Name LIKE @Search";
            }

            var countSql = $@"
            SELECT COUNT(*) 
            FROM Products
            {whereClause}
        ";

            var totalCount = await _connection.ExecuteScalarAsync<int>(
                countSql,
                new { Search= $"%{search}%" }
            );

            var sql = $@"
            SELECT 
                Id,
                Name,
                Price
            FROM Products
            {whereClause}
            ORDER BY Id
            OFFSET @Offset ROWS
            FETCH NEXT @PageSize ROWS ONLY
        ";

            var items = disablePaging
     ? await _connection.QueryAsync<ProductDto>(sql.Replace("OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY", "")
                , new { Search = $"%{search}%" })

                : await _connection.QueryAsync<ProductDto>(sql, new
                {
                    Search = $"%{search}%",
                    Offset = (pageNumber - 1) * pageSize,
                    PageSize = pageSize
                });

            return new PaginatedList<ProductDto>(
                 items.ToList(),
                 pageNumber,
                 pageSize,
                 totalCount
            );
        }
    }

}
