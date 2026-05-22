using Domain.Models.Customers;
using Domain.Models.Products;
using Infrastrucure.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Repository
{
    public class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
