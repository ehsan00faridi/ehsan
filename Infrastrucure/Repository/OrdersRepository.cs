using Domain.Models.Ordera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastrucure.BaseRepository;

namespace Infrastrucure.Repository
{
    public class OrdersRepository : BaseRepository<Order, int>, IOrdersRepository
    {
        public OrdersRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
