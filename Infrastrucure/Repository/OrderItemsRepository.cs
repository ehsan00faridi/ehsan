

using Domain.Models.Ordera;
using Infrastrucure;
using Infrastrucure.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastructure.Repository
{
    public class OrderItemsRepository : BaseRepository<OrderItems, int>, IOrderItemsRepository
    {
        private readonly IDbConnection _connection;

        public OrderItemsRepository(ApplicationDbContext context) : base(context)
        {
            _connection = context.Database.GetDbConnection();
        }

       
    }
}
