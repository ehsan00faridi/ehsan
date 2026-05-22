using Domain.Models.Ordera;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
          builder.HasKey(x => x.Id);
            builder.HasOne(x => x.customer)
                .WithMany(x=>x.Orders)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(s=>s.CustomerId);

        }
    }
}
