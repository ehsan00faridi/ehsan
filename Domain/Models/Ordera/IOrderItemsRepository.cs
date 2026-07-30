using Domain.BaseRepository;
using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Ordera
{
    public interface IOrderItemsRepository : IBaseRepository<OrderItems, int>
    {
        
    }
}
