using Domain.BaseEntity;
using Domain.Models.Ordera;
using Domain.Models.User;

namespace Domain.Models.Customers
{
    public class Customer : BaseEntity<int>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        public Address? Address { get; private set; }

        public ICollection<Order> Orders { get; private set; } = new List<Order>();

        public int? UserId { get; private set; }
       // public User User { get; private set; }

        private Customer() { }

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
            if (userId <= 0)
                throw new ArgumentException("UserId is invalid.", nameof(userId));

            if (UserId.HasValue)
                throw new InvalidOperationException("Customer is already linked to a user.");

            UserId = userId;
        }
    }
}
