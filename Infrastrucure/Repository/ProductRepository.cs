using Domain.Models.Products;
using Infrastrucure.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Repository
{
    public class ProductRepository :BaseRepository<Product,int>, IProductRepository
    {
    
        public ProductRepository(ApplicationDbContext context):base(context) { 
     
        }


    }
}
