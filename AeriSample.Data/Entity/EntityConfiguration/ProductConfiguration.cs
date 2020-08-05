using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AeriSample.Data.Entity.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.ProductID);
            builder.ToTable("product", "production");
            builder.Property(e => e.ProductNumber);
            builder.Property(e => e.Name);
            builder.Property(e => e.Color);
            builder.Property(e => e.Size);
            builder.Property(e => e.PriceList).HasColumnName("ListPrice");

        }
    }
}
