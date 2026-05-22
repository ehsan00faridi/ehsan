using Domain.BaseEntity;
using Domain.Event;
using Domain.Models.Ordera;

namespace Domain.Models.Customers
{
    public class Customer:BaseEntity<int>
    {
      
        public string Name { get; set; }
        public string Email {  get; set; }
        public Address Address { get; private set; }

        public void setaddress(Address address)
        {
            Address = address;  
        }


        public Customer(string name, string email) { 
        Name = name;
        Email = email;
     //   AddDomainEvent(new UserRegisteredDomainEvent(Id, Email));

        }
        public ICollection<Order> Orders { get; }

    }
}
