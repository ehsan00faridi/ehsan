using Domain.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Configuration
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(s => s.Address, addressBuilder =>
            {
 
                addressBuilder.Property(x => x.City).HasMaxLength(100).HasColumnName("City");
                addressBuilder.Property(x => x.Street).HasMaxLength(100).HasColumnName("Street");
                addressBuilder.Property(x => x.Zipcode).HasMaxLength(100).HasColumnName("Zipcode");
            });
        }
    }
}
