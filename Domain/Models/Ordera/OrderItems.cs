using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.BaseEntity;
using Domain.Models.Products;
namespace Domain.Models.Ordera
{
    public class OrderItems:BaseEntity<int>
    {
        public int Productid {  get; set; }
        public Product product { get; set; }
        public decimal Price { get; set; }
        public int Qty {  get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
