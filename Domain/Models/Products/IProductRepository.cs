using Domain.BaseRepository;
using Domain.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Products
{
    public interface IProductRepository:IBaseRepository<Product,int>
    {
         Task<ProductDto> GetProductById(int id);
    }
}
