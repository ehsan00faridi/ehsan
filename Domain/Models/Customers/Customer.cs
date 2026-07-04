using Domain.BaseEntity;
using Domain.Event;
using Domain.Models.Ordera;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Customers
{
    public class Customer : BaseEntity<int>
    {
      
        public string Name { get; set; }
        public string Email { get; set; }

        public Address Address { get; private set; }

        public ICollection<Order> Orders { get; private set; } = new List<Order>();
     
        public int? UserId { get; private set; }

        //private Customer()
        //{

        //}

        public Customer(string name, string email, int? userId = null)
        {
            Name = name;
            Email = email;
            UserId = userId;
        }

        public void SetAddress(Address address)
        {
            Address = address;
        }

        public void LinkToUser(int userId)
        {
            if (string.IsNullOrWhiteSpace(userId.ToString()))
                throw new ArgumentException("UserId cannot be empty.", nameof(userId));

            if (UserId is not null)
                throw new InvalidOperationException("Customer is already linked to a user.");

            UserId = userId;
        }
    }


}
