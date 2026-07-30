using Dapper;
using Domain.Models.Ordera;
using Domain.Models.Products;
using Infrastrucure.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastrucure.Repository
{
    public class OrdersRepository : BaseRepository<Order, int>, IOrdersRepository
    {
        private readonly IDbConnection _connection;

        public OrdersRepository(ApplicationDbContext context) : base(context)
        {
            _connection = context.Database.GetDbConnection();
        }
        public async Task<IEnumerable<ProductDto>> GetOrders(int? Userid)
        {
            if (Userid == null)
            {
                 throw new NotImplementedException();
            }
            string sql =
$@"
SELECT 
p.Id,
p.Name ,
p.Img,
p.material,
p.Weight,
oi.Qty,   
P.Price * oi.Qty AS Price
FROM OrderItems oi
JOIN Products p ON oi.ProductId = p.Id
JOIN Orders o ON oi.OrderId = o.Id
JOIN Customers c ON o.CustomerId = c.Id  and c.UserId=@UserId;";
var data= await _connection.QueryAsync<ProductDto>(sql, new { UserId = Userid });

            return data;

        }
        
    }
}
