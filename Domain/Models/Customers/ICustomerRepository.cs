using Domain.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Customers
{
    public interface ICustomerRepository:IBaseRepository<Customer,int>
    {
    }
}
