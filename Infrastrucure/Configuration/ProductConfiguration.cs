using Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>

    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            //.HasColumnType("nvarchar")
            //.HasColumnName("titel")

            builder.OwnsOne(s => s.Property, propetybuilder =>{
                propetybuilder.Property(x=>x.material).HasColumnName("material");
                propetybuilder.Property(x => x.Weight).HasColumnName("Weight");

            });
        }
    }
}
