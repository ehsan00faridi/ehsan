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
    internal class OrderItemsConfiguration : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
           builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Order).WithMany(x => x.Items)
                .OnDelete(DeleteBehavior.Restrict).HasForeignKey(x=>x.OrderId);

            builder.HasOne(x => x.product).WithMany(x => x.Items)
              .OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.Productid);
        }
    }
}
