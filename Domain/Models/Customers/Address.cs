using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Customers
{
       public class Address
    {
        public string Street {  get; set; }

        public Address(string street, string city, string zipcode)
        {
            Street = street;
            City = city;
            Zipcode = zipcode;
        }

        public string City { get; set; }
        public string Zipcode { get; set; }
    }
}
