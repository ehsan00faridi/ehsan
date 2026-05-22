using Domain.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Ordera
{
    public interface IOrdersRepository:IBaseRepository<Order,int>
    {
    }
}
