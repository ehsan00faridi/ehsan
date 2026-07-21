using Dapper;
using Domain.Models.Products;
using Infrastrucure.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastrucure.Repository
{
    public class ProductRepository :BaseRepository<Product,int>, IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(ApplicationDbContext context):base(context) {
            _connection = context.Database.GetDbConnection();
        }

        public async Task<IEnumerable<Domain.Models.Products.ProductDto>> GetAllProducts()
        {
            var sql = "SELECT * FROM products  WHERE Enable = 1";
            return await _connection.QueryAsync<Domain.Models.Products.ProductDto>(sql);
        }

        

        public async Task<Domain.Models.Products.ProductDto> GetProductById(int id)
        {
            var sql = "select * from products\r\nwhere Id=@Id";
           
            return await _connection.QueryFirstOrDefaultAsync<Domain.Models.Products.ProductDto>(sql, new { Id = id });
        }

    }
}
