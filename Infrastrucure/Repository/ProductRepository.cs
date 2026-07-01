using Application.Features.Products.Dto;
using Dapper;
using Domain.Models.Customers;
using Domain.Models.Products;
using Infrastrucure.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Repository
{
    public class ProductRepository :BaseRepository<Product,int>, IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(ApplicationDbContext context):base(context) {
            _connection = context.Database.GetDbConnection();
        }




        public Task<Product> GetProductById(int? id)
        {
            return GetProductById(id);
        }

        public async Task<Domain.Models.Products.ProductDto> GetProductById(int id)
        {
            var sql = "select * from products\r\nwhere Id=@Id";
           
            return await _connection.QueryFirstOrDefaultAsync<Domain.Models.Products.ProductDto>(sql, new { Id = id });
        }

        //public async Task<ProductDto> FindAsync(int id)
        //{
        //    string sql = @"SELECT *
        //           FROM Products WHERE Id = @Id";
        //    return
        //    await _connection.QueryFirstOrDefaultAsync<ProductDto>(sql, new { Id = id });
        //}
    }
}
