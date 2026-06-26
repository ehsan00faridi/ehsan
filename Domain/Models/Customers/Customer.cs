using Domain.BaseEntity;
using Domain.Event;
using Domain.Models.Ordera;

namespace Domain.Models.Customers
{
    public class Customer : BaseEntity<int>
    {
        public string? UserId { get; private set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public Address Address { get; private set; }

        public ICollection<Order> Orders { get; private set; } = new List<Order>();

        //private Customer()
        //{
            
        //}

        public Customer(string name, string email, string? userId = null)
        {
            Name = name;
            Email = email;
            UserId = userId;
        }

        public void SetAddress(Address address)
        {
            Address = address;
        }

        public void LinkToUser(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("UserId cannot be empty.", nameof(userId));

            if (UserId is not null)
                throw new InvalidOperationException("Customer is already linked to a user.");

            UserId = userId;
        }
    }


}
