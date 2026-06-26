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

            builder.Property(x => x.UserId)
                .HasMaxLength(450)
                .IsRequired(false);

            builder.HasIndex(x => x.UserId)
                .IsUnique()
                .HasFilter("[UserId] IS NOT NULL");

            builder.Property(x => x.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(256)
                .IsRequired();

            builder.OwnsOne(s => s.Address, addressBuilder =>
            {
                addressBuilder.Property(x => x.City)
                    .HasMaxLength(100)
                    .HasColumnName("City");

                addressBuilder.Property(x => x.Street)
                    .HasMaxLength(100)
                    .HasColumnName("Street");

                addressBuilder.Property(x => x.Zipcode)
                    .HasMaxLength(100)
                    .HasColumnName("Zipcode");
            });
        }
    }

}
