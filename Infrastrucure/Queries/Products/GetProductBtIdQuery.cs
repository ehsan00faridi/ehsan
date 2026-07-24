using Application.Interfaces;
using Dapper;
using System.Data;

namespace Infrastructure.Queries.Products
{
    public class ProductById: IProductById
    {
        private readonly IDbConnection _connection;

        public ProductById(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Domain.Models.Products.ProductDto> FindAsync(int id)
        {
            string sql = @"SELECT *
                   FROM Products WHERE Id = @Id";
            return
            await _connection.QueryFirstOrDefaultAsync<Domain.Models.Products.ProductDto>(sql, new { Id = id });
        }
    }

}
