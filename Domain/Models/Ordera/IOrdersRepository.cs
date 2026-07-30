using Domain.BaseRepository;
using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Ordera
{
    public interface IOrdersRepository:IBaseRepository<Order,int>
    {
        Task<IEnumerable<ProductDto>> GetOrders(int? UserId);
    }
}
