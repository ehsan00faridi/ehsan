using Domain.BaseEntity;
using Domain.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Ordera
{
    public class Order:BaseEntity<int>
    {
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public int CustomerId {  get; set; }
        public Customer customer { get; set; } 
        public  ICollection<OrderItems> Items { get;  }
      //  public ICollection<Order> orders { get; }

    }
}
